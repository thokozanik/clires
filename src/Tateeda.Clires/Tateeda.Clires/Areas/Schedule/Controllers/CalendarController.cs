// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CalendarController.cs" company="">
//   
// </copyright>
// <summary>
//   The calendar controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Linq.Expressions;
using System.Transactions;

namespace Tateeda.Clires.Areas.Schedule.Controllers
{
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Globalization;
    using global::System.Linq;
    using global::System.Threading;
    using global::System.Web.Mvc;
    using NLog;
    using Tateeda.Clires.Areas.Schedule.Model;
    using Tateeda.Clires.Core.Data.EF;
    using Tateeda.Clires.Core.Data.Enums;
    using Tateeda.Clires.Data.UOW;
    using Tateeda.Clires.Extensions;
    using Tateeda.Clires.System;

	/// <summary>
	/// The calendar controller.
	/// </summary>
	[Authorize(Roles = GlobalVariables.RoleSiteAdminAndAppUser)]
	public class CalendarController : BaseController
	{
		#region Public Methods and Operators

		/// <summary>
		/// The index.
		/// </summary>
		/// <returns>
		/// The <see cref="ActionResult"/>.
		/// </returns>
		public ActionResult Index()
		{
			@ViewBag.StudyId = GlobalVariables.CurrentStudyId;
			@ViewBag.SiteId = CurrentAppUser.SiteId;
			return View();
		}

	    /// <summary>
	    /// The move appointment.
	    /// </summary>
	    /// <param name="start">
	    /// The start.
	    /// </param>
	    /// <param name="end">
	    /// The end.
	    /// </param>
	    /// <param name="appointmentId">
	    /// The appointment id.
	    /// </param>
	    /// <param name="subjectId">
	    /// The subject id.
	    /// </param>
	    /// <param name="visitId">
	    /// The visit id.
	    /// </param>
	    /// <returns>
	    /// The <see cref="JsonResult"/>.
	    /// </returns>
	    public ActionResult MoveAppointment(DateTime start, DateTime end, int appointmentId, int subjectId, int visitId)
	    {
	        try {
	            using (var scope = new TransactionScope())
	            using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>()) {
	                var appt = adminUow.AppointmentRepository.GetById(appointmentId);
	                var model = new AppointmentViewModel {
	                    Id = appt.Id,
	                    VisitStepId = appt.VisitStepId,
	                    StartDate = start.Date,
	                    StartTime = start.TimeOfDay,
	                    EndDate = end.Date,
	                    EndTime = end.TimeOfDay,
	                    SubjectId = subjectId,
	                    VisitId = visitId
	                };

	                var stepVisits = adminUow.StudyRepository.GetStepVisits(model.VisitStepId).ToList();
	                var visitToSchedule = stepVisits.FirstOrDefault(v => v.VisitId == model.VisitId);
	                var subjectVisits = adminUow.AppointmentRepository.GetSubjectVisits(model.SubjectId).ToList();
	                var baseVisit = GetBaseOrFirstVisit(subjectVisits);
	                var baseVisitDate = baseVisit.StartDate.Add(baseVisit.StartTime.Value);
	                var canMove = VerifyAppointmentDates(model, visitToSchedule, baseVisitDate);
	                if (canMove) {
	                    UpdateAppointment(model);
	                }

	                adminUow.Commit();
	                scope.Complete();

	                return Json(canMove);
	            }
	        }
	        catch (Exception ex) {
	            _logger.LogException(LogLevel.Error, "Error moving appointments.", ex);
	            Response.StatusCode = 500;
	            return new ContentResult {Content = "Error moving appointment."};
	        }
	    }

