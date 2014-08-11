using System.Collections.Generic;
using System.Linq;
using Tateeda.Clires.Core.Data.EF;
using Tateeda.Clires.Core.Utility;

namespace Tateeda.Clires.CodeTest.EFFakes
{
    internal class CodeRepositoryFake : ICodeRepository
    {
        #region Implementation of IRepository<Code>

        public IQueryable<Code> All { get; private set; }
        public Code GetById(object id)
        {
            throw new global::System.NotImplementedException();
        }

        public void Insert(Code entity)
        {
            throw new global::System.NotImplementedException();
        }

        public void Update(Code entity)
        {
            throw new global::System.NotImplementedException();
        }

        public void Delete(Code entity)
        {
            throw new global::System.NotImplementedException();
        }

        public void Commit()
        {
            throw new global::System.NotImplementedException();
        }

        #endregion

        #region Implementation of ICodeRepository

        public IEnumerable<ICode> GetFormTypes()
        {
            throw new global::System.NotImplementedException();
        }

        public IEnumerable<ICode> GetFormStatuses()
        {
            throw new global::System.NotImplementedException();
        }

        public IEnumerable<ICode> GetVisitTypes()
        {
            throw new global::System.NotImplementedException();
        }

        public IEnumerable<ICode> GetVisitStatuses()
        {
            throw new global::System.NotImplementedException();
        }

        public IEnumerable<ICode> GetFormLayoutTypes()
        {
            throw new global::System.NotImplementedException();
        }

        public IEnumerable<ICode> GetCodeTypeEnumeration(int typeId)
        {
            throw new global::System.NotImplementedException();
        }

        public IEnumerable<ICode> GetFieldDataTypes()
        {
            throw new global::System.NotImplementedException();
        }

        public IEnumerable<IStudy> GetStudyList(bool showAll)
        {
            throw new global::System.NotImplementedException();
        }

        public IEnumerable<IRole> GetRolesList()
        {
            throw new global::System.NotImplementedException();
        }

        public IEnumerable<ISite> GetSitesList()
        {
            throw new global::System.NotImplementedException();
        }

        public IEnumerable<ICode> GetGender()
        {
            throw new global::System.NotImplementedException();
        }

        public IEnumerable<ITimeZone> GetTimeZones()
        {
            throw new global::System.NotImplementedException();
        }

        public IEnumerable<ICountry> GetCountries()
        {
            throw new global::System.NotImplementedException();
        }

        public IEnumerable<IState> GetStates(int countryId)
        {
            throw new global::System.NotImplementedException();
        }

        public IEnumerable<ICode> GetPhoneTypes()
        {
            throw new global::System.NotImplementedException();
        }

        public IEnumerable<ICode> GetAddressTypes()
        {
            throw new global::System.NotImplementedException();
        }

        #endregion
    }
}