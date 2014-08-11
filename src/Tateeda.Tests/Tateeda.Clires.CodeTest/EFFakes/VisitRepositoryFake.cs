using System.Collections.Generic;
using System.Linq;
using Tateeda.Clires.Core.Data.EF;
using Tateeda.Clires.Core.Visits;

namespace Tateeda.Clires.CodeTest.EFFakes {
    internal class VisitRepositoryFake : IVisitRepository
    {
        private List<Visit> _visits;

        public VisitRepositoryFake()
        {
            _visits = new List<Visit>();
            _visits.Add(new Visit {Id = 1, Name = "Test Only", IsActive = true, Status = 1});
            _visits.Add(new Visit { Id = 2, Name = "Test Only", IsActive = true, Status = 1 });
            _visits.Add(new Visit { Id = 3, Name = "Test Only", IsActive = true, Status = 1 });
        }

        #region Implementation of IRepository<Visit>

        public IQueryable<Visit> All { get; private set; }

        public Visit GetById(object id)
        {
            return _visits.FirstOrDefault(v => v.Id == (int)id);
        }

        public void Insert(Visit entity)
        {
            _visits.Add(entity);
        }

        public void Update(Visit entity)
        {
            var cur = _visits.FirstOrDefault(v => v.Id == entity.Id);
            _visits.Remove(cur);
            _visits.Add(entity);
        }

        public void Delete(Visit entity)
        {
            _visits.Remove(entity);
        }

        public void Commit()
        {

        }

        #endregion

        #region Implementation of IVisitRepository

        public IEnumerable<IVisit> GetAllVisits(int studyId, bool all = false)
        {
            return _visits;
        }

        public IEnumerable<IForm> GetVisitForms(int visitId, bool all = false)
        {
            var visForms = _visits.Select(v => v.VisitForms);

            return (from IVisitForm f in visForms select f.Form).Cast<IForm>().ToList();
        }

        public void ClearVisitFormsAssosiation(int visitId)
        {

        }

        public void AssosiateVisitForms(int visitId, IEnumerable<IForm> forms)
        {

        }

        #endregion

        #region Implementation of IDisposable

        public void Dispose()
        {
            
        }

        #endregion
    }
}
