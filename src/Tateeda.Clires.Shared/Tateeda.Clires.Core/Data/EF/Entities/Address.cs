// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Address.cs" company="">
//   
// </copyright>
// <summary>
//   The Address interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The Address interface.
    /// </summary>
    public interface IAddress
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the address type id.
        /// </summary>
        int AddressTypeId { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        string City { get; set; }

        /// <summary>
        /// Gets or sets the contacts.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        ICollection<Contact> Contacts { get; set; }

        /// <summary>
        /// Gets or sets the country id.
        /// </summary>
        int? CountryId { get; set; }

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
        /// Gets or sets the postal code.
        /// </summary>
        string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the state id.
        /// </summary>
        int? StateId { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        int Status { get; set; }

        /// <summary>
        /// Gets or sets the street.
        /// </summary>
        string Street { get; set; }

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
    /// The address.
    /// </summary>
    public partial class Address : BaseEntity, IAddress
    {
    }
}