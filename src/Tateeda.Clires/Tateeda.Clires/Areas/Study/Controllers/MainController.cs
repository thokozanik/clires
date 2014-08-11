using System.Web.Mvc;
using Tateeda.Clires.System;

namespace Tateeda.Clires.Areas.Study.Controllers
{
    [Authorize]//(Roles = UserRollAccess.APP_USER)]
    public class MainController : BaseController
    {
        public MainController()
        {

        }
        //
        // GET: /Study/Main/

        public ActionResult Index()
        {
            return View();
        }

    }
}
