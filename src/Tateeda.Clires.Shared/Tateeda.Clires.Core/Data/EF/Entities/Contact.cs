// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Contact.cs" company="">
//   
// </copyright>
// <summary>
//   The Contact interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The Contact interface.
    /// </summary>
    public interface IContact
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the addresses.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        ICollection<Address> Addresses { get; set; }

        /// <summary>
        /// Gets or sets the app users.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        ICollection<AppUser> AppUsers { get; set; }

        /// <summary>
        /// Gets or sets the contact type id.
        /// </summary>
        int ContactTypeId { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the emails.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        ICollection<Email> Emails { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        string FirstName { get; set; }

        /// <summary>
        ///   Gets or sets the entity identifier
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is active.
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        string LastName { get; set; }

        /// <summary>
        /// Gets or sets the middle name.
        /// </summary>
        string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        int Status { get; set; }

        /// <summary>
        /// Gets or sets the subjects.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        ICollection<Subject> Subjects { get; set; }

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
    /// The contact.
    /// </summary>
    public partial class Contact : BaseEntity, IContact
    {
    }
}