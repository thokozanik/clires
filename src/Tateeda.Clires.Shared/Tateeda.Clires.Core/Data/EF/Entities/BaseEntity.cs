// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseEntity.cs" company="">
//   
// </copyright>
// <summary>
//   The base entity.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
    /// <summary>
    /// The base entity.
    /// </summary>
    public abstract class BaseEntity : IBaseEntity
    {
        #region Public Properties

        /// <summary>
        ///   Gets or sets the entity identifier
        /// </summary>
        public int Id { get; set; }

        #endregion
    }

    /// <summary>
    /// The BaseEntity interface.
    /// </summary>
    public interface IBaseEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        int Id { get; set; }

        #endregion
    }
}