// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Membership.cs" company="">
//   
// </copyright>
// <summary>
//   The Membership interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The Membership interface.
    /// </summary>
    public interface IMembership
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the application id.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        Guid ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        string Comment { get; set; }

        /// <summary>
        /// Gets or sets the create date.
        /// </summary>
        DateTime CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// Gets or sets the failed password answer attempt count.
        /// </summary>
        int FailedPasswordAnswerAttemptCount { get; set; }

        /// <summary>
        /// Gets or sets the failed password answer attempt windows start.
        /// </summary>
        DateTime FailedPasswordAnswerAttemptWindowsStart { get; set; }

        /// <summary>
        /// Gets or sets the failed password attempt count.
        /// </summary>
        int FailedPasswordAttemptCount { get; set; }

        /// <summary>
        /// Gets or sets the failed password attempt window start.
        /// </summary>
        DateTime FailedPasswordAttemptWindowStart { get; set; }

        /// <summary>
        ///   Gets or sets the entity identifier
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is approved.
        /// </summary>
        bool IsApproved { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is locked out.
        /// </summary>
        bool IsLockedOut { get; set; }

        /// <summary>
        /// Gets or sets the last lockout date.
        /// </summary>
        DateTime LastLockoutDate { get; set; }

        /// <summary>
        /// Gets or sets the last login date.
        /// </summary>
        DateTime LastLoginDate { get; set; }

        /// <summary>
        /// Gets or sets the last password changed date.
        /// </summary>
        DateTime LastPasswordChangedDate { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// Gets or sets the password answer.
        /// </summary>
        string PasswordAnswer { get; set; }

        /// <summary>
        /// Gets or sets the password format.
        /// </summary>
        int PasswordFormat { get; set; }

        /// <summary>
        /// Gets or sets the password question.
        /// </summary>
        string PasswordQuestion { get; set; }

        /// <summary>
        /// Gets or sets the password salt.
        /// </summary>
        string PasswordSalt { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        User User { get; set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        Guid UserId { get; set; }

        #endregion
    }

    /// <summary>
    /// The membership.
    /// </summary>
    public partial class Membership : BaseEntity, IMembership
    {
    }
}