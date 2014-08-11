// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FormAnswer.cs" company="">
//   
// </copyright>
// <summary>
//   The FormAnswer interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The FormAnswer interface.
    /// </summary>
    public interface IFormAnswer
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the answer id.
        /// </summary>
        int AnswerId { get; set; }

        /// <summary>
        /// Gets or sets the appointment form.
        /// </summary>
        AppointmentForm AppointmentForm { get; set; }

        /// <summary>
        /// Gets or sets the appointment form id.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        int AppointmentFormId { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the free text answer.
        /// </summary>
        string FreeTextAnswer { get; set; }

        /// <summary>
        ///   Gets or sets the entity identifier
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        string Notes { get; set; }

        /// <summary>
        /// Gets or sets the question id.
        /// </summary>
        int QuestionId { get; set; }

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
    /// The form answer.
    /// </summary>
    public partial class FormAnswer : BaseEntity, IFormAnswer
    {
    }
}