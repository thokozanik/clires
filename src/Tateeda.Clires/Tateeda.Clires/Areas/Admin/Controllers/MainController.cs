using System.Web.Mvc;
using Tateeda.Clires.System;

namespace Tateeda.Clires.Areas.Admin.Controllers
{
    [Authorize(Roles = GlobalVariables.RoleSystemAdmin)]
    public class MainController : BaseController
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}