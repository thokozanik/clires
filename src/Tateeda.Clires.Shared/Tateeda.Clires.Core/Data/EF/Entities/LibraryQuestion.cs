// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LibraryQuestion.cs" company="">
//   
// </copyright>
// <summary>
//   The LibraryQuestion interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The LibraryQuestion interface.
    /// </summary>
    public interface ILibraryQuestion
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
        /// Gets or sets the css type.
        /// </summary>
        CssType CssType { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the directions.
        /// </summary>
        string Directions { get; set; }

        /// <summary>
        /// Gets or sets the field data type id.
        /// </summary>
        int FieldDataTypeId { get; set; }

        /// <summary>
        /// Gets or sets the form.
        /// </summary>
        Form Form { get; set; }

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
        /// Gets or sets a value indicating whether is parent.
        /// </summary>
        bool IsParent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is required.
        /// </summary>
        bool IsRequired { get; set; }

        /// <summary>
        /// Gets or sets the library form id.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        int LibraryFormId { get; set; }

        /// <summary>
        /// Gets or sets the parent question id.
        /// </summary>
        int? ParentQuestionId { get; set; }

        /// <summary>
        /// Gets or sets the question text.
        /// </summary>
        string QuestionText { get; set; }

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
    /// The library question.
    /// </summary>
    public partial class LibraryQuestion : BaseEntity, ILibraryQuestion
    {
    }
}