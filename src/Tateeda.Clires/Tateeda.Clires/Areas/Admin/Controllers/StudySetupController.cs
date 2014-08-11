namespace Tateeda.Clires.Areas.Admin.Controllers
{
    using global::System.Web.Mvc;

    using Tateeda.Clires.System;

    [Authorize(Roles = GlobalVariables.RoleSystemAdmin)]
    public class StudySetupController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}
