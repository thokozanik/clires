// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SubjectDrug.cs" company="">
//   
// </copyright>
// <summary>
//   The SubjectDrug interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The SubjectDrug interface.
    /// </summary>
    public interface ISubjectDrug
    {
        #region Public Properties

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
        DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the directions.
        /// </summary>
        string Directions { get; set; }

        /// <summary>
        /// Gets or sets the dosage.
        /// </summary>
        string Dosage { get; set; }

        /// <summary>
        /// Gets or sets the dosage frequency id.
        /// </summary>
        int DosageFrequencyId { get; set; }

        /// <summary>
        /// Gets or sets the dosage type.
        /// </summary>
        string DosageType { get; set; }

        /// <summary>
        /// Gets or sets the drug.
        /// </summary>
        Drug Drug { get; set; }

        /// <summary>
        /// Gets or sets the drug id.
        /// </summary>
        int DrugId { get; set; }

        /// <summary>
        /// Gets or sets the duration used.
        /// </summary>
        int? DurationUsed { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        DateTime? EndDate { get; set; }

        /// <summary>
        ///   Gets or sets the entity identifier
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is active.
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is before study.
        /// </summary>
        bool IsBeforeStudy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is changed.
        /// </summary>
        bool IsChanged { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is current.
        /// </summary>
        bool IsCurrent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is stopped.
        /// </summary>
        bool IsStopped { get; set; }

        /// <summary>
        /// Gets or sets the md notes.
        /// </summary>
        string MdNotes { get; set; }

        /// <summary>
        /// Gets or sets the multiple trials id.
        /// </summary>
        int? MultipleTrialsId { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        string Notes { get; set; }

        /// <summary>
        /// Gets or sets the reason stopped id.
        /// </summary>
        int ReasonStoppedId { get; set; }

        /// <summary>
        /// Gets or sets the reason type id.
        /// </summary>
        int ReasonTypeId { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        int Status { get; set; }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        Subject Subject { get; set; }

        /// <summary>
        /// Gets or sets the subject id.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        int SubjectId { get; set; }

        /// <summary>
        /// Gets or sets the treatment induced id.
        /// </summary>
        int TreatmentInducedId { get; set; }

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
    /// The subject drug.
    /// </summary>
    public partial class SubjectDrug : BaseEntity, ISubjectDrug
    {
    }
}