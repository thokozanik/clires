// --------------------------------------------------------------------------------------------------------------------
// <copyright file="File.cs" company="">
//   
// </copyright>
// <summary>
//   The File interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The File interface.
    /// </summary>
    public interface IFile
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
        /// Gets or sets the fiel content.
        /// </summary>
        byte[] FielContent { get; set; }

        /// <summary>
        /// Gets or sets the file guid.
        /// </summary>
        Guid FileGuid { get; set; }

        /// <summary>
        /// Gets or sets the file type.
        /// </summary>
        string FileType { get; set; }

        /// <summary>
        ///   Gets or sets the entity identifier
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the studies.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        ICollection<Study> Studies { get; set; }

        /// <summary>
        /// Gets or sets the subjects.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        ICollection<Subject> Subjects { get; set; }

        #endregion
    }

    /// <summary>
    /// The file.
    /// </summary>
    public partial class File : BaseEntity, IFile
    {
    }
}