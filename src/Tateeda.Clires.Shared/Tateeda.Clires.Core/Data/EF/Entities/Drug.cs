// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Drug.cs" company="">
//   
// </copyright>
// <summary>
//   The Drug interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The Drug interface.
    /// </summary>
    public interface IDrug
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the directions.
        /// </summary>
        string Directions { get; set; }

        /// <summary>
        /// Gets or sets the drug class.
        /// </summary>
        DrugClass DrugClass { get; set; }

        /// <summary>
        /// Gets or sets the drug class id.
        /// </summary>
        int DrugClassId { get; set; }

        /// <summary>
        /// Gets or sets the drug type id.
        /// </summary>
        int? DrugTypeId { get; set; }

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
        /// Gets or sets the study.
        /// </summary>
        Study Study { get; set; }

        /// <summary>
        /// Gets or sets the study id.
        /// </summary>
        int StudyId { get; set; }

        /// <summary>
        /// Gets or sets the subject drugs.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        ICollection<SubjectDrug> SubjectDrugs { get; set; }

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
    /// The drug.
    /// </summary>
    public partial class Drug : BaseEntity, IDrug
    {
    }
}