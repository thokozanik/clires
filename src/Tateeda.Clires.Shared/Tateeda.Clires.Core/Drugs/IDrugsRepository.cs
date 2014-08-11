// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDrugsRepository.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the IDrugsRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Tateeda.Clires.Core.Drugs
{
    using System.Collections.Generic;

    using Tateeda.Clires.Core.Data;
    using Tateeda.Clires.Core.Data.EF;

    /// <summary>
    /// The DrugsRepository interface.
    /// </summary>
    public interface IDrugsRepository : IRepository<Drug>
    {
        #region Public Methods and Operators

        /// <summary>
        /// The create drug category.
        /// </summary>
        /// <param name="category">
        /// The category.
        /// </param>
        void CreateDrugCategory(IDrugCategory category);

        /// <summary>
        /// The create drug class.
        /// </summary>
        /// <param name="drugClass">
        /// The drug class.
        /// </param>
        void CreateDrugClass(IDrugClass drugClass);

        /// <summary>
        /// The delete drug category.
        /// </summary>
        /// <param name="categoryId">
        /// The category id.
        /// </param>
        void DeleteDrugCategory(int categoryId);

        /// <summary>
        /// The delete drug class.
        /// </summary>
        /// <param name="classId">
        /// The class id.
        /// </param>
        void DeleteDrugClass(int classId);

        /// <summary>
        /// The find by name.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <param name="maxRetur">
        /// The max retur.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<IDrug> FindByName(string text, int maxRetur);

        /// <summary>
        /// The get all drug categories.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<IDrugCategory> GetAllDrugCategories();

        /// <summary>
        /// The get class drugs.
        /// </summary>
        /// <param name="classId">
        /// The class id.
        /// </param>
        /// <param name="pageIndex">
        /// The page index.
        /// </param>
        /// <param name="totalRecords">
        /// The total records.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<IDrug> GetClassDrugs(int classId, int pageIndex, out int totalRecords, int pageSize = 20);

        /// <summary>
        /// The get drug classes.
        /// </summary>
        /// <param name="categoryId">
        /// The category id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<IDrugClass> GetDrugClasses(int categoryId);

        #endregion
    }
}