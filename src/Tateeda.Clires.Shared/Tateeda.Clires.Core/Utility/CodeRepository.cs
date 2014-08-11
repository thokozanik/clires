// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CodeRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The code repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    using Tateeda.Clires.Core.Data.EF;

    /// <summary>
    /// The code repository.
    /// </summary>
    public class CodeRepository : ICodeRepository
    {
        #region Fields

        /// <summary>
        /// The _context.
        /// </summary>
        private readonly IDbContext _context;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public CodeRepository(IDbContext context)
        {
            _context = context;
            All = _context.Codes;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the all.
        /// </summary>
        public IQueryable<Code> All { get; private set; }

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
        /// The delete.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Delete(Code entity)
        {
            var item = _context.Codes.FirstOrDefault(a => a.Id == entity.Id);
            if (item == null)
            {
                return;
            }

            item.IsActive = false;
            item.UpdatedBy = entity.UpdatedBy ?? Thread.CurrentPrincipal.Identity.Name;
            item.UpdatedOn = DateTime.UtcNow;
        }

        /// <summary>
        /// The get address types.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<ICode> GetAddressTypes()
        {
            const int typeId = 12;
            return _context.Codes.Where(c => c.CodeTypeId == typeId).AsEnumerable();
        }

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Code"/>.
        /// </returns>
        public Code GetById(object id)
        {
            return _context.Codes.FirstOrDefault(c => c.Id == (int)id);
        }

        /// <summary>
        /// The get code type enumeration.
        /// </summary>
        /// <param name="typeId">
        /// The type id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<ICode> GetCodeTypeEnumeration(int typeId)
        {
            _context.AutoDetectChangesEnabled = false;
            var codes = _context.Codes.Where(c => c.CodeTypeId == typeId).AsEnumerable();
            _context.AutoDetectChangesEnabled = true;
            return codes;
        }

        /// <summary>
        /// The get countries.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<ICountry> GetCountries()
        {
            _context.AutoDetectChangesEnabled = false;
            var countries = _context.Countries.AsEnumerable();
            _context.AutoDetectChangesEnabled = true;
            return countries;
        }

        /// <summary>
        /// The get field data types.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<ICode> GetFieldDataTypes()
        {
            const int FieldDataTypeId = 6;
            return GetCodeTypeEnumeration(FieldDataTypeId);
        }

        /// <summary>
        /// The get form layout types.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<ICode> GetFormLayoutTypes()
        {
            const int FormLayoutTypeId = 5;
            return GetCodeTypeEnumeration(FormLayoutTypeId);
        }

        /// <summary>
        /// The get form statuses.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<ICode> GetFormStatuses()
        {
            const int FormStatusId = 2;
            return GetCodeTypeEnumeration(FormStatusId);
        }

        /// <summary>
        /// The get form types.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<ICode> GetFormTypes()
        {
            const int FormTypeId = 1;
            return GetCodeTypeEnumeration(FormTypeId);
        }

        /// <summary>
        /// The get gender.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<ICode> GetGender()
        {
            const int GenderTypeId = 10;
            return GetCodeTypeEnumeration(GenderTypeId);
        }

        /// <summary>
        /// The get phone types.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<ICode> GetPhoneTypes()
        {
            const int typeId = 11;
            return _context.Codes.Where(c => c.CodeTypeId == typeId).AsEnumerable();
        }

        /// <summary>
        /// The get roles list.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<IRole> GetRolesList()
        {
            _context.AutoDetectChangesEnabled = false;
            var rols = _context.Roles.AsEnumerable();
            _context.AutoDetectChangesEnabled = true;
            return rols;
        }

        /// <summary>
        /// The get sites list.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<ISite> GetSitesList()
        {
            _context.AutoDetectChangesEnabled = false;
            var sites = _context.Sites.AsEnumerable();
            _context.AutoDetectChangesEnabled = true;
            return sites;
        }

        /// <summary>
        /// The get states.
        /// </summary>
        /// <param name="countryId">
        /// The country id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<IState> GetStates(int countryId)
        {
            _context.AutoDetectChangesEnabled = false;
            var states = _context.Countries.FirstOrDefault(c => c.Id == countryId).States.AsEnumerable();
            _context.AutoDetectChangesEnabled = true;
            return states;
        }

        /// <summary>
        /// The get study list.
        /// </summary>
        /// <param name="showAll">
        /// The show all.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<IStudy> GetStudyList(bool showAll)
        {
            return showAll ? _context.Studies.AsEnumerable() : _context.Studies.Where(s => s.IsActive).AsEnumerable();
        }

        /// <summary>
        /// The get time zones.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<ITimeZone> GetTimeZones()
        {
            _context.AutoDetectChangesEnabled = false;
            var zones = _context.TimeZones.AsEnumerable();
            _context.AutoDetectChangesEnabled = true;
            return zones;
        }

        /// <summary>
        /// The get visit statuses.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<ICode> GetVisitStatuses()
        {
            const int VisitStatusId = 4;
            return GetCodeTypeEnumeration(VisitStatusId);
        }

        /// <summary>
        /// The get visit types.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<ICode> GetVisitTypes()
        {
            const int VisitTypeId = 3;
            return GetCodeTypeEnumeration(VisitTypeId);
        }

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Insert(Code entity)
        {
            _context.Codes.Add(entity);
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Update(Code entity)
        {
            var code = _context.Codes.FirstOrDefault(c => c.Id == entity.Id);
            if (code != null)
            {
                code.CodeTypeId = entity.CodeTypeId;
                code.CreatedBy = entity.CreatedBy;
                code.CreatedOn = entity.CreatedOn;
                code.Description = entity.Description;
                code.EnumId = entity.EnumId;
                code.IsActive = entity.IsActive;
                code.Name = entity.Name;
                code.SortOrder = entity.SortOrder;
                code.UpdatedBy = entity.UpdatedBy;
                code.UpdatedOn = DateTime.UtcNow;
            }
        }

        #endregion
    }
}