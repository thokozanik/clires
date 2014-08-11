namespace Tateeda.Clires.Utility
{
    using global::System.Collections.Generic;
    using global::System.Web.Mvc;

    public interface IEnumerationHelper
    {
        IEnumerable<SelectListItem> GetOptions(int typeId);

        IEnumerable<SelectListItem> GetStudies(bool showAll);

        IEnumerable<SelectListItem> GetSites();

        IEnumerable<SelectListItem> GetTimeZones();

        MultiSelectList GetFormQuestions(int formId, int excludeQuestionId = 0);

        IEnumerable<SelectListItem> GetSiteSubjects(int studyId, int siteId);

        IEnumerable<SelectListItem> GetSiteUsers(int siteId);

        IEnumerable<SelectListItem> GetStudyArms(int studyId);
    }
}