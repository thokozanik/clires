// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SettingsRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The settings repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Utility
{
    using System;
    using System.Linq;
    using System.Threading;

    using Tateeda.Clires.Core.Data.EF;

    /// <summary>
    /// The settings repository.
    /// </summary>
    public class SettingsRepository : ISettingsRepository
    {
        #region Fields

        /// <summary>
        /// The _context.
        /// </summary>
        private readonly IDbContext _context;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public SettingsRepository(IDbContext context)
        {
            _context = context;
            All = _context.Settings;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the all.
        /// </summary>
        public IQueryable<Setting> All { get; private set; }

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
        public void Delete(Setting entity)
        {
            _context.Settings.Remove(entity);
        }

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Setting"/>.
        /// </returns>
        public Setting GetById(object id)
        {
            return _context.Settings.FirstOrDefault(c => c.Id == (int)id);
        }

        /// <summary>
        /// The get by name.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="ISetting"/>.
        /// </returns>
        public ISetting GetByName(string name)
        {
            _context.AutoDetectChangesEnabled = false;
            var setting = _context.Settings.FirstOrDefault(s => s.Name.Equals(name));
            _context.AutoDetectChangesEnabled = true;
            return setting;
        }

        /// <summary>
        /// The get current study.
        /// </summary>
        /// <returns>
        /// The <see cref="ISetting"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public ISetting GetCurrentStudy()
        {
            var curStudy = _context.Settings.FirstOrDefault(s => s.Name == "CurrentStudyId");
            if (curStudy == null)
            {
                throw new Exception("Missing configuration value for [Name] = CurrentStudyId in Settings table");
            }

            return curStudy;
        }

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Insert(Setting entity)
        {
            _context.Settings.Add(entity);
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Update(Setting entity)
        {
            var setting = _context.Settings.FirstOrDefault(s => s.Id == entity.Id);
            if (setting != null)
            {
                setting.IsActive = entity.IsActive;
                setting.Name = entity.Name;
                setting.SortOrder = entity.SortOrder;
                setting.Status = entity.Status;
                setting.Description = entity.Description;
                setting.UpdatedBy = entity.UpdatedBy ?? Thread.CurrentPrincipal.Identity.Name;
                setting.UpdatedOn = DateTime.UtcNow;
            }
        }

        #endregion
    }
}