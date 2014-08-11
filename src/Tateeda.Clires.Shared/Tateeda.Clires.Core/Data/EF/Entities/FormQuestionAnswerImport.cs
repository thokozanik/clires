namespace Tateeda.Clires.Core.Data.EF
{
	public interface IFormQuestionAnswerImport
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		int FormId { get; set; }

		string FormName { get; set; }

		string title { get; set; }

		string Description { get; set; }

		int FormType { get; set; }

		int QuestionId { get; set; }

		string QuestionText { get; set; }

		int QuestionTypeId { get; set; }

		int AnswerId { get; set; }

		string AnswerText { get; set; }

		/// <summary>
		///   Gets or sets the entity identifier
		/// </summary>
		int Id { get; set; }
	}

	public partial class FormQuestionAnswerImport : BaseEntity, IFormQuestionAnswerImport
	{
	}
}
