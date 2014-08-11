// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FormVerification.cs" company="">
//   
// </copyright>
// <summary>
//   The FormVerification interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The FormVerification interface.
    /// </summary>
    public interface IFormVerification
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
        /// Gets or sets the form.
        /// </summary>
        Form Form { get; set; }

        /// <summary>
        /// Gets or sets the form id.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        int FormId { get; set; }

        /// <summary>
        ///   Gets or sets the entity identifier
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets the result status.
        /// </summary>
        int? ResultStatus { get; set; }

        /// <summary>
        /// Gets or sets the verified by.
        /// </summary>
        string VerifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the verified on.
        /// </summary>
        DateTime? VerifiedOn { get; set; }

        #endregion
    }

    /// <summary>
    /// The form verification.
    /// </summary>
    public partial class FormVerification : BaseEntity, IFormVerification
    {
    }
}