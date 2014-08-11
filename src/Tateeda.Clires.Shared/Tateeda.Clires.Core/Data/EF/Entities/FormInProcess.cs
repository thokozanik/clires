// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FormInProcess.cs" company="">
//   
// </copyright>
// <summary>
//   The FormInProcess interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The FormInProcess interface.
    /// </summary>
    public interface IFormInProcess
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the app user id.
        /// </summary>
        int AppUserId { get; set; }

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
        /// Gets or sets a value indicating whether is locked.
        /// </summary>
        bool IsLocked { get; set; }

        /// <summary>
        /// Gets or sets the max lock time min.
        /// </summary>
        int MaxLockTimeMin { get; set; }

        /// <summary>
        /// Gets or sets the openend on.
        /// </summary>
        DateTime OpenendOn { get; set; }

        /// <summary>
        /// Gets or sets the released on.
        /// </summary>
        DateTime? ReleasedOn { get; set; }

        /// <summary>
        /// Gets or sets the subject id.
        /// </summary>
        int SubjectId { get; set; }

        /// <summary>
        /// Gets or sets the unlocked by app user id.
        /// </summary>
        int UnlockedByAppUserId { get; set; }

        #endregion
    }

    /// <summary>
    /// The form in process.
    /// </summary>
    public partial class FormInProcess : BaseEntity, IFormInProcess
    {
    }
}