// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Appointment.cs" company="">
//   
// </copyright>
// <summary>
//   The Appointment interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The Appointment interface.
    /// </summary>
    public interface IAppointment
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the app user id.
        /// </summary>
        int AppUserId { get; set; }

        /// <summary>
        /// Gets or sets the appointment forms.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        ICollection<AppointmentForm> AppointmentForms { get; set; }

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
        /// Gets or sets the end date.
        /// </summary>
        DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        TimeSpan? EndTime { get; set; }

        /// <summary>
        ///   Gets or sets the entity identifier
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is active.
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        string Location { get; set; }

        /// <summary>
        /// Gets or sets the recreational drug or substances.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        ICollection<RecreationalDrugOrSubstance> RecreationalDrugOrSubstances { get; set; }

        /// <summary>
        /// Gets or sets the site id.
        /// </summary>
        int SiteId { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        TimeSpan? StartTime { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        int Status { get; set; }

        /// <summary>
        /// Gets or sets the subject id.
        /// </summary>
        int SubjectId { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated on.
        /// </summary>
        DateTime? UpdatedOn { get; set; }

        /// <summary>
        /// Gets or sets the visit.
        /// </summary>
        Visit Visit { get; set; }

        /// <summary>
        /// Gets or sets the visit id.
        /// </summary>
        int VisitId { get; set; }

        /// <summary>
        /// Gets or sets the visit step id.
        /// </summary>
        int VisitStepId { get; set; }

        #endregion
    }

    /// <summary>
    /// The appointment.
    /// </summary>
    public partial class Appointment : BaseEntity, IAppointment
    {
    }
}