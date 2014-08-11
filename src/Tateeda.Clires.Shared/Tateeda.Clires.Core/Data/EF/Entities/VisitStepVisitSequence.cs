// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VisitStepVisitSequence.cs" company="">
//   
// </copyright>
// <summary>
//   The VisitStepVisitSequence interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The VisitStepVisitSequence interface.
    /// </summary>
    public interface IVisitStepVisitSequence
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the days from base.
        /// </summary>
        int DaysFromBase { get; set; }

        /// <summary>
        /// Gets or sets the deviation.
        /// </summary>
        int Deviation { get; set; }

        /// <summary>
        ///   Gets or sets the entity identifier
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is active.
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is termination.
        /// </summary>
        bool IsTermination { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the visit.
        /// </summary>
        Visit Visit { get; set; }

        /// <summary>
        /// Gets or sets the visit id.
        /// </summary>
        int VisitId { get; set; }

        /// <summary>
        /// Gets or sets the visit step.
        /// </summary>
        VisitStep VisitStep { get; set; }

        /// <summary>
        /// Gets or sets the visit step id.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        int VisitStepId { get; set; }

        #endregion
    }

    /// <summary>
    /// The visit step visit sequence.
    /// </summary>
    public partial class VisitStepVisitSequence : BaseEntity, IVisitStepVisitSequence
    {
    }
}