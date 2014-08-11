// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Role.cs" company="">
//   
// </copyright>
// <summary>
//   The Role interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The Role interface.
    /// </summary>
    public interface IRole
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the application id.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        Guid ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        ///   Gets or sets the entity identifier
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets the role id.
        /// </summary>
        Guid RoleId { get; set; }

        /// <summary>
        /// Gets or sets the role name.
        /// </summary>
        string RoleName { get; set; }

        #endregion
    }

    /// <summary>
    /// The role.
    /// </summary>
    public partial class Role : BaseEntity, IRole
    {
    }
}