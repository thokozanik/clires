#region

using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Tateeda.Clires.Areas.Admin.Model.Forms;
using Tateeda.Clires.Core.Data.Enums;
using Tateeda.Clires.Data.UOW;
using Tateeda.Clires.Extensions;
using Tateeda.Clires.System;
using Tateeda.Clires.Utility;

#endregion

namespace Tateeda.Clires.Areas.Admin.Controllers
{
    [Authorize(Roles = GlobalVariables.RoleSystemAdmin)]
    public class StudyFormsController : BaseController
    {
        #region - Import Forms Data -

        [HttpPost]
        public ActionResult ImportFormData(HttpPostedFileBase dataFile)
        {
            Common.ProcessFormImportFile(dataFile);

            return RedirectToAction("Index");
        }

        #endregion

        #region - Forms -

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PreviewForm(int id)
        {
            ViewBag.FormId = id;
            return View();
        }

        [ValidateInput(false)]
        public JsonResult CreateNewForm(FormViewModel form)
        {
            ModelState.Remove("Id");
            TryValidateModel(form);

            if (ModelState.IsValid)
            {
                form.Status = (int) EntityStatusType.Current;
                if (form.Id > 0)
                {
                    return EditForm(form);
                }

                using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
                {
                    adminUow.FormRepository.CreateNewForm(form);
                    adminUow.Commit();
                }
                var result = new List<string> {"success", form.StudyId.ToString(CultureInfo.InvariantCulture)};
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return Json("Form submission error. Please check all required fields", JsonRequestBehavior.AllowGet);
        }

        private JsonResult EditForm(FormViewModel form)
        {
            if (ModelState.IsValid)
            {
                using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
                {
                    adminUow.FormRepository.UpdateForm(form.ToEntity());
                    adminUow.Commit();
                }

                var result = new List<string> {"success", form.StudyId.ToString(CultureInfo.InvariantCulture)};
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return Json("Form submission error. Please check all required fields", JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region - Answers -

        [HttpPost]
        public ActionResult QuestoinAnswers(int questionId)
        {
            ViewBag.parentQuestionId = questionId;
            using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
            {
                var question = adminUow.FormRepository.GetQuestion(questionId);
                ViewBag.Question = question.QuestionText;
                ViewBag.FormId = question.FormId;
            }
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult CreateNewAnswer(AnswerViewModel answer)
        {
            ModelState.Remove("Id");
            TryValidateModel(answer);

            if (ModelState.IsValid)
            {
                answer.Status = (int) EntityStatusType.Current;
                if (answer.Id > 0) return EditAnswer(answer);

                answer.Header += string.Empty;
                answer.Trailer += string.Empty;
                answer.Directions += string.Empty;
                using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
                {
                    adminUow.FormRepository.CreateNewAnswer(answer.ToEntity());
                    adminUow.Commit();
                }
                return Json(answer.QuestionId, JsonRequestBehavior.AllowGet);
            }
            return Json("Form submission error. Please check all required fields", JsonRequestBehavior.AllowGet);
        }

        private JsonResult EditAnswer(AnswerViewModel answer)
        {
            answer.Header += string.Empty;
            answer.Trailer += string.Empty;
            answer.Directions += string.Empty;
            using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
            {
                adminUow.FormRepository.UpdateAnswer(answer);

                if (answer.ChildQuestionIds != null)
                {
                    adminUow.FormRepository.AddAnswerChildQuestionsMapping(answer.Id, answer.ChildQuestionIds);
                }
                else
                {
                    adminUow.FormRepository.AddAnswerChildQuestionsMapping(answer.Id, new List<int>());
                }
                adminUow.Commit();
            }
            return Json(answer.QuestionId, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region - Questions -

        [HttpPost]
        public ActionResult FormQuestions(int formId)
        {
            using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
            {
                ViewBag.FormName = adminUow.FormRepository.GetForm(formId).Title;
                ViewBag.parentFormId = formId;
            }
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult CreateNewFormQuestion(QuestionViewModel question)
        {
            ModelState.Remove("Id");
            TryValidateModel(question);

            if (ModelState.IsValid)
            {
                question.Status = (int) EntityStatusType.Current;
                if (question.Id > 0) return EditFormQuestion(question);

                question.Header += string.Empty;
                question.Trailer += string.Empty;
                question.Directions += string.Empty;
                using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
                {
                    adminUow.FormRepository.CreateNewQuestion(question);
                    adminUow.Commit();
                }
                return Json(question.FormId, JsonRequestBehavior.AllowGet);
            }
            return Json("Form submission error. Please check all required fields", JsonRequestBehavior.AllowGet);
        }

        private JsonResult EditFormQuestion(QuestionViewModel question)
        {
            if (ModelState.IsValid)
            {
                question.Header += string.Empty;
                question.Trailer += string.Empty;
                question.Directions += string.Empty;
                question.Status = (int) EntityStatusType.Current;
                using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
                {
                    adminUow.FormRepository.UpdateQuestion(question);
                    adminUow.Commit();
                }

                return Json("success", JsonRequestBehavior.AllowGet);
            }
            return Json("Form submission error. Please check all required fields", JsonRequestBehavior.AllowGet);
        }

        #endregion

        public FileResult ExportFormsData()
        {
            var header =
                @"StudyId,FormId,FormName,FormCode,FormTypeId,FormTitle,FormDirections,FormHeader,FormTrailer,FormIsFilledBySubject,FormShowTotalScore,FormLayoutTypeId,FormIsDoubleChecked,FormDescription,FormSortOrder,FormStatus,FormCreatedOn,FormCreatedBy,FormIsActive,FormNotifyOnChange,FormNotifyOnCompletion,QuestionId,QuestionFieldDataTypeId,QuestionText,QuestionCode,QuestionDirections,QuestionHeader,QuestionTrailer,QuestionIsRequired,QuestionParentQuestionId,QuestionIsParent,QuestionDescription,QuestionSortOrder,QuestionStatus,QuestionCreatedOn,QuestionCreatedBy,QuestionIsActive,AnswerId,AnswerOptionText,AnswerCode,AnswerScore,AnswerHeader,AnswerTrailer,AnswerDirections,AnswerSortOrder,AnswerStatus,AnswerCreatedOn,AnswerCreatedBy,AnswerIsActive";
            var sb = new StringBuilder();
            sb.AppendLine(header);
            using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
            {
                var allForms = adminUow.FormRepository.GetAllFormsPerStudy(DefaultStudyId == 0 ? 1 : DefaultStudyId);
                foreach (var form in allForms)
                {
                    foreach (var question in form.Questions)
                    {
                        foreach (var answer in question.Answers)
                        {
                            sb.AppendFormat(
                                "\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\",\"{12}\",\"{13}\",\"{14}\",\"{15}\",\"{16}\",\"{17}\",\"{18}\",\"{19}\",\"{20}\",\"{21}\",\"{22}\",\"{23}\",\"{24}\",\"{25}\",\"{26}\",\"{27}\",\"{28}\",\"{29}\",\"{30}\",\"{31}\",\"{32}\",\"{33}\",\"{34}\",\"{35}\",\"{36}\",\"{37}\",\"{38}\",\"{39}\",\"{40}\",\"{41}\",\"{42}\",\"{43}\",\"{44}\",\"{46}\",\"{46}\",\"{47}\",\"{48}\"\n",
                                form.StudyId,
                                form.Id,
                                form.Name,
                                form.Code,
                                form.FormTypeId,
                                form.Title,
                                form.Directions,
                                form.Header,
                                form.Trailer,
                                form.IsFilledBySubject,
                                form.ShowTotalScore,
                                form.LayoutTypeId,
                                form.IsDoubleChecked,
                                form.Description,
                                form.SortOrder,
                                form.Status,
                                form.CreatedOn,
                                form.CreatedBy,
                                form.IsActive,
                                form.NotifyOnChange,
                                form.NotifyOnCompletion,
                                question.Id,
                                question.FieldDataTypeId,
                                question.QuestionText,
                                question.Code,
                                question.Directions,
                                question.Header,
                                question.Trailer,
                                question.IsRequired,
                                question.ParentQuestionId,
                                question.IsParent,
                                question.Description,
                                question.SortOrder,
                                question.Status,
                                question.CreatedOn,
                                question.CreatedBy,
                                question.IsActive,
                                answer.Id,
                                answer.OptionText,
                                answer.Code,
                                answer.Score,
                                answer.Header,
                                answer.Trailer,
                                answer.Directions,
                                answer.SortOrder,
                                answer.Status,
                                answer.CreatedOn,
                                answer.CreatedBy,
                                answer.IsActive);
                        }
                    }
                }
            }

            byte[] context = Encoding.ASCII.GetBytes(sb.ToString());
            return new FileStreamResult(new MemoryStream(context), "text/csv");
        }
    }
}