// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnswerChildQuestion.cs" company="">
//   
// </copyright>
// <summary>
//   The AnswerChildQuestion interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The AnswerChildQuestion interface.
    /// </summary>
    public interface IAnswerChildQuestion
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the answer.
        /// </summary>
        Answer Answer { get; set; }

        /// <summary>
        /// Gets or sets the answer id.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        int AnswerId { get; set; }

        /// <summary>
        ///   Gets or sets the entity identifier
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        bool? IsActive { get; set; }

        /// <summary>
        /// Gets or sets the question.
        /// </summary>
        Question Question { get; set; }

        /// <summary>
        /// Gets or sets the question id.
        /// </summary>
        int QuestionId { get; set; }

        #endregion
    }

    /// <summary>
    /// The answer child question.
    /// </summary>
    public partial class AnswerChildQuestion : BaseEntity, IAnswerChildQuestion
    {
    }
}