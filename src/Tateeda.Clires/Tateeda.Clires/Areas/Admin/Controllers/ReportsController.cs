using Tateeda.Clires.Utility;

namespace Tateeda.Clires.Areas.Admin.Controllers
{
	using global::System.Web.Mvc;
	using Model.Report;
	using Data.UOW;
	using System;

	public class ReportsController : BaseController
	{
		[Authorize]
		public ActionResult Index()
		{
			var model = new ReportModel { SubjectsReportModel = new SubjectsReportModel() };
			Common.FillReportModel(model, DefaultStudyId);
			return View(model);
		}
	}
}