// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DrugsRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The drugs repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Drugs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    using Tateeda.Clires.Core.Data.EF;
    using Tateeda.Clires.Core.Data.Enums;

    /// <summary>
    /// The drugs repository.
    /// </summary>
    public class DrugsRepository : IDrugsRepository
    {
        #region Fields

        /// <summary>
        /// The _context.
        /// </summary>
        private readonly IDbContext _context;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DrugsRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public DrugsRepository(IDbContext context)
        {
            _context = context;
            All = context.Drugs;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the all.
        /// </summary>
        public IQueryable<Drug> All { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The commit.
        /// </summary>
        public void Commit()
        {
            _context.Commit();
        }

        /// <summary>
        /// The create drug category.
        /// </summary>
        /// <param name="category">
        /// The category.
        /// </param>
        public void CreateDrugCategory(IDrugCategory category)
        {
            var cat = new DrugCategory
                {
                    IsActive = true, 
                    Code = category.Code, 
                    CreatedBy = category.CreatedBy ?? Thread.CurrentPrincipal.Identity.Name, 
                    CreatedOn = DateTime.UtcNow, 
                    Description = category.Description, 
                    Name = category.Name, 
                    Status = (int)EntityStatusType.Current, 
                    SortOrder = category.SortOrder, 
                    Directions = category.Directions
                };
            _context.DrugCategories.Add(cat);
        }

        /// <summary>
        /// The create drug class.
        /// </summary>
        /// <param name="drugClass">
        /// The drug class.
        /// </param>
        public void CreateDrugClass(IDrugClass drugClass)
        {
            var clazz = new DrugClass
                {
                    IsActive = true, 
                    CreatedBy = drugClass.CreatedBy ?? Thread.CurrentPrincipal.Identity.Name, 
                    CreatedOn = DateTime.UtcNow, 
                    Description = drugClass.Description, 
                    Name = drugClass.Name, 
                    Status = (int)EntityStatusType.Current, 
                    SortOrder = drugClass.SortOrder, 
                    Directions = drugClass.Directions, 
                    DrugCategoryId = drugClass.DrugCategoryId
                };
            _context.DrugClasses.Add(clazz);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Delete(Drug entity)
        {
            var drug = _context.Drugs.FirstOrDefault(a => a.Id == entity.Id);
            if (drug == null)
            {
                return;
            }

            drug.IsActive = false;
            drug.Status = (int)EntityStatusType.Deleted;
            drug.UpdatedBy = entity.UpdatedBy ?? Thread.CurrentPrincipal.Identity.Name;
            drug.UpdatedOn = DateTime.UtcNow;
        }

        /// <summary>
        /// The delete drug category.
        /// </summary>
        /// <param name="categoryId">
        /// The category id.
        /// </param>
        public void DeleteDrugCategory(int categoryId)
        {
            var item = _context.DrugCategories.FirstOrDefault(a => a.Id == categoryId);
            if (item == null)
            {
                return;
            }

            item.IsActive = false;
            item.Status = (int)EntityStatusType.Deleted;
            item.UpdatedBy = Thread.CurrentPrincipal.Identity.Name;
            item.UpdatedOn = DateTime.UtcNow;
        }

        /// <summary>
        /// The delete drug class.
        /// </summary>
        /// <param name="classId">
        /// The class id.
        /// </param>
        public void DeleteDrugClass(int classId)
        {
            var item = _context.DrugClasses.FirstOrDefault(a => a.Id == classId);
            if (item == null)
            {
                return;
            }

            item.IsActive = false;
            item.Status = (int)EntityStatusType.Deleted;
            item.UpdatedBy = Thread.CurrentPrincipal.Identity.Name;
            item.UpdatedOn = DateTime.UtcNow;
        }

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
        public IEnumerable<IDrug> FindByName(string text, int maxRetur)
        {
            _context.AutoDetectChangesEnabled = false;

            var drugs =
                _context.Drugs.Where(d => d.IsActive && d.Status != (int)EntityStatusType.Deleted && d.Name.Contains(text)).OrderBy(d => d.Name).Take(maxRetur).
                    AsEnumerable();

            _context.AutoDetectChangesEnabled = true;

            return drugs;
        }

        /// <summary>
        /// The get all drug categories.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<IDrugCategory> GetAllDrugCategories()
        {
            return _context.DrugCategories.Where(c => c.IsActive && c.Status != (int)EntityStatusType.Deleted).AsEnumerable();
        }

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Drug"/>.
        /// </returns>
        public Drug GetById(object id)
        {
            return _context.Drugs.FirstOrDefault(a => a.Id == (int)id);
        }

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
        public IEnumerable<IDrug> GetClassDrugs(int classId, int pageIndex, out int totalRecords, int pageSize = 20)
        {
            _context.AutoDetectChangesEnabled = false;
            totalRecords = _context.Drugs.Count(c => c.IsActive && c.Status != (int)EntityStatusType.Deleted && c.DrugClassId == classId);

            var drugs =
                _context.Drugs.Where(c => c.IsActive && c.Status != (int)EntityStatusType.Deleted && c.DrugClassId == classId).OrderBy(d => d.Name).Skip(
                    pageIndex * pageSize).Take(pageSize).AsEnumerable();

            _context.AutoDetectChangesEnabled = true;

            return drugs;
        }

        /// <summary>
        /// The get drug classes.
        /// </summary>
        /// <param name="categoryId">
        /// The category id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<IDrugClass> GetDrugClasses(int categoryId)
        {
            return _context.DrugClasses.Where(c => c.IsActive && c.Status != (int)EntityStatusType.Deleted && c.DrugCategoryId == categoryId).AsEnumerable();
        }

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Insert(Drug entity)
        {
            entity.CreatedBy = Thread.CurrentPrincipal.Identity.Name;
            entity.CreatedOn = DateTime.UtcNow;
            _context.Drugs.Add(entity);
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Update(Drug entity)
        {
            var drug = _context.Drugs.FirstOrDefault(a => a.Id == entity.Id);
            if (drug == null)
            {
                return;
            }

            drug.UpdatedBy = entity.UpdatedBy ?? Thread.CurrentPrincipal.Identity.Name;
            drug.UpdatedOn = DateTime.UtcNow;
            drug.Name = entity.Name;
            drug.IsActive = entity.IsActive;
            drug.SortOrder = entity.SortOrder;
            drug.Status = entity.Status;
            drug.StudyId = entity.StudyId;
            drug.Description = entity.Description;
            drug.Directions = entity.Directions;
            drug.DrugTypeId = entity.DrugTypeId;
            drug.DrugClassId = entity.DrugClassId;
        }

        #endregion
    }
}