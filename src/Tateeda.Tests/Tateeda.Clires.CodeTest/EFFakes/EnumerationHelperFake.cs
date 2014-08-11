using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Tateeda.Clires.Utility;

namespace Tateeda.Clires.CodeTest.EFFakes {
    internal class EnumerationHelperFake : IEnumerationHelper {
        #region Implementation of IEnumerationHelper

        public IEnumerable<SelectListItem> GetOptions(int typeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SelectListItem>GetStudies(bool showAll)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SelectListItem>GetSites()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SelectListItem>GetTimeZones()
        {
            throw new NotImplementedException();
        }

        public MultiSelectList GetFormQuestions(int formId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SelectListItem>GetSiteSubjects(int studyId, int siteId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SelectListItem>GetSiteUsers(int siteId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SelectListItem>GetStudyArms(int studyId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
