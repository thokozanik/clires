using System.Collections.Generic;
using System.Linq;
using Tateeda.Clires.Core.Data.EF;
using Tateeda.Clires.Core.Utility;

namespace Tateeda.Clires.CodeTest.EFFakes
{
    internal class SettingsRepositoryFake : ISettingsRepository
    {
        private List<Setting> _settings = new List<Setting>();

        #region Implementation of IRepository<Setting>

        public IQueryable<Setting> All { get; private set; }

        public Setting GetById(object id)
        {
            return _settings.FirstOrDefault(s => s.Id == (int) id);
        }

        public void Insert(Setting entity)
        {
            throw new global::System.NotImplementedException();
        }

        public void Update(Setting entity)
        {
            throw new global::System.NotImplementedException();
        }

        public void Delete(Setting entity)
        {
            throw new global::System.NotImplementedException();
        }

        public void Commit()
        {
           
        }

        #endregion

        #region Implementation of ISettingsRepository

        public ISetting GetCurrentStudy()
        {
            return new Setting { Name = "CurrentStudyId", Value = "1" };
        }

        public ISetting GetByName(string name)
        {
            throw new global::System.NotImplementedException();
        }

        #endregion
    }
}