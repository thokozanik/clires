namespace Tateeda.Clires.Areas.Subject.Controllers
{
    using Tateeda.Clires.Areas.Schedule.Model;

    using global::System.Collections.Generic;
    using global::System.Web.Mvc;

    using System;

    [Authorize(Roles = GlobalVariables.RoleAppUser)]
    public class AppointmentsController : BaseController
    {
        //
        // GET: /Subject/Appointments/

        /// <summary>
        /// Get all appointments for given subject Id
        /// </summary>
        /// <param name="id">subject id</param>
        /// <returns></returns>
        public ActionResult Index(int id)
        {
            var appts = new List<AppointmentViewModel>();
            return View(appts);
        }

    }
}
