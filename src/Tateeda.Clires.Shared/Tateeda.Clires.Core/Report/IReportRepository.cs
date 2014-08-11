using System.Collections.Generic;

namespace Tateeda.Clires.Core.Report
{
	public interface IReportRepository
	{
		/// <summary>
		/// If null show all. If true - only active. If false only terminated
		/// </summary>
		/// <param name="active"></param>
		/// <returns></returns>
		int GetTotalSubjectsCount(bool? active);

		/// <summary>
		/// Total number of subjects per study
		/// </summary>
		/// <param name="studyId"></param>
		/// <returns></returns>
		int GetTotalSubjectsPerStydy(int studyId);

		/// <summary>
		/// Show Total subjects per study and site
		/// </summary>
		/// <param name="studyId"></param>
		/// <param name="siteId"></param>
		/// <returns></returns>
		Dictionary<string, int> GetTotalSubjectsPerStudyForAllSites(int studyId);

		/// <summary>
		/// Show Total Active subjects per study and site
		/// </summary>
		/// <param name="studyId"></param>
		/// <param name="siteId"></param>
		/// <returns></returns>
		Dictionary<string, int> GetTotalActiveSubjectsPerStudyForAllSites(int studyId);

		/// <summary>
		/// Total number of completed visits per site
		/// </summary>
		/// <param name="siteId"></param>
		/// <returns></returns>
		Dictionary<string, int> GetTotalCompletedAppointmentsPerStudy(int studyId);

		Dictionary<string, int> GetTotalInProgressAppointmentsPerStudy(int studyId);

		Dictionary<string, int> GetTotalScheduledAppointmentsPerStudy(int studyId);

		Dictionary<string, int> GetTotalCompletedFormsPerStudy(int studyId);

		Dictionary<string, int> GetTotalInProgressFormsPerStudy(int studyId);
	}
}