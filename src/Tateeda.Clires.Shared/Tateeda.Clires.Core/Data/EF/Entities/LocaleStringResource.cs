// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocaleStringResource.cs" company="">
//   
// </copyright>
// <summary>
//   The LocaleStringResource interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The LocaleStringResource interface.
    /// </summary>
    public interface ILocaleStringResource
    {
        #region Public Properties

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
        ///   Gets or sets the entity identifier
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is active.
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        Language Language { get; set; }

        /// <summary>
        /// Gets or sets the language id.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        int LanguageId { get; set; }

        /// <summary>
        /// Gets or sets the resource name.
        /// </summary>
        string ResourceName { get; set; }

        /// <summary>
        /// Gets or sets the resource value.
        /// </summary>
        string ResourceValue { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        int Status { get; set; }

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
    /// The locale string resource.
    /// </summary>
    public partial class LocaleStringResource : BaseEntity, ILocaleStringResource
    {
    }
}