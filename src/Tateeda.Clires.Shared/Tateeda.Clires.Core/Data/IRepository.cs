// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The Repository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data
{
    using System.Linq;

    using Tateeda.Clires.Core.Data.EF;

    /// <summary>
    /// The Repository interface.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public interface IRepository<T>
        where T : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets the all.
        /// </summary>
        IQueryable<T> All { get; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Delete(T entity);

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T GetById(object id);

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Insert(T entity);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Update(T entity);

        #endregion

        // void Commit();
    }
}