namespace Tateeda.Clires.Areas.Schedule.Model
{
	using Tateeda.Clires.Core.Data.EF;

	using global::System;
	using global::System.Collections.Generic;
	using global::System.ComponentModel.DataAnnotations;

	public interface IAppointmentViewModel
	{
		bool IsTermination { get; set; }
		bool ScheduleAll { get; set; }
		string SubjectFullName { get; set; }
		string AppUserFullName { get; set; }
		string VisitName { get; set; }
		string CalendarStart { get; set; }
		string CalendarEnd { get; set; }
		int ArmId { get; set; }
		int StepSequenceId { get; set; }
		int AllFormsCount { get; set; }

		bool CanRepeat { get; set; }
	}

	public class AppointmentViewModel : IAppointment, IAppointmentViewModel
	{
		public bool CanRepeat { get; set; }

		public bool IsTermination { get; set; }

		public bool ScheduleAll { get; set; }
		[Required]
		public int SubjectId { get; set; }
		[Required]
		public int VisitId { get; set; }

		public int SiteId { get; set; }
		[Required]
		public int AppUserId { get; set; }

		public string Title { get; set; }

		public string Location { get; set; }

		public string Description { get; set; }
		[Required]
		public DateTime StartDate { get; set; }
		[Required]
		public TimeSpan? StartTime { get; set; }
		[Required]
		public DateTime EndDate { get; set; }
		[Required]
		public TimeSpan? EndTime { get; set; }

		public string CalendarStartDate { get; set; }
		public string CalendarStartTime { get; set; }
		public string CalendarEndDate { get; set; }
		public string CalendarEndTime { get; set; }

		public int VisitStepId { get; set; }

		public int Status { get; set; }

		public string CreatedBy { get; set; }

		public DateTime CreatedOn { get; set; }

		public DateTime? UpdatedOn { get; set; }

		public string UpdatedBy { get; set; }

		public bool IsActive { get; set; }

		public Visit Visit { get; set; }

		public ICollection<AppointmentForm> AppointmentForms { get; set; }

		public ICollection<RecreationalDrugOrSubstance> RecreationalDrugOrSubstances { get; set; }

		/// <summary>
		///   Gets or sets the entity identifier
		/// </summary>
		public int Id { get; set; }

		public string SubjectFullName { get; set; }

		public string AppUserFullName { get; set; }

		public string VisitName { get; set; }

		public string CalendarStart { get; set; }

		public string CalendarEnd { get; set; }

		public int ArmId { get; set; }

		public int StepSequenceId { get; set; }

		public int AllFormsCount { get; set; }
	}
}