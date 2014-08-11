using System.Web.Mvc;
using Tateeda.Clires.System;

namespace Tateeda.Clires.Areas.Admin.Controllers
{
    [Authorize]
    public class SubjectsController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}