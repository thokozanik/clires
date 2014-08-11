// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Profile.cs" company="">
//   
// </copyright>
// <summary>
//   The Profile interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The Profile interface.
    /// </summary>
    public interface IProfile
    {
        #region Public Properties

        /// <summary>
        ///   Gets or sets the entity identifier
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets the last updated date.
        /// </summary>
        DateTime LastUpdatedDate { get; set; }

        /// <summary>
        /// Gets or sets the property names.
        /// </summary>
        string PropertyNames { get; set; }

        /// <summary>
        /// Gets or sets the property value binary.
        /// </summary>
        byte[] PropertyValueBinary { get; set; }

        /// <summary>
        /// Gets or sets the property value strings.
        /// </summary>
        string PropertyValueStrings { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        User User { get; set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        Guid UserId { get; set; }

        #endregion
    }

    /// <summary>
    /// The profile.
    /// </summary>
    public partial class Profile : BaseEntity, IProfile
    {
    }
}