	    /// <summary>
		/// The new appointment.
		/// </summary>
		/// <param name="model">
		/// The model.
		/// </param>
		/// <returns>
		/// The <see cref="JsonResult"/>.
		/// </returns>
		public JsonResult NewAppointment(AppointmentViewModel model)
		{
			try
			{
				ModelState.Remove("Id");
				TryValidateModel(model);

				if (!ModelState.IsValid)
				{
					return Json("Missing required fields", JsonRequestBehavior.DenyGet);
				}

			    using (var scope = new TransactionScope()) {
			        if (model.Id > 0) {
			            return EditAppointment(model);
			        }

			        using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>()) {
			            model.SiteId = adminUow.SubjectRepository.GetById(model.SubjectId).SiteId;

			            if (model.ScheduleAll) {
			                var visits = ScheduleAllInSequence(model, adminUow);
			                adminUow.Commit();
			                return visits;
			            }
			            var viewModel = CreateAppointment(model, adminUow);
			            adminUow.Commit();
                        scope.Complete();

			            return Json(viewModel, JsonRequestBehavior.DenyGet);
			        }                    
			    }
			}
			catch (Exception ex)
			{
				return Json(ex.Message, JsonRequestBehavior.DenyGet);
			}
		}

		private JsonResult EditAppointment(AppointmentViewModel model)
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var appt = adminUow.AppointmentRepository.GetById(model.Id);
				var stepVisits = adminUow.StudyRepository.GetStepVisits(appt.VisitStepId).ToList();
				var visitToSchedule = stepVisits.FirstOrDefault(v => v.VisitId == appt.VisitId);
				var subjectVisits = adminUow.AppointmentRepository.GetSubjectVisits(appt.SubjectId).ToList();
				var baseVisit = GetBaseOrFirstVisit(subjectVisits);
				var baseVisitDate = baseVisit.StartDate.Add(baseVisit.StartTime.Value);
				var canMove = VerifyAppointmentDates(model, visitToSchedule, baseVisitDate);
				if (canMove)
				{
					UpdateAppointment(model);
					adminUow.Commit();
				}

				return Json(canMove, JsonRequestBehavior.AllowGet);
			}
		}

		public JsonResult DeleteAppointment(int id)
		{
			try
			{
                using(var scope = new TransactionScope())
				using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
				{
					var appt = adminUow.AppointmentRepository.GetById(id);
					adminUow.AppointmentRepository.Delete(appt);
					adminUow.Commit();
                    scope.Complete();

					return Json("success", JsonRequestBehavior.AllowGet);
				}
			}
			catch (Exception ex)
			{
				_logger.LogException(LogLevel.Error, "Can't delete appointment", ex);
				return Json("error");
			}
		}

		public JsonResult GetAppointementInfo(int id)
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var appt = adminUow.AppointmentRepository.GetById(id).ToModel();
				return Json(appt, JsonRequestBehavior.AllowGet);
			}
		}

		public JsonResult GetEmptyAppointment()
		{
			return Json(
				new AppointmentViewModel
					{
						Title = "New Appointment"
					},
				JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetSubjectAppointements(int subjectId)
		{
			var allSubjectAppts = new List<AppointmentViewModel>();
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var appts = adminUow.SubjectRepository.GetAllSubjectAppointements(subjectId);
				foreach (var appt in appts)
				{
					allSubjectAppts.Add(new AppointmentViewModel
						{
							VisitId = appt.VisitId,
							VisitName = appt.Visit.Name,
							StartDate = appt.StartDate,
							EndDate = appt.EndDate,
							CalendarStart = appt.StartDate.ToString(),
							CalendarEnd = appt.EndDate.ToString(),
							CanRepeat = appt.Visit.CanRepeat
						});
				}

				return Json(allSubjectAppts, JsonRequestBehavior.AllowGet);
			}
		}
		#endregion

		#region Methods

		/// <summary>
		/// The verify appointment dates.
		/// </summary>
		/// <param name="model">
		/// The model.
		/// </param>
		/// <param name="visitToSchedule">
		/// The visit to schedule.
		/// </param>
		/// <param name="baseVisitDate">
		/// The base visit date.
		/// </param>
		/// <returns>
		/// The <see cref="bool"/>.
		/// </returns>
		/// <exception cref="Exception">
		/// </exception>
		private static bool VerifyAppointmentDates(AppointmentViewModel model, IVisitStepVisitSequence visitToSchedule, DateTime baseVisitDate)
		{
			var apptStartUtc = model.StartDate.Add(model.StartTime.Value).ToUniversalTime();
			var apptEndUtc = model.EndDate.Add(model.EndTime.Value).ToUniversalTime();
			_logger.Debug("Visit to schedule is {0} days from baseline visit", visitToSchedule.DaysFromBase);

			var minDate = baseVisitDate.AddDays(visitToSchedule.DaysFromBase - visitToSchedule.Deviation);
			var maxDate = baseVisitDate.AddDays(visitToSchedule.DaysFromBase + visitToSchedule.Deviation);
			_logger.Debug("Min Date: {0}, Max Date: {1}. Current visit for :{2} - {3}", minDate, maxDate, apptStartUtc, apptEndUtc);

			if (apptStartUtc >= minDate && apptEndUtc <= maxDate)
			{
				return true;
			}

			throw new Exception(
				string.Format(
					"Visit {0} on {1} is outside deviation.  Earliest: {2}.  Latest: {3}. ",
					visitToSchedule.Visit.Name,
					model.StartDate.ToLocalTime(),
					minDate.ToLocalTime(),
					maxDate.ToLocalTime()));
		}

		/// <summary>
		/// The can create appointment.
		/// </summary>
		/// <param name="model">
		/// The model.
		/// </param>
		/// <returns>
		/// The <see cref="bool"/>.
		/// </returns>
		/// <exception cref="Exception">
		/// </exception>
		private bool CanCreateAppointment(AppointmentViewModel model)
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				// Validate if appt can be created in time frame and this is not a duplicate          
				// 1. Check if this visit is not scheduled yet for this subject (except for 0 deviation visits and 0 days from base)
				var subjectVisits = adminUow.AppointmentRepository
											.GetSubjectVisits(model.SubjectId)
											.Where(v => v.VisitStepId == model.VisitStepId)
											.ToList();

				// This is first visit
				if (subjectVisits.Count() == 0)
				{
					return true;
				}

				var sameVisit = subjectVisits.FirstOrDefault(v => v.VisitId == model.VisitId);
				if (sameVisit != null)
				{
					if (!sameVisit.Visit.CanMove && model.Id > 0)
					{
						_logger.Debug("Visit: {0} cannot move.", sameVisit.Visit.Id);
						throw new Exception("This Visit can not be modified");
					}

					if (!sameVisit.Visit.CanRepeat)
					{
						var visitDate = sameVisit.StartDate.Add(sameVisit.StartTime.HasValue ? sameVisit.StartTime.Value : new TimeSpan(0)).ToLocalTime();
						_logger.Debug("This visit {1} is scheduled on: {0} and cannot be repeated", visitDate, sameVisit.Visit.Name);

						throw new Exception(string.Format("This visit is scheduled on: {0} and cannot be repeated", visitDate));
					}
				}

				var stepVisits = adminUow.StudyRepository.GetStepVisits(model.StepSequenceId).ToList();
				var visitToSchedule = stepVisits.FirstOrDefault(v => v.VisitId == model.VisitId);
				_logger.Debug(
					"Found visit to Schedule with deviation of {0} days. Days from base: {1}. Visit name: {2}",
					visitToSchedule.Deviation,
					visitToSchedule.DaysFromBase,
					visitToSchedule.Visit.Name);

				model.IsTermination = visitToSchedule.IsTermination;

				// Deviation is 0 and can repeat then it's ok to schedule
				if (visitToSchedule.Visit.CanRepeat)
				{
					return true;
				}

				// Find Base Visit or First Visit
				var baseVisit = GetBaseOrFirstVisit(subjectVisits);
				var baseVisitDate = baseVisit.StartDate.Add(baseVisit.StartTime.Value);

				_logger.Debug("Found BASE visit on {0} - UTC. BASE Visit name: {1}", baseVisitDate, baseVisit.Visit.Name);

				if (visitToSchedule.Deviation == 0 && model.StartDate >= baseVisitDate)
				{
					return true;
				}

				if (visitToSchedule.Deviation == 0)
				{
					throw new Exception(string.Format("This visit cannot be scheduled before based visit on :{0}", baseVisitDate));
				}

				// 2. Check if this visit is under deviation brackets from base day
				return VerifyAppointmentDates(model, visitToSchedule, baseVisitDate);
			}
		}

	    /// <summary>
	    /// The create appointment.
	    /// </summary>
	    /// <param name="model">
	    /// The model.
	    /// </param>
	    /// <param name="adminUow"></param>
	    /// <returns>
	    /// The <see cref="AppointmentViewModel"/>.
	    /// </returns>
	    /// <exception cref="Exception">
	    /// </exception>
	    private AppointmentViewModel CreateAppointment(AppointmentViewModel model, IAdminUnitOfWork adminUow)
		{
			if (model.StartDate.Kind == DateTimeKind.Utc || model.EndDate.Kind == DateTimeKind.Utc)
			{
				throw new Exception("Date time is in UTC Format. Use only LOCACL time for this call");
			}

			var apptStartDateTimeUTC = model.StartDate.Add(model.StartTime.Value).ToUniversalTime();
			var apptEndDateTimeUTC = model.EndDate.Add(model.EndTime.Value).ToUniversalTime();

			var appt = model.ToEntity();
			appt.StartDate = apptStartDateTimeUTC;
			appt.EndDate = apptEndDateTimeUTC;
			appt.StartTime = new TimeSpan(apptStartDateTimeUTC.Hour, apptStartDateTimeUTC.Minute, 0);
			appt.EndTime = new TimeSpan(apptEndDateTimeUTC.Hour, apptEndDateTimeUTC.Minute, 0);
			appt.VisitStepId = model.StepSequenceId;
			appt.CreatedBy = Thread.CurrentPrincipal.Identity.Name;
			appt.IsActive = true;
			appt.Status = (int)AppointmentStatusType.Scheduled;

			if (CanCreateAppointment(model))
			{                
				// TODO: Move to Monday should be in Settings as Days to adjust for weekends.
				if (appt.StartDate.DayOfWeek == DayOfWeek.Saturday)
				{
					appt.StartDate = appt.StartDate.AddDays(2); // move to Monday.
					appt.EndDate = appt.EndDate.AddDays(2);
				}
				else if (appt.StartDate.DayOfWeek == DayOfWeek.Sunday)
				{
					appt.StartDate = model.StartDate.AddDays(1); // move to Monday.
					appt.EndDate = model.EndDate.AddDays(1);
				}

				_logger.Debug(
					"CAN Create Visit:{0} start:{1}:{3} end:{2}:{4}",
					appt.VisitId,
					appt.StartDate,
					appt.EndDate,
					appt.StartTime,
					appt.EndTime);

				adminUow.AppointmentRepository.Insert(appt);

				if (model.IsTermination)
				{
					TerminateAllFutureVisits(model);
				}
			}

			var viewModel = new AppointmentViewModel
				{
					Id = appt.Id,
					SubjectId = appt.SubjectId,
					AppUserId = appt.AppUserId,
					CalendarStart = apptStartDateTimeUTC.ToLocalTime().ToString(CultureInfo.InvariantCulture),
					CalendarEnd = apptEndDateTimeUTC.ToLocalTime().ToString(CultureInfo.InvariantCulture),
					Title = appt.Title,
					Description = appt.Description
				};


			return viewModel;
		}

		/// <summary>
		/// The get base or first visit.
		/// </summary>
		/// <param name="subjectVisits">
		/// The subject visits.
		/// </param>
		/// <returns>
		/// The <see cref="IAppointment"/>.
		/// </returns>
		private IAppointment GetBaseOrFirstVisit(IList<IAppointment> subjectVisits)
		{
			var baseVisit = subjectVisits.FirstOrDefault(v => v.IsActive && v.Visit.IsBaseVisit)
							?? subjectVisits.Where(v => v.IsActive).OrderBy(v => v.StartDate).Take(1).FirstOrDefault();
			return baseVisit;
		}

		/// <summary>
		/// The schedule all in sequence.
		/// </summary>
		/// <param name="model">
		/// The model.
		/// </param>
		/// <returns>
		/// The <see cref="JsonResult"/>.
		/// </returns>
		private JsonResult ScheduleAllInSequence(AppointmentViewModel model, IAdminUnitOfWork adminUow)
		{
			var stepVisits = adminUow.StudyRepository.GetStepVisits(model.StepSequenceId).OrderBy(v => v.SortOrder).ToList();
			int cnt = 0;
			var originalStartDate = model.StartDate;
			var originalEndDate = model.EndDate;
			var subjectVisits = adminUow.AppointmentRepository
										.GetSubjectVisits(model.SubjectId)
										.Where(v => v.VisitStepId == model.VisitStepId)
										.ToList();
			var baseVisit = GetBaseOrFirstVisit(subjectVisits);
			var title = model.Title;
			var viewModel = model;
			var delta = 0;
			var shift = 0;
			if (baseVisit != null)
			{
				delta = (originalStartDate.ToUniversalTime() - baseVisit.StartDate).Days;
			}

			foreach (var appt in stepVisits)
			{
				if (delta > 0)
				{
					shift = stepVisits.FirstOrDefault(v => v.VisitId == appt.VisitId).Deviation - delta;
				}

				//Skip visits already created for this subject.
				var existingSubjectVisit = subjectVisits.FirstOrDefault(v => v.VisitId == appt.VisitId);
				if (existingSubjectVisit == null || existingSubjectVisit.Visit.CanRepeat)
				{
					model.VisitId = appt.VisitId;
					if (cnt > 0)
					{
						model.StartDate = originalStartDate.AddDays(appt.DaysFromBase - shift);
						model.EndDate = originalEndDate.AddDays(appt.DaysFromBase - shift);
						model.Title = title + string.Format(" {0} of {1}", cnt + 1, stepVisits.Count);
						_logger.Debug(
							"Increment next appointment by {0} days for Visit [in sequence]: {1}", appt.DaysFromBase, appt.Visit.Name);
						_logger.Debug("NEXT Appointment start: {0}", model.StartDate);
					}

					CreateAppointment(model, adminUow);

					cnt++;
				}
			}

			return Json(viewModel, JsonRequestBehavior.DenyGet);
		}

		/// <summary>
		/// The terminate all future visits.
		/// </summary>
		/// <param name="model">
		/// The model.
		/// </param>
		/// <exception cref="NotImplementedException">
		/// </exception>
		private void TerminateAllFutureVisits(AppointmentViewModel model)
		{
			// Terminate here.
			throw new NotImplementedException("Implement me.....");
		}

		/// <summary>
		/// The update appointment.
		/// </summary>
		/// <param name="model">
		/// The model.
		/// </param>
		private void UpdateAppointment(AppointmentViewModel model)
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var appt = adminUow.AppointmentRepository.GetById(model.Id);
				appt.StartDate = model.StartDate;
				appt.StartTime = model.StartTime;
				appt.EndDate = model.EndDate;
				appt.EndTime = model.EndTime;
				appt.UpdatedBy = User.Identity.Name;
				appt.UpdatedOn = DateTime.UtcNow;
				adminUow.AppointmentRepository.Update(appt);
				adminUow.Commit();
			}
		}

		#endregion
	}
}