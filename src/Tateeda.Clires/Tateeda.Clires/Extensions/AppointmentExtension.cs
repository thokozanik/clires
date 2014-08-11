namespace Tateeda.Clires.Extensions
{
	using Core.Data.EF;

	using Tateeda.Clires.Areas.Schedule.Model;

	using global::System;

	public static class AppointmentExtension
	{
		public static AppointmentViewModel ToModel(this IAppointment appt)
		{
			if (appt.StartTime != null)
			{
				return new AppointmentViewModel
					{
						Id = appt.Id,
						ArmId = appt.Visit.ArmId,
						VisitId = appt.VisitId,
						AppUserId = appt.AppUserId,
						SubjectId = appt.SubjectId,
						Title = appt.Title,
						StartDate = appt.StartDate,
						EndDate = appt.EndDate,
						StartTime = appt.StartTime,
						CalendarStart = string.Format("{0} UTC", appt.StartDate.Add(appt.StartTime.Value)),
						CalendarEnd = string.Format("{0} UTC", appt.EndDate.Add(appt.EndTime.Value)),
						Description = appt.Description,
						VisitName = appt.Visit.Name,
						Status = appt.Status,
						VisitStepId = appt.VisitStepId,
						AllFormsCount = appt.Visit.VisitForms.Count,
						CalendarEndDate = appt.EndDate.ToShortDateString(),
						CalendarEndTime = appt.EndTime.ToString(),
						CalendarStartDate = appt.StartDate.ToShortDateString(),
						CalendarStartTime = appt.StartTime.ToString()
					};
			}
			return new AppointmentViewModel();
		}

		public static Appointment ToEntity(this AppointmentViewModel model)
		{
			return new Appointment
				{
					Id = model.Id,
					IsActive = model.IsActive,
					AppUserId = model.AppUserId,
					CreatedBy = model.CreatedBy,
					CreatedOn = model.CreatedOn,
					Description = model.Description,
					VisitStepId = model.VisitStepId,
					EndDate = model.EndDate,
					EndTime = model.EndTime ?? TimeSpan.Parse(model.CalendarEndTime),
					SiteId = model.SiteId,
					StartDate = model.StartDate,
					StartTime = model.StartTime ?? TimeSpan.Parse(model.CalendarStartTime),
					Status = model.Status,
					SubjectId = model.SubjectId,
					Title = model.Title,
					VisitId = model.VisitId,
					UpdatedBy = model.UpdatedBy,
					UpdatedOn = model.UpdatedOn
				};
		}

	}
}