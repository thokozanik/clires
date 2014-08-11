namespace Tateeda.Clires.Areas.Admin.Controllers
{
	using Core.Data.Enums;
	using Core.Study;

	using Tateeda.Clires.Data.UOW;

	using global::System.Web.Mvc;
	using EF = Core.Data.EF;
	using System;

	[Authorize(Roles = GlobalVariables.RoleSystemAdmin)]
	public class SitesController : BaseController
	{
		public ActionResult Index()
		{
			return View();
		}

		public JsonResult CreateSite(EF.Site site, int studyId)
		{
			site.Status = (int)EntityStatusType.Current;
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				if (site.Id > 0)
				{
					adminUow.StudyRepository.UpdateSite(site, studyId);
				}
				else
				{
					adminUow.StudyRepository.CreateSite(site, studyId);
				}

				adminUow.Commit();
			}
			return Json("site.vm.getSites()", JsonRequestBehavior.DenyGet);
		}
	}
}