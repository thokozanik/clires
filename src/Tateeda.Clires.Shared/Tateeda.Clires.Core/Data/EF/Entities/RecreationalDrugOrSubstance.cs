// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecreationalDrugOrSubstance.cs" company="">
//   
// </copyright>
// <summary>
//   The RecreationalDrugOrSubstance interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The RecreationalDrugOrSubstance interface.
    /// </summary>
    public interface IRecreationalDrugOrSubstance
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the appointement id.
        /// </summary>
        int? AppointementId { get; set; }

        /// <summary>
        /// Gets or sets the appointment.
        /// </summary>
        Appointment Appointment { get; set; }

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
        DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the dose.
        /// </summary>
        string Dose { get; set; }

        /// <summary>
        /// Gets or sets the frequency.
        /// </summary>
        int? Frequency { get; set; }

        /// <summary>
        /// Gets or sets the frequency unit.
        /// </summary>
        string FrequencyUnit { get; set; }

        /// <summary>
        ///   Gets or sets the entity identifier
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is active.
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        int Status { get; set; }

        /// <summary>
        /// Gets or sets the subject id.
        /// </summary>
        int SubjectId { get; set; }

        /// <summary>
        /// Gets or sets the type name.
        /// </summary>
        string TypeName { get; set; }

        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        string Unit { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated on.
        /// </summary>
        DateTime? UpdatedOn { get; set; }

        /// <summary>
        /// Gets or sets the use end date.
        /// </summary>
        DateTime? UseEndDate { get; set; }

        /// <summary>
        /// Gets or sets the use start date.
        /// </summary>
        DateTime? UseStartDate { get; set; }

        #endregion
    }

    /// <summary>
    /// The recreational drug or substance.
    /// </summary>
    public partial class RecreationalDrugOrSubstance : BaseEntity, IRecreationalDrugOrSubstance
    {
    }
}