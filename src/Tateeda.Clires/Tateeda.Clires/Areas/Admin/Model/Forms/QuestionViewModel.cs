namespace Tateeda.Clires.Areas.Admin.Model.Forms
{
	using Tateeda.Clires.Core.Data.EF;

	using global::System;
	using global::System.Collections.Generic;
	using global::System.ComponentModel;
	using global::System.ComponentModel.DataAnnotations;
	using global::System.Web.Mvc;

	public interface IQuestionViewModel
	{
		string FieldDataTypeName { get; set; }
		string Required { get; }
		ICollection<AnswerViewModel> AnswersViewModel { get; set; }
		Question ParentQuestion { get; set; }
		int AnswersCount { get; set; }
		IEnumerable<string> ChildQuestions { get; set; }
	}

	public class QuestionViewModel : IQuestion, IQuestionViewModel
	{
		[Required]
		public int FormId { get; set; }
		public int FieldDataTypeId { get; set; }
		public string FieldDataTypeName { get; set; }
		[DisplayName("Question")]
		[Required]
		[AllowHtml]
		public string QuestionText { get; set; }
		public string Code { get; set; }
		[AllowHtml]
		public string Directions { get; set; }
		[AllowHtml]
		public string Header { get; set; }
		[AllowHtml]
		public string Trailer { get; set; }
		public bool IsRequired { get; set; }
		public int? ParentQuestionId { get; set; }
		public bool IsParent { get; set; }

		public string Required { get { return this.IsRequired ? "required" : ""; } }
        public string ValidationRule { get; set; }
		public string Description { get; set; }
		public int SortOrder { get; set; }
		public int Status { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime? UpdatedOn { get; set; }
		public string CreatedBy { get; set; }
		public string UpdatedBy { get; set; }
		public bool IsActive { get; set; }
		public ICollection<Answer> Answers { get; set; }
		public ICollection<AnswerChildQuestion> AnswerChildQuestions { get; set; }
		public ICollection<AnswerViewModel> AnswersViewModel { get; set; }
		public Form Form { get; set; }
		public Question ParentQuestion { get; set; }
		public CssType CssType { get; set; }
		public int Id { get; set; }
		public int AnswersCount { get; set; }
		public IEnumerable<string> ChildQuestions { get; set; }
	}
}