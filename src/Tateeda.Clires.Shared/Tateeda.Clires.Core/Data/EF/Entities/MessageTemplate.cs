// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageTemplate.cs" company="">
//   
// </copyright>
// <summary>
//   The MessageTemplate interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The MessageTemplate interface.
    /// </summary>
    public interface IMessageTemplate
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the bcc email addresses.
        /// </summary>
        string BccEmailAddresses { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        string Body { get; set; }

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
        /// Gets or sets the language.
        /// </summary>
        Language Language { get; set; }

        /// <summary>
        /// Gets or sets the language id.
        /// </summary>
        int LanguageId { get; set; }

        /// <summary>
        /// Gets or sets the message provider.
        /// </summary>
        MessageProvider MessageProvider { get; set; }

        /// <summary>
        /// Gets or sets the message provider id.
        /// </summary>
        int MessageProviderId { get; set; }

        /// <summary>
        /// Gets or sets the message queues.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        ICollection<MessageQueue> MessageQueues { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        int Status { get; set; }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        string Subject { get; set; }

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
    /// The message template.
    /// </summary>
    public partial class MessageTemplate : BaseEntity, IMessageTemplate
    {
    }
}