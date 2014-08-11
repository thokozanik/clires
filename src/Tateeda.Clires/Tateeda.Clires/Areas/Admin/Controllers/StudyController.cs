namespace Tateeda.Clires.Areas.Admin.Controllers
{
    #region - Usings

    using Tateeda.Clires.Areas.Admin.Model.Study;
    using Tateeda.Clires.Data.UOW;

    using global::System;
    using global::System.Threading;
    using global::System.Web.Mvc;

    using Tateeda.Clires.Core.Data.EF;
    using Tateeda.Clires.Core.Data.Enums;
    using Tateeda.Clires.Core.Study;

    using Tateeda.Clires.Extensions;

    using Tateeda.Clires.System;

    #endregion

    [Authorize(Roles = GlobalVariables.RoleSystemAdmin)]
    public class StudyController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult NewStudy(StudyViewModel study)
        {
            if (ModelState.IsValid)
            {
                if (study.Id > 0)
                {
                    EditStudy(study);
                    //return RedirectToAction("Index");
                    return Json("success", JsonRequestBehavior.AllowGet);
                }

                study.CreatedBy = Thread.CurrentPrincipal.Identity.Name;
                study.CreatedOn = DateTime.UtcNow;
                study.Status = (int)EntityStatusType.Current;

                using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
                {
                    adminUow.StudyRepository.Insert(study.ToEntity());
                    adminUow.Commit();
                }
            }
            //return RedirectToAction("Index");
            return Json("success", JsonRequestBehavior.AllowGet);
        }

        public ActionResult StudySites()
        {
            return View();
        }

        private void EditStudy(StudyViewModel study)
        {
            study.Status = (int)EntityStatusType.Current;
            study.UpdatedBy = Thread.CurrentPrincipal.Identity.Name;
            study.UpdatedOn = DateTime.UtcNow;

            using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
            {
                adminUow.StudyRepository.Update(study.ToEntity());
                adminUow.Commit();
            }
        }

        public ActionResult Arms()
        {
            return View(new ArmViewModel());
        }

        public JsonResult NewArm(ArmViewModel arm)
        {
            using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
            {
                adminUow.StudyRepository.CreateOrUpdateArm(arm.ToEntity());
                adminUow.Commit();
                return Json("studyArms.vm.getStudyArms(0);", JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult VisitSequence()
        {
            return View();
        }

        public JsonResult AddStep(int armId, string stepName, string description)
        {
            using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
            {
                adminUow.StudyRepository.CreateArmStep(armId, stepName, description);
                adminUow.Commit();
                return Json("loadSteps()", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult AddStepVisits(int stepId, int visitId, int deviation, int daysFromBase, int sortOrder, bool isTermination)
        {
            var seq = new VisitStepVisitSequence
                {
                    DaysFromBase = daysFromBase,
                    Deviation = deviation,
                    IsActive = true,
                    VisitId = visitId,
                    VisitStepId = stepId,
                    SortOrder = sortOrder,
                    IsTermination = isTermination
                };

            using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
            {
                adminUow.StudyRepository.AddStepVisits(seq);
                adminUow.Commit();
            }
            return Json(stepId, JsonRequestBehavior.DenyGet);
        }

        public JsonResult DeleteStepVisits(int stepId, int visitId)
        {
            var seq = new VisitStepVisitSequence
            {
                VisitId = visitId,
                VisitStepId = stepId
            };

            using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
            {
                adminUow.StudyRepository.DeleteStepVisits(seq);
                adminUow.Commit();
            }

            return Json(stepId, JsonRequestBehavior.DenyGet);
        }

        public JsonResult UpdateStepVisits(int stepId, int visitId, int deviation, int daysFromBase, int sortOrder, bool isTermination)
        {
            var seq = new VisitStepVisitSequence
            {
                DaysFromBase = daysFromBase,
                Deviation = deviation,
                IsActive = true,
                VisitId = visitId,
                VisitStepId = stepId,
                SortOrder = sortOrder,
                IsTermination = isTermination
            };
            using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
            {
                adminUow.StudyRepository.UpdateStepVisits(seq);
                adminUow.Commit();
            }
            return Json(stepId, JsonRequestBehavior.DenyGet);
        }

    }
}