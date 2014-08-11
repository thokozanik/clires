namespace Tateeda.Clires.Core.Report
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Data.EF;
	using Data.Enums;

	public class ReportRepository : IReportRepository
	{
		private readonly IDbContext _context;

		public ReportRepository(IDbContext context)
		{
			_context = context;
		}

		public int GetTotalSubjectsCount(bool? active)
		{
			if (active == null)
			{
				return _context.Subjects.Count();
			}

			return active.Value ?
					_context.Subjects.Count(s => s.IsActive || s.Status == (int)EntityStatusType.Current) :
					_context.Subjects.Count(s => s.IsActive == false || s.Status != (int)EntityStatusType.Current);
		}

		public int GetTotalSubjectsPerStydy(int studyId)
		{
			return _context.Subjects.Count(s => s.StudyId == studyId);
		}

		public Dictionary<string, int> GetTotalSubjectsPerStudyForAllSites(int studyId)
		{
			var result = new Dictionary<string, int>();
			var sites = _context.Sites.ToList();
			foreach (var site in sites)
			{
				int subjectsCount = _context.Subjects.Count(s => s.SiteId == site.Id);
				result.Add(string.Format("{0}: {1}", site.Id, site.Name), subjectsCount);
			}

			return result;
		}

		public Dictionary<string, int> GetTotalActiveSubjectsPerStudyForAllSites(int studyId)
		{
			var result = new Dictionary<string, int>();
			var sites = _context.Sites.ToList();
			foreach (var site in sites)
			{
				int subjectsCount = _context.Subjects.Count(s => s.SiteId == site.Id && (s.IsActive || s.Status == (int)EntityStatusType.Current));
				result.Add(string.Format("{0}: {1}", site.Id, site.Name), subjectsCount);
			}

			return result;
		}

		public Dictionary<string, int> GetTotalCompletedAppointmentsPerStudy(int studyId)
		{
			var result = new Dictionary<string, int>();
			var sites = _context.Sites.ToList();
			foreach (var site in sites)
			{
				int apptCount = _context.Appointments.Count(a => a.SiteId == site.Id && a.Status == (int)AppointmentStatusType.Completed && a.Visit.Arm.StudyId == studyId);
				result.Add(string.Format("{0}: {1}", site.Id, site.Name), apptCount);
			}
			return result;
		}

		public Dictionary<string, int> GetTotalInProgressAppointmentsPerStudy(int studyId)
		{
			var result = new Dictionary<string, int>();
			var sites = _context.Sites.ToList();
			foreach (var site in sites)
			{
				int apptCount = _context.Appointments.Count(a => a.SiteId == site.Id && a.Status == (int)AppointmentStatusType.InProgress && a.Visit.Arm.StudyId == studyId);
				result.Add(string.Format("{0}: {1}", site.Id, site.Name), apptCount);
			}
			return result;
		}

		public Dictionary<string, int> GetTotalScheduledAppointmentsPerStudy(int studyId)
		{
			var result = new Dictionary<string, int>();
			var sites = _context.Sites.ToList();
			foreach (var site in sites)
			{
				int apptCount = _context.Appointments.Count(a => a.SiteId == site.Id && a.Status == (int)AppointmentStatusType.Scheduled && a.Visit.Arm.StudyId == studyId);
				result.Add(string.Format("{0}: {1}", site.Id, site.Name), apptCount);
			}
			return result;
		}

		public Dictionary<string, int> GetTotalCompletedFormsPerStudy(int studyId)
		{
			var result = new Dictionary<string, int>();
			var sites = _context.Sites.ToList();
			foreach (var site in sites)
			{
				int formsCount =
					_context.AppointmentForms.Count(
						af => af.FormStatusTypeId == (int)ApptFormStatusType.Completed && af.Appointment.SiteId == site.Id);
				result.Add(string.Format("{0}: {1}", site.Id, site.Name), formsCount);
			}
			return result;
		}

		public Dictionary<string, int> GetTotalInProgressFormsPerStudy(int studyId)
		{
			var result = new Dictionary<string, int>();
			var sites = _context.Sites.ToList();
			foreach (var site in sites)
			{
				int formsCount =
					_context.AppointmentForms.Count(
						af => af.FormStatusTypeId == (int)ApptFormStatusType.InProgress && af.Appointment.SiteId == site.Id);
				result.Add(string.Format("{0}: {1}", site.Id, site.Name), formsCount);
			}
			return result;
		}
	}
}
