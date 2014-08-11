// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPersistentCollection.cs" company="">
//   
// </copyright>
// <summary>
//   The PersistentCollection interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// The PersistentCollection interface.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public interface IPersistentCollection<T> : ICollection<T>, ICollection
        where T : class
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the after add.
        /// </summary>
        Action<ICollection<T>> AfterAdd { get; set; }

        /// <summary>
        /// Gets or sets the after remove.
        /// </summary>
        Action<ICollection<T>> AfterRemove { get; set; }

        /// <summary>
        /// Gets or sets the before add.
        /// </summary>
        Func<ICollection<T>, T, bool> BeforeAdd { get; set; }

        /// <summary>
        /// Gets or sets the before remove.
        /// </summary>
        Func<ICollection<T>, T, bool> BeforeRemove { get; set; }

        #endregion
    }
}