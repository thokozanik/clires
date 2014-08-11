// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppUser.cs" company="">
//   
// </copyright>
// <summary>
//   The AppUser interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The AppUser interface.
    /// </summary>
    public interface IAppUser
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        string Comments { get; set; }

        /// <summary>
        /// Gets or sets the contact.
        /// </summary>
        Contact Contact { get; set; }

        /// <summary>
        /// Gets or sets the contact id.
        /// </summary>
        int ContactId { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        DateTime? CreatedOn { get; set; }

        /// <summary>
        ///   Gets or sets the entity identifier
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is active.
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the membership user id.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        Guid MembershipUserId { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        Role Role { get; set; }

        /// <summary>
        /// Gets or sets the role id.
        /// </summary>
        Guid RoleId { get; set; }

        /// <summary>
        /// Gets or sets the site.
        /// </summary>
        Site Site { get; set; }

        /// <summary>
        /// Gets or sets the site id.
        /// </summary>
        int SiteId { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        int Status { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated on.
        /// </summary>
        DateTime? UpdatedOn { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        User User { get; set; }

        #endregion
    }

    /// <summary>
    /// The app user.
    /// </summary>
    public partial class AppUser : BaseEntity, IAppUser
    {
    }
}