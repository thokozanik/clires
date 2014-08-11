// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LibraryForm.cs" company="">
//   
// </copyright>
// <summary>
//   The LibraryForm interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The LibraryForm interface.
    /// </summary>
    public interface ILibraryForm
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
        /// Gets or sets the description.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the directions.
        /// </summary>
        string Directions { get; set; }

        /// <summary>
        /// Gets or sets the form type id.
        /// </summary>
        int FormTypeId { get; set; }

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
        /// Gets or sets the is double checked.
        /// </summary>
        bool? IsDoubleChecked { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is filled by subject.
        /// </summary>
        bool IsFilledBySubject { get; set; }

        /// <summary>
        /// Gets or sets the layout type id.
        /// </summary>
        int LayoutTypeId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether show total score.
        /// </summary>
        bool ShowTotalScore { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        int Status { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        string Title { get; set; }

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
    /// The library form.
    /// </summary>
    public partial class LibraryForm : BaseEntity, ILibraryForm
    {
    }
}