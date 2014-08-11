using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tateeda.Clires.Core.Data.EF;
using Tateeda.Clires.Core.Drugs;

namespace Tateeda.Clires.CodeTest.EFFakes {
    internal class DrugsRepositoryFake : IDrugsRepository  {
        #region Implementation of IRepository<Drug>

        public IQueryable<Drug> All { get; private set; }
        public Drug GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Drug entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Drug entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Drug entity)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IDrugsRepository

        public IEnumerable<IDrugCategory> GetAllDrugCategories()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IDrugClass> GetDrugClasses(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IDrug> GetClassDrugs(int classId, int pageIndex, out int totalRecords, int pageSize = 20)
        {
            throw new NotImplementedException();
        }

        public void CreateDrugCategory(IDrugCategory category)
        {
            throw new NotImplementedException();
        }

        public void CreateDrugClass(IDrugClass drugClass)
        {
            throw new NotImplementedException();
        }

        public void DeleteDrugCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void DeleteDrugClass(int classId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IDrug> FindByName(string text, int maxRetur)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IDisposable

        public void Dispose()
        {
            
        }

        #endregion
    }
}
