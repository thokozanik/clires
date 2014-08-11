// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MedicationController.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the MedicationController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Tateeda.Clires.Areas.Admin.Controllers
{
    using global::System.Web.Mvc;

    using Tateeda.Clires.Areas.Admin.Model.Drugs;
    using Tateeda.Clires.Data.UOW;
    using Tateeda.Clires.System;

    /// <summary>
    /// The medication controller.
    /// </summary>
    [Authorize]
    public class MedicationController : BaseController
    {

        #region Public Methods and Operators

        /// <summary>
        /// The delete drug.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        [HttpPost]
        public JsonResult DeleteDrug(int id)
        {
            return Json("alert('need to finish it...'); OnComplete();", JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// The delete drug category.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        [HttpPost]
        public JsonResult DeleteDrugCategory(int id)
        {
            return Json("alert('need to finish it...'); OnComplete();", JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// The delete drug class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        [HttpPost]
        public JsonResult DeleteDrugClass(int id)
        {
            return Json("alert('need to finish it...'); OnComplete();", JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// The edit drug.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        [HttpPost]
        public JsonResult EditDrug(DrugViewModel model)
        {
            return Json("alert('need to finish it...'); OnComplete();", JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// The edit drug category.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        [HttpPost]
        public JsonResult EditDrugCategory(DrugCategoryViewModel model)
        {
            return Json("alert('need to finish it...'); OnComplete();", JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// The edit drug class.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        [HttpPost]
        public JsonResult EditDrugClass(DrugClassViewModel model)
        {
            return Json("alert('need to finish it...'); OnComplete();", JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        #endregion
    }
}