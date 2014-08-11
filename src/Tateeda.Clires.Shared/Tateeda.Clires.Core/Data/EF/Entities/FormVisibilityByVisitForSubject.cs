// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FormVisibilityByVisitForSubject.cs" company="">
//   
// </copyright>
// <summary>
//   The FormVisibilityByVisitForSubject interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The FormVisibilityByVisitForSubject interface.
    /// </summary>
    public interface IFormVisibilityByVisitForSubject
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
        /// Gets or sets the days after visit.
        /// </summary>
        int DaysAfterVisit { get; set; }

        /// <summary>
        /// Gets or sets the days prior to visit.
        /// </summary>
        int DaysPriorToVisit { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        string Description { get; set; }

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
        /// Gets or sets a value indicating whether is active.
        /// </summary>
        bool IsActive { get; set; }

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
        /// Gets or sets the visit.
        /// </summary>
        Visit Visit { get; set; }

        /// <summary>
        /// Gets or sets the visit id.
        /// </summary>
        int VisitId { get; set; }

        #endregion
    }

    /// <summary>
    /// The form visibility by visit for subject.
    /// </summary>
    public partial class FormVisibilityByVisitForSubject : BaseEntity, IFormVisibilityByVisitForSubject
    {
    }
}