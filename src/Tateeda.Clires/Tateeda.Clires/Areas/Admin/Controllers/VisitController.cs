namespace Tateeda.Clires.Areas.Admin.Controllers
{
    #region Usings

    using Tateeda.Clires.Data.UOW;

    using global::System;

    using global::System.Threading;

    using global::System.Web.Mvc;

    using Tateeda.Clires.Areas.Admin.Model.Study;
    using Tateeda.Clires.Core.Data.Enums;
    using Tateeda.Clires.Core.Visits;
    using Tateeda.Clires.Extensions;
    using Tateeda.Clires.System;

    #endregion

    [Authorize(Roles = GlobalVariables.RoleSystemAdmin)]
    public class VisitController : BaseController
    {
        public ActionResult Index()
        {
            var model = new VisitViewModel();
            return View(model);
        }

        public JsonResult CreateVisit(VisitViewModel model)
        {
            //ModelState.Remove("StudyId");
            //model.StudyId = GlobalVariables.CurrentStudyId;

            if (model.Id == 0)
            {
                ModelState.Remove("Id");
                TryValidateModel(model);
            }

            if (!ModelState.IsValid)
            {
                return Json("alert('Error!');", JsonRequestBehavior.DenyGet);
            }

            if (model.ParentVisitId < 1) model.ParentVisitId = null;

            if (model.Id > 0)
            {
                return UpdateVisit(model);
            }

            var visit = model.ToEntity();
            visit.CreatedOn = DateTime.UtcNow;
            visit.CreatedBy = Thread.CurrentPrincipal.Identity.Name;
            visit.Status = (int)EntityStatusType.Current;

            using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
            {
                adminUow.VisitRepository.Insert(visit);
                adminUow.Commit();
            }
            return Json("vis.vm.loadVisits(" + model.StudyId + ");", JsonRequestBehavior.DenyGet);
        }

        private JsonResult UpdateVisit(VisitViewModel model)
        {
            using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
            {
                var visit = model.ToEntity();
                visit.UpdatedOn = DateTime.UtcNow;
                visit.UpdatedBy = Thread.CurrentPrincipal.Identity.Name;
                visit.Status = (int)EntityStatusType.Current;
                if (model.ParentVisitId > 0)
                {
                    var parent = adminUow.VisitRepository.GetById(model.ParentVisitId);
                    if (parent != null) parent.HasChild = true;
                }
                else
                {
                    visit.ParentVisitId = null;
                }
                adminUow.VisitRepository.Update(visit);
                adminUow.Commit();

                return Json("vis.vm.loadVisits(" + model.StudyId + ");", JsonRequestBehavior.DenyGet);
            }
        }
    }
}
