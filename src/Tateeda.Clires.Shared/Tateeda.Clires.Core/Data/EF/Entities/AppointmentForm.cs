// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppointmentForm.cs" company="">
//   
// </copyright>
// <summary>
//   The AppointmentForm interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The AppointmentForm interface.
    /// </summary>
    public interface IAppointmentForm
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the appointment.
        /// </summary>
        Appointment Appointment { get; set; }

        /// <summary>
        /// Gets or sets the appointment id.
        /// </summary>
        int AppointmentId { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        string Comments { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the form.
        /// </summary>
        Form Form { get; set; }

        /// <summary>
        /// Gets or sets the form answers.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        ICollection<FormAnswer> FormAnswers { get; set; }

        /// <summary>
        /// Gets or sets the form id.
        /// </summary>
        int FormId { get; set; }

        /// <summary>
        /// Gets or sets the form status type id.
        /// </summary>
        int FormStatusTypeId { get; set; }

        /// <summary>
        ///   Gets or sets the entity identifier
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is active.
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        string Notes { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        int Status { get; set; }

        /// <summary>
        /// Gets or sets the total score.
        /// </summary>
        int TotalScore { get; set; }

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
    /// The appointment form.
    /// </summary>
    public partial class AppointmentForm : BaseEntity, IAppointmentForm
    {
    }
}