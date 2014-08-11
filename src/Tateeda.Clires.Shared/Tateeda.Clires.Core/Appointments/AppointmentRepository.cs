// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppointmentRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The appointment repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Appointments
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading;

	using Tateeda.Clires.Core.Data.EF;
	using Tateeda.Clires.Core.Data.Enums;

	/// <summary>
	/// The appointment repository.
	/// </summary>
	public class AppointmentRepository : IAppointmentRepository
	{
		#region Fields

		/// <summary>
		/// The _context.
		/// </summary>
		private readonly IDbContext _context;

		#endregion

		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="AppointmentRepository"/> class.
		/// </summary>
		/// <param name="context">
		/// The context.
		/// </param>
		public AppointmentRepository(IDbContext context)
		{
			_context = context;
			All = _context.Appointments;
		}

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets the all.
		/// </summary>
		public IQueryable<Appointment> All { get; private set; }

		#endregion

		#region Public Methods and Operators

		/// <summary>
		/// The commit.
		/// </summary>
		public void Commit()
		{
			_context.Commit();
		}

		/// <summary>
		/// The create or update appointment form.
		/// </summary>
		/// <param name="apptForm">
		/// The appt form.
		/// </param>
		public void CreateOrUpdateAppointmentForm(IAppointmentForm apptForm)
		{
			if (apptForm.Id > 0)
			{
				var current = _context.AppointmentForms.FirstOrDefault(af => af.Id == apptForm.Id);

				current = apptForm as AppointmentForm;
			}
			else
			{
				_context.AppointmentForms.Add((AppointmentForm)apptForm);
			}
		}

		/// <summary>
		/// The delete.
		/// </summary>
		/// <param name="entity">
		/// The entity.
		/// </param>
		public void Delete(Appointment entity)
		{
			var item = _context.Appointments.FirstOrDefault(a => a.Id == entity.Id);
			if (item == null)
			{
				return;
			}

			item.IsActive = false;
			item.Status = (int)EntityStatusType.Deleted;
			item.UpdatedBy = entity.UpdatedBy ?? Thread.CurrentPrincipal.Identity.Name;
			item.UpdatedOn = DateTime.UtcNow;
		}

		/// <summary>
		/// The get all visits in step.
		/// </summary>
		/// <param name="stepSequenceId">
		/// The step sequence id.
		/// </param>
		/// <returns>
		/// The <see cref="IEnumerable"/>.
		/// </returns>
		public IEnumerable<IVisit> GetAllVisitsInStep(int stepSequenceId)
		{
			return _context.VisitStepVisitSequences.Where(vs => vs.VisitStepId == stepSequenceId && vs.IsActive).Select(vs => vs.Visit).AsEnumerable();
		}

		/// <summary>
		/// The get appointment form.
		/// </summary>
		/// <param name="apptId">
		/// The appt id.
		/// </param>
		/// <param name="formId">
		/// The form id.
		/// </param>
		/// <returns>
		/// The <see cref="IAppointmentForm"/>.
		/// </returns>
		public IAppointmentForm GetAppointmentForm(int apptId, int formId)
		{
			return _context.AppointmentForms.FirstOrDefault(af => af.AppointmentId == apptId && af.FormId == formId && af.IsActive);
		}

		/// <summary>
		/// The get appointment form.
		/// </summary>
		/// <param name="apptFormId">
		/// The appt form id.
		/// </param>
		/// <returns>
		/// The <see cref="IAppointmentForm"/>.
		/// </returns>
		public IAppointmentForm GetAppointmentForm(int apptFormId)
		{
			return _context.AppointmentForms.FirstOrDefault(af => af.Id == apptFormId);
		}

		/// <summary>
		/// The get appointment status.
		/// </summary>
		/// <param name="appointmentId">
		/// The appointment id.
		/// </param>
		/// <returns>
		/// The <see cref="AppointmentStatusType"/>.
		/// </returns>
		public AppointmentStatusType GetAppointmentStatus(int appointmentId)
		{
			var appt = _context.Appointments.FirstOrDefault(a => a.Id == appointmentId);
			return (AppointmentStatusType)appt.Status;
		}

		/// <summary>
		/// The get by id.
		/// </summary>
		/// <param name="id">
		/// The id.
		/// </param>
		/// <returns>
		/// The <see cref="Appointment"/>.
		/// </returns>
		public Appointment GetById(object id)
		{
			return _context.Appointments.FirstOrDefault(a => a.Id == (int)id);
		}

		/// <summary>
		/// The get subject visits.
		/// </summary>
		/// <param name="subjectId">
		/// The subject id.
		/// </param>
		/// <returns>
		/// The <see cref="IEnumerable"/>.
		/// </returns>
		public IEnumerable<IAppointment> GetSubjectVisits(int subjectId)
		{
			return _context.Appointments.Where(a => a.SubjectId == subjectId).AsEnumerable();
		}

		/// <summary>
		/// The insert.
		/// </summary>
		/// <param name="entity">
		/// The entity.
		/// </param>
		public void Insert(Appointment entity)
		{
			entity.CreatedBy = entity.CreatedBy ?? Thread.CurrentPrincipal.Identity.Name;
			entity.CreatedOn = DateTime.UtcNow;
			entity.IsActive = true;
			entity.Status = (int)EntityStatusType.Current;
			_context.Appointments.Add(entity);
		}

		/// <summary>
		/// The site appointments by dates.
		/// </summary>
		/// <param name="siteId">
		/// The site id.
		/// </param>
		/// <param name="start">
		/// The start.
		/// </param>
		/// <param name="end">
		/// The end.
		/// </param>
		/// <returns>
		/// The <see cref="IEnumerable"/>.
		/// </returns>
		public IEnumerable<IAppointment> SiteAppointmentsByDates(int siteId, DateTime start, DateTime end)
		{
			var startUtc = start.Kind == DateTimeKind.Utc ? start : start.ToUniversalTime();
			var endUtc = end.Kind == DateTimeKind.Utc ? end : end.ToUniversalTime();
			_context.AutoDetectChangesEnabled = false;
			var appts = _context.Appointments.Where(a => a.IsActive && a.StartDate >= startUtc && a.EndDate < endUtc && a.SiteId == siteId).AsEnumerable();
			_context.AutoDetectChangesEnabled = true;
			return appts;
		}

		/// <summary>
		/// The site appointments by dates.
		/// </summary>
		/// <param name="start">
		/// The start.
		/// </param>
		/// <param name="end">
		/// The end.
		/// </param>
		/// <returns>
		/// The <see cref="IEnumerable"/>.
		/// </returns>
		public IEnumerable<IAppointment> SiteAppointmentsByDates(DateTime start, DateTime end)
		{
			_context.AutoDetectChangesEnabled = false;
			var startUtc = start.Kind == DateTimeKind.Utc ? start : start.ToUniversalTime();
			var endUtc = end.Kind == DateTimeKind.Utc ? end : end.ToUniversalTime();

			var appts = _context.Appointments.Where(a => a.StartDate >= startUtc && a.EndDate < endUtc && a.IsActive).AsEnumerable();
			_context.AutoDetectChangesEnabled = true;

			return appts;
		}

	    public IEnumerable<IAppointment> SiteAppointmentsByDates(DateTime start, DateTime end, int siteId)
	    {
            _context.AutoDetectChangesEnabled = false;
            var startUtc = start.Kind == DateTimeKind.Utc ? start : start.ToUniversalTime();
            var endUtc = end.Kind == DateTimeKind.Utc ? end : end.ToUniversalTime();

	        var appts =
	            _context.Appointments.Where(
	                a => a.StartDate >= startUtc && a.EndDate < endUtc && a.IsActive && a.SiteId == siteId).AsEnumerable();
            _context.AutoDetectChangesEnabled = true;

            return appts;
	    }

	    /// <summary>
		/// The update.
		/// </summary>
		/// <param name="entity">
		/// The entity.
		/// </param>
		public void Update(Appointment entity)
		{
			var appt = _context.Appointments.FirstOrDefault(a => a.Id == entity.Id);
			if (appt != null)
			{
				appt.StartDate = entity.StartDate;
				appt.StartTime = entity.StartTime;
				appt.EndDate = entity.EndDate;
				appt.EndTime = entity.EndTime;
				appt.IsActive = entity.IsActive;
				appt.Status = entity.Status;
				appt.UpdatedBy = entity.UpdatedBy ?? Thread.CurrentPrincipal.Identity.Name;
				appt.UpdatedOn = DateTime.UtcNow;
				appt.SubjectId = entity.SubjectId;
				appt.AppUserId = entity.AppUserId;
				appt.VisitId = entity.VisitId;
			}
		}

		#endregion
	}
}