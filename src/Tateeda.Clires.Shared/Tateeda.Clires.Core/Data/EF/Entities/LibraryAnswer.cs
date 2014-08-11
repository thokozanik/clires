// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LibraryAnswer.cs" company="">
//   
// </copyright>
// <summary>
//   The LibraryAnswer interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The LibraryAnswer interface.
    /// </summary>
    public interface ILibraryAnswer
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        string Code { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the directions.
        /// </summary>
        string Directions { get; set; }

        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        string Header { get; set; }

        /// <summary>
        ///   Gets or sets the entity identifier
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is active.
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the option text.
        /// </summary>
        string OptionText { get; set; }

        /// <summary>
        /// Gets or sets the question.
        /// </summary>
        Question Question { get; set; }

        /// <summary>
        /// Gets or sets the question id.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        int QuestionId { get; set; }

        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        int? Score { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        int Status { get; set; }

        /// <summary>
        /// Gets or sets the trailer.
        /// </summary>
        string Trailer { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated on.
        /// </summary>
        DateTime? UpdatedOn { get; set; }

        #endregion
    }

    /// <summary>
    /// The library answer.
    /// </summary>
    public partial class LibraryAnswer : BaseEntity, ILibraryAnswer
    {
    }
}