namespace Tateeda.Clires.Core.StudySetup
{
    using System;
    using System.Linq;
    using System.Threading;

    using Tateeda.Clires.Core.Data.EF;

    public class StudySetupRepository : IStudySetupRepository
    {
        private readonly IDbContext _context;
        public StudySetupRepository(IDbContext context)
        {
            _context = context;
            All = _context.StudySetupMaps.AsQueryable();
        }

        #region Implementation of IRepository<StudySetupMap>

        public IQueryable<StudySetupMap> All { get; private set; }

        public void Delete(StudySetupMap entity)
        {
            _context.StudySetupMaps.Remove(entity);
        }

        public StudySetupMap GetById(object id)
        {
            return All.FirstOrDefault(m => m.Id == (int)id);
        }

        public void Insert(StudySetupMap entity)
        {
            _context.StudySetupMaps.Add(entity);
        }

        public void Update(StudySetupMap entity)
        {
            var currnt = All.FirstOrDefault(m => m.Id == entity.Id);
            if (currnt != null)
            {
                currnt.UpdatedBy = Thread.CurrentPrincipal.Identity.Name;
                currnt.UpdatedOn = DateTime.UtcNow;
                currnt.IsActive = entity.IsActive;
                currnt.OrganizationId = entity.OrganizationId;
                currnt.StepSetupStatus = entity.StepSetupStatus;
                currnt.StudyId = entity.StudyId;
                currnt.StudySetupStepId = entity.StudySetupStepId;
            }
        }

        #endregion
    }
}