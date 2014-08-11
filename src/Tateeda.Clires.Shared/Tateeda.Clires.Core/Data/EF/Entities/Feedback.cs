// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Feedback.cs" company="">
//   
// </copyright>
// <summary>
//   The Feedback interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The Feedback interface.
    /// </summary>
    public interface IFeedback
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        string Comment { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        DateTime CreatedOn { get; set; }

        /// <summary>
        ///   Gets or sets the entity identifier
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets the like score.
        /// </summary>
        int LikeScore { get; set; }

        /// <summary>
        /// Gets or sets the uri.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        string Uri { get; set; }

        #endregion
    }

    /// <summary>
    /// The feedback.
    /// </summary>
    public partial class Feedback : BaseEntity, IFeedback
    {
    }
}