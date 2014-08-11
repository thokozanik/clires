namespace Tateeda.Clires.Controllers
{
    using global::System;
    using global::System.Web.Mvc;
    using Tateeda.Clires.System;

    public class ErrorController : BaseController
    {
        //
        // GET: /Error/

        public ActionResult Index(int statusCode, Exception exception)
        {
            ViewBag.LayoutLink = LayoutLink;
            Response.StatusCode = statusCode;
            return View();
        }

    }
}
