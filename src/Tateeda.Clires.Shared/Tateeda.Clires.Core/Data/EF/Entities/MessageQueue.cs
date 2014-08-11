// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageQueue.cs" company="">
//   
// </copyright>
// <summary>
//   The MessageQueue interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The MessageQueue interface.
    /// </summary>
    public interface IMessageQueue
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        string Data { get; set; }

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
        /// Gets or sets the last processed on.
        /// </summary>
        DateTime? LastProcessedOn { get; set; }

        /// <summary>
        /// Gets or sets the message template.
        /// </summary>
        MessageTemplate MessageTemplate { get; set; }

        /// <summary>
        /// Gets or sets the priority id.
        /// </summary>
        int PriorityId { get; set; }

        /// <summary>
        /// Gets or sets the queued on.
        /// </summary>
        DateTime QueuedOn { get; set; }

        /// <summary>
        /// Gets or sets the recipient id.
        /// </summary>
        int RecipientId { get; set; }

        /// <summary>
        /// Gets or sets the sender id.
        /// </summary>
        int SenderId { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        int Status { get; set; }

        /// <summary>
        /// Gets or sets the status id.
        /// </summary>
        int StatusId { get; set; }

        /// <summary>
        /// Gets or sets the template id.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        int TemplateId { get; set; }

        /// <summary>
        /// Gets or sets the tries count.
        /// </summary>
        int TriesCount { get; set; }

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
    /// The message queue.
    /// </summary>
    public partial class MessageQueue : BaseEntity, IMessageQueue
    {
    }
}