// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageProvider.cs" company="">
//   
// </copyright>
// <summary>
//   The MessageProvider interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The MessageProvider interface.
    /// </summary>
    public interface IMessageProvider
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the account name.
        /// </summary>
        string AccountName { get; set; }

        /// <summary>
        /// Gets or sets the account password.
        /// </summary>
        string AccountPassword { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        ///   Gets or sets the entity identifier
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is active.
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the license key.
        /// </summary>
        string LicenseKey { get; set; }

        /// <summary>
        /// Gets or sets the message templates.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        ICollection<MessageTemplate> MessageTemplates { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the service uri.
        /// </summary>
        string ServiceUri { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        int Status { get; set; }

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
    /// The message provider.
    /// </summary>
    public partial class MessageProvider : BaseEntity, IMessageProvider
    {
    }
}