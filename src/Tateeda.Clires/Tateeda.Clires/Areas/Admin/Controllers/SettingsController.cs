
namespace Tateeda.Clires.Areas.Admin.Controllers
{
	using global::System.Globalization;
	using global::System.Web.Mvc;

	using Tateeda.Clires.Core.Data.EF;
	using Tateeda.Clires.Core.Data.Enums;
	using Tateeda.Clires.Data.UOW;
	using Tateeda.Clires.System;

	using DateTime = global::System.DateTime;
	using Thread = global::System.Threading.Thread;

	[Authorize(Roles = GlobalVariables.RoleSystemAdmin)]
	public class SettingsController : BaseController
	{
		public ActionResult Index()
		{
			return View();
		}

		public JsonResult SetDefaultStudy(int studyId)
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var setting = adminUow.SettingsRepository.GetByName("CurrentStudyId");

				if (setting == null)
				{
					setting = new Setting
						{
							CreatedBy = Thread.CurrentPrincipal.Identity.Name,
							CreatedOn = DateTime.UtcNow,
							Description = "Default App Study",
							IsActive = true,
							Name = "CurrentStudyId",
							SortOrder = 0,
							Status = (int)EntityStatusType.Current,
							Value = studyId.ToString(CultureInfo.InvariantCulture)
						};
					adminUow.SettingsRepository.Insert((Setting)setting);
				}
				else
				{
					setting.Value = studyId.ToString(CultureInfo.InvariantCulture);
					setting.UpdatedBy = Thread.CurrentPrincipal.Identity.Name;
					setting.UpdatedOn = DateTime.UtcNow;
					adminUow.SettingsRepository.Update((Setting)setting);
				}
				adminUow.Commit();
			}

			return Json("Default Study is set", JsonRequestBehavior.AllowGet);
		}
	}

	public class Message
	{
		public string Text { get; set; }

		public string Error { get; set; }
	}
}