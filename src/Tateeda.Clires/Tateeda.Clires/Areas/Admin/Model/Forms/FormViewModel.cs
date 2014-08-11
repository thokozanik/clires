namespace Tateeda.Clires.Areas.Admin.Model.Forms
{
	using Tateeda.Clires.Core.Data.Enums;
	using Tateeda.Clires.Core.Data.EF;

	using global::System;
	using global::System.Collections.Generic;
	using global::System.ComponentModel.DataAnnotations;
	using global::System.Web.Mvc;

	public interface IFormViewModel
	{
		ApptFormStatusType ApptFormStatus { get; set; }
		string FormTypeName { get; set; }
		string LayoutTypeName { get; set; }
		ICollection<QuestionViewModel> QuestionsViewModel { get; set; }
		string StudyName { get; set; }
		int QuestionCount { get; set; }
		int VisitId { get; set; }
		bool IsLocked { get; set; }
	}

	public class FormViewModel : IForm, IFormViewModel
	{
		public int StudyId { get; set; }

		[AllowHtml]
		[Required]
		public string Name { get; set; }
		public string Code { get; set; }
		public int FormTypeId { get; set; }
		public ApptFormStatusType ApptFormStatus { get; set; }
		public string FormTypeName { get; set; }
		public string LayoutTypeName { get; set; }
		public ICollection<QuestionViewModel> QuestionsViewModel { get; set; }
		public string StudyName { get; set; }
		public int QuestionCount { get; set; }
		public int VisitId { get; set; }
		public bool IsLocked { get; set; }
		public string Title { get; set; }
		[AllowHtml]
		public string Directions { get; set; }
		[AllowHtml]
		public string Header { get; set; }
		[AllowHtml]
		public string Trailer { get; set; }

		public bool IsFilledBySubject { get; set; }
		public bool ShowTotalScore { get; set; }
		public int LayoutTypeId { get; set; }
		public bool? IsDoubleChecked { get; set; }
		public string Description { get; set; }
		public int SortOrder { get; set; }
		public int Status { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime? UpdatedOn { get; set; }
		public string CreatedBy { get; set; }
		public string UpdatedBy { get; set; }
		public bool IsActive { get; set; }
		public bool NotifyOnChange { get; set; }
		public bool NotifyOnCompletion { get; set; }
		public ICollection<AppointmentForm> AppointmentForms { get; set; }
		public Study Study { get; set; }
		public ICollection<FormVerification> FormVerifications { get; set; }
		public ICollection<FormVisibilityByVisitForSubject> FormVisibilityByVisitForSubjects { get; set; }
		public ICollection<VisitForm> VisitForms { get; set; }
		public ICollection<Question> Questions { get; set; }
		public ICollection<LibraryQuestion> LibraryQuestions { get; set; }
		public int Id { get; set; }
	}
}