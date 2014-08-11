// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VisitForm.cs" company="">
//   
// </copyright>
// <summary>
//   The VisitForm interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The VisitForm interface.
    /// </summary>
    public interface IVisitForm
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the form.
        /// </summary>
        Form Form { get; set; }

        /// <summary>
        /// Gets or sets the form id.
        /// </summary>
        int FormId { get; set; }

        /// <summary>
        ///   Gets or sets the entity identifier
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        int? SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the visit.
        /// </summary>
        Visit Visit { get; set; }

        /// <summary>
        /// Gets or sets the visit id.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        int VisitId { get; set; }

        #endregion
    }

    /// <summary>
    /// The visit form.
    /// </summary>
    public partial class VisitForm : BaseEntity, IVisitForm
    {
    }
}