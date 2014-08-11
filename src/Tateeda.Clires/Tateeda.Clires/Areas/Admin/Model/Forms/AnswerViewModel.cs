namespace Tateeda.Clires.Areas.Admin.Model.Forms
{
    using Tateeda.Clires.Core.Data.EF;

    using global::System;
    using global::System.Collections.Generic;
    using global::System.ComponentModel.DataAnnotations;
    using global::System.Web.Mvc;

    public interface IAnswerViewModel
    {
        int FieldDataTypeId { get; set; }
        string FieldDataTypeName { get; set; }
        string CssClass { get; set; }
        string CssInputType { get; set; }
        IEnumerable<int> ChildQuestionIds { get; set; }
        IEnumerable<QuestionViewModel> ChildQuestions { get; set; }
        string AnswerText { get; set; }
        bool Selected { get; set; }
        int FormAnswerId { get; set; }
    }

    public class AnswerViewModel : IAnswer, IAnswerViewModel
    {
        [Required]
        public int QuestionId { get; set; }

        [AllowHtml]
        [Required]
        public string OptionText { get; set; }

        public string Code { get; set; }

        public int? Score { get; set; }

        [AllowHtml]
        public string Header { get; set; }

        [AllowHtml]
        public string Trailer { get; set; }

        [AllowHtml]
        public string Directions { get; set; }

        public int SortOrder { get; set; }

        public int Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public bool IsActive { get; set; }

        public Question Question { get; set; }

        public ICollection<AnswerChildQuestion> AnswerChildQuestions { get; set; }

        public IEnumerable<int> AnswerChildQuestionsIds { get; set; }

        public int Id { get; set; }

        public int FieldDataTypeId { get; set; }

        public string FieldDataTypeName { get; set; }

        public string CssClass { get; set; }

        public string CssInputType { get; set; }

        public IEnumerable<int> ChildQuestionIds { get; set; }

        public IEnumerable<QuestionViewModel> ChildQuestions { get; set; }

        public string AnswerText { get; set; }
        public bool Selected { get; set; }
        public int FormAnswerId { get; set; }

        public int SelectedId { get; set; }
    }
}