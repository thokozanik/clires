// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="">
//   
// </copyright>
// <summary>
//   The User interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The User interface.
    /// </summary>
    public interface IUser
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the app users.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        ICollection<AppUser> AppUsers { get; set; }

        /// <summary>
        /// Gets or sets the application id.
        /// </summary>
        Guid ApplicationId { get; set; }

        /// <summary>
        ///   Gets or sets the entity identifier
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is anonymous.
        /// </summary>
        bool IsAnonymous { get; set; }

        /// <summary>
        /// Gets or sets the last activity date.
        /// </summary>
        DateTime LastActivityDate { get; set; }

        /// <summary>
        /// Gets or sets the membership.
        /// </summary>
        Membership Membership { get; set; }

        /// <summary>
        /// Gets or sets the profile.
        /// </summary>
        Profile Profile { get; set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        string UserName { get; set; }

        #endregion
    }

    /// <summary>
    /// The user.
    /// </summary>
    public partial class User : BaseEntity, IUser
    {
    }
}