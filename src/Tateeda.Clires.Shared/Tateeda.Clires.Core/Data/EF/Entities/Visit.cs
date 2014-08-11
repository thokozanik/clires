// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Visit.cs" company="">
//   
// </copyright>
// <summary>
//   The Visit interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The Visit interface.
    /// </summary>
    public interface IVisit
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the appointments.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        ICollection<Appointment> Appointments { get; set; }

        /// <summary>
        /// Gets or sets the arm.
        /// </summary>
        Arm Arm { get; set; }

        /// <summary>
        /// Gets or sets the arm id.
        /// </summary>
        int ArmId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether can move.
        /// </summary>
        bool CanMove { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether can repeat.
        /// </summary>
        bool CanRepeat { get; set; }

        /// <summary>
        /// Gets or sets the child visit.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        ICollection<Visit> ChildVisit { get; set; }

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
        /// Gets or sets the form visibility by visit for subjects.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        ICollection<FormVisibilityByVisitForSubject> FormVisibilityByVisitForSubjects { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether has child.
        /// </summary>
        bool HasChild { get; set; }

        /// <summary>
        ///   Gets or sets the entity identifier
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is active.
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is base visit.
        /// </summary>
        bool IsBaseVisit { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the parent visit.
        /// </summary>
        Visit ParentVisit { get; set; }

        /// <summary>
        /// Gets or sets the parent visit id.
        /// </summary>
        int? ParentVisitId { get; set; }

        /// <summary>
        /// Gets or sets the schedule subject visits.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        ICollection<ScheduleSubjectVisit> ScheduleSubjectVisits { get; set; }

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

        /// <summary>
        /// Gets or sets the visit forms.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        ICollection<VisitForm> VisitForms { get; set; }

        /// <summary>
        /// Gets or sets the visit step visit sequences.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        ICollection<VisitStepVisitSequence> VisitStepVisitSequences { get; set; }

        /// <summary>
        /// Gets or sets the visit steps.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        ICollection<VisitStep> VisitSteps { get; set; }

        /// <summary>
        /// Gets or sets the visit type id.
        /// </summary>
        int VisitTypeId { get; set; }

        #endregion
    }

    /// <summary>
    /// The visit.
    /// </summary>
    public partial class Visit : BaseEntity, IVisit
    {
    }
}