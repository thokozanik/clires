// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Phone.cs" company="">
//   
// </copyright>
// <summary>
//   The Phone interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The Phone interface.
    /// </summary>
    public interface IPhone
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the area code.
        /// </summary>
        int AreaCode { get; set; }

        /// <summary>
        /// Gets or sets the contacts.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        ICollection<Contact> Contacts { get; set; }

        /// <summary>
        /// Gets or sets the country code.
        /// </summary>
        string CountryCode { get; set; }

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
        /// Gets or sets a value indicating whether is active.
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        int Number { get; set; }

        /// <summary>
        /// Gets or sets the phone type id.
        /// </summary>
        int? PhoneTypeId { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        int Status { get; set; }

        /// <summary>
        /// Gets or sets the telephone.
        /// </summary>
        string Telephone { get; set; }

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
    /// The phone.
    /// </summary>
    public partial class Phone : BaseEntity, IPhone
    {
    }
}