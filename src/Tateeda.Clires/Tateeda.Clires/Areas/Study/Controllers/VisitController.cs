// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VisitController.cs" company="">
//   
// </copyright>
// <summary>
//   The visit controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Areas.Study.Controllers
{
	using global::System;

	using global::System.Collections.Generic;

	using global::System.Linq;

	using global::System.Web.Mvc;

	using Tateeda.Clires.Areas.Subject.Model;
	using Tateeda.Clires.Core.Data.EF;
	using Tateeda.Clires.Core.Data.Enums;
	using Tateeda.Clires.Data.UOW;
	using Tateeda.Clires.Extensions;
	using Tateeda.Clires.System;

	/// <summary>
	/// The visit controller.
	/// </summary>
	[Authorize(Roles = GlobalVariables.RoleAppUser)]
	public class VisitController : BaseController
	{
		#region Public Methods and Operators

		/// <summary>
		/// The add subject drug.
		/// </summary>
		/// <param name="drug">
		/// The drug.
		/// </param>
		/// <returns>
		/// The <see cref="JsonResult"/>.
		/// </returns>
		public JsonResult AddSubjectDrug(SubjectDrug drug, string searchDrugName)
		{
			drug.CreatedBy = User.Identity.Name;
			drug.CreatedOn = DateTime.UtcNow;
			drug.IsActive = true;
			drug.Status = (int)EntityStatusType.Current;

			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				try
				{
					adminUow.SubjectRepository.AddSubjectDrug(drug);
					adminUow.Commit();
				}
				catch (Exception ex)
				{
					_logger.ErrorException("Adding drug error.", ex);

					var newDrug = new Drug
						{
							Name = searchDrugName,
							CreatedBy = this.User.Identity.Name,
							CreatedOn = DateTime.UtcNow,
							IsActive = true,
							Status = (int)EntityStatusType.Current,
							StudyId = DefaultStudyId
						};

					const int OtherDrugCategoryId = 10; //TODO: Review this
					newDrug.DrugClassId = OtherDrugCategoryId; //OTHER Drug category
					adminUow.DrugsRepository.Insert(newDrug);
					drug.Id = newDrug.Id;
					adminUow.SubjectRepository.AddSubjectDrug(drug);
					adminUow.Commit();
				}
			}

			return Json("showMessage('historyMsg', 'Drug is added', 5000); stdvis.vm.clearInput();", JsonRequestBehavior.DenyGet);
		}

		// GET: /Study/Visit/

		/// <summary>
		/// The form submission.
		/// </summary>
		/// <param name="fid">
		/// The id is Form Id 
		/// </param>
		/// <param name="vid">
		/// The vid - is Visit Id 
		/// </param>
		/// <returns>
		/// The <see cref="ActionResult"/> . 
		/// </returns>
		public ActionResult FormSubmission(int fid, int vid)
		{
			ViewBag.FormId = fid;
			ViewBag.AppointmentId = vid;
			ViewBag.VisitId = vid;
			ViewBag.AppUserId = CurrentAppUser == null ? 0 : CurrentAppUser.Id;

			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var appt = adminUow.AppointmentRepository.GetById(vid);
				var apptForm = adminUow.AppointmentRepository.GetAppointmentForm(vid, fid);
				var apptFormId = apptForm != null ? apptForm.Id : 0;

				ViewBag.AppointmentFormId = apptFormId;
				ViewBag.SubjectId = appt != null ? appt.SubjectId : 0;

				return View(apptForm);
			}
		}

		/// <summary>
		/// The index.
		/// </summary>
		/// <param name="id">
		/// The appointment ID 
		/// </param>
		/// <returns>
		/// The <see cref="ActionResult"/> . 
		/// </returns>
		public ActionResult Index(int id)
		{
			var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>();
			{
				var appt = adminUow.AppointmentRepository.GetById(id);
				if (appt == null)
				{
					return RedirectToAction("Index", "Tasks", new { area = "Dashboard" });
				}

				ViewBag.AppointementId = id;
				ViewBag.SubjectId = appt.SubjectId;
				ViewBag.AppUserId = CurrentAppUser == null ? 0 : CurrentAppUser.Id;

				var reqForm = appt.Visit.VisitForms;
				var compForm = appt.AppointmentForms.Where(f => f.FormStatusTypeId == (int)ApptFormStatusType.Completed).ToList();
				var progForm = appt.AppointmentForms.Where(f => f.FormStatusTypeId == (int)ApptFormStatusType.InProgress).ToList();
				var removeFromReq = new List<int>();

				foreach (var frm in reqForm)
				{
					var item = compForm.FirstOrDefault(f => f.FormId == frm.FormId) ?? progForm.FirstOrDefault(f => f.FormId == frm.FormId);
					if (item != null)
					{
						removeFromReq.Add(item.FormId);
					}
				}

				foreach (var i in removeFromReq)
				{
					var frm = reqForm.FirstOrDefault(f => f.FormId == i);
					reqForm.Remove(frm);
				}

				var subj = adminUow.SubjectRepository.GetById(appt.SubjectId);
				var subjModel = subj.ToModel();
				var model = new SubjectVisitViewModel
					{
						Appointment = appt.ToModel(),
						Subject = subjModel,
						Visit = appt.Visit.ToModel(),
						RequiredForms = reqForm.Select(f => f.Form.ToModel()),
						CompletedForms = compForm.Select(f => f.Form.ToModel()),
						InProgressForms = progForm.Select(f => f.Form.ToModel()),
						Medications = new List<ISubjectDrug>(),
						SubjectFiles = subj.Files.Select(f => f.ToModel())
					};

				adminUow.Commit();
				return View(model);
			}
		}

		/// <summary>
		/// The save continue.
		/// </summary>
		/// <param name="frm">
		/// The frm.
		/// </param>
		/// <returns>
		/// The <see cref="ActionResult"/>.
		/// </returns>
		public ActionResult SaveContinue(FormCollection frm)
		{
			IAppointmentForm apptForm = CreateAppointmentForm(frm, ApptFormStatusType.InProgress);

			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				adminUow.AppointmentRepository.CreateOrUpdateAppointmentForm(apptForm);
				var appointment = adminUow.AppointmentRepository.GetById(apptForm.AppointmentId);
				appointment.Status = (int)AppointmentStatusType.InProgress;
				adminUow.AppointmentRepository.Update(appointment);
				adminUow.Commit();
			}
			UnlockSubmittedForm(apptForm);
			return RedirectToAction("FormSubmission", new { @fid = frm["FormId"], @vid = frm["VisitId"] });
		}

		/// <summary>
		/// The save finish.
		/// </summary>
		/// <param name="frm">
		/// The frm.
		/// </param>
		/// <returns>
		/// The <see cref="ActionResult"/>.
		/// </returns>
		public ActionResult SaveFinish(FormCollection frm)
		{
			var apptForm = CreateAppointmentForm(frm, ApptFormStatusType.Completed);

			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				adminUow.AppointmentRepository.CreateOrUpdateAppointmentForm(apptForm);

				var appointment = adminUow.AppointmentRepository.GetById(apptForm.AppointmentId);
				appointment.Status = (int)AppointmentStatusType.InProgress;
				adminUow.AppointmentRepository.Update(appointment);
				adminUow.Commit();
			}
			UnlockSubmittedForm(apptForm);

			return RedirectToAction("FormSubmission", new { @fid = frm["FormId"], @vid = frm["VisitId"] });
		}

		/// <summary>
		/// The save request data.
		/// </summary>
		/// <param name="frm">
		/// The frm.
		/// </param>
		/// <returns>
		/// The <see cref="ActionResult"/>.
		/// </returns>
		public ActionResult SaveRequestData(FormCollection frm)
		{
			IAppointmentForm apptForm = CreateAppointmentForm(frm, ApptFormStatusType.NeedsApproval);

			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				adminUow.AppointmentRepository.CreateOrUpdateAppointmentForm(apptForm);
				var appointment = adminUow.AppointmentRepository.GetById(apptForm.AppointmentId);
				appointment.Status = (int)AppointmentStatusType.InProgress;
				adminUow.AppointmentRepository.Update(appointment);
				adminUow.Commit();
			}
			UnlockSubmittedForm(apptForm);
			return RedirectToAction("FormSubmission", new { @fid = frm["FormId"], @vid = frm["VisitId"] });
		}

		#endregion

		#region Methods

		/// <summary>
		/// The create appointment form.
		/// </summary>
		/// <param name="frm">
		/// The frm.
		/// </param>
		/// <param name="status">
		/// The status.
		/// </param>
		/// <returns>
		/// The <see cref="IAppointmentForm"/>.
		/// </returns>
		private IAppointmentForm CreateAppointmentForm(FormCollection frm, ApptFormStatusType status)
		{
			IAppointmentForm apptForm = null;
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				apptForm = GetAppointmentForm(frm, status, adminUow);

				// TODO: Not sure but will clear all answers for now..
				apptForm.FormAnswers.Clear();

				var qKeys = frm.AllKeys.Where(k => k.StartsWith("q_"));
				foreach (var k in qKeys)
				{
					var qId = Convert.ToInt32(k.Split(new[] { "q_" }, StringSplitOptions.RemoveEmptyEntries)[0]);
					var answer = frm[k];
					var question = adminUow.FormRepository.GetQuestion(qId);

					if (question.CssType.CssClassName.Equals("checkbox"))
					{
						var chOptions = answer.Split(new[] { ',' });

						foreach (var ch in chOptions)
						{
							var frmAnswer = GetFormAnswerAnswerId(ch, question.CssType.CssClassName);
							frmAnswer.QuestionId = qId;
							apptForm.FormAnswers.Add(frmAnswer);
						}
					}
					else
					{
						var frmAnswer = GetFormAnswerAnswerId(answer, question.CssType.CssClassName);
						frmAnswer.QuestionId = qId;
						apptForm.FormAnswers.Add(frmAnswer);
					}
				}
				adminUow.Commit();
			}
			return apptForm;
		}

		/// <summary>
		/// The get appointment form.
		/// </summary>
		/// <param name="frm">
		/// The frm.
		/// </param>
		/// <param name="status">
		/// The status.
		/// </param>
		/// <returns>
		/// The <see cref="IAppointmentForm"/>.
		/// </returns>
		private IAppointmentForm GetAppointmentForm(FormCollection frm, ApptFormStatusType status, IAdminUnitOfWork adminUow)
		{
			var apptFormId = Convert.ToInt32(frm["AppointmentFormId"]);
			var apptForm = new AppointmentForm
				{
					FormId = Convert.ToInt32(frm["FormId"]),
					AppointmentId = Convert.ToInt32(frm["AppointmentId"]),
					CreatedBy = User.Identity.Name,
					CreatedOn = DateTime.UtcNow,
					IsActive = true
				};

			if (apptFormId > 0)
			{
				//var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>();

				apptForm = adminUow.AppointmentRepository.GetAppointmentForm(apptFormId) as AppointmentForm;
			}

			if (apptForm != null)
			{
				apptForm.Notes = frm["Notes"];
				apptForm.Status = (int)EntityStatusType.Current;
				apptForm.FormStatusTypeId = (int)status;
				apptForm.UpdatedBy = this.User.Identity.Name;
				apptForm.UpdatedOn = DateTime.UtcNow;
			}

			return apptForm;
		}

		/// <summary>
		/// The get form answer answer id.
		/// </summary>
		/// <param name="answer">
		/// The answer.
		/// </param>
		/// <returns>
		/// The <see cref="FormAnswer"/>.
		/// </returns>
		private FormAnswer GetFormAnswerAnswerId(string answer, string inputKind)
		{
			var frmAnswer = new FormAnswer
				{
					CreatedBy = User.Identity.Name,
					CreatedOn = DateTime.UtcNow,
					UpdatedBy = User.Identity.Name,
					UpdatedOn = DateTime.UtcNow
				};
			int answerId;
			int.TryParse(answer, out answerId);
			if (answerId > 0 && !inputKind.Contains("number"))
			{
				frmAnswer.AnswerId = answerId;
			}
			else
			{
				frmAnswer.FreeTextAnswer = answer;
			}

			return frmAnswer;
		}

		/// <summary>
		/// The unlock submitted form.
		/// </summary>
		/// <param name="apptForm">
		/// The appt form.
		/// </param>
		private void UnlockSubmittedForm(IAppointmentForm apptForm)
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				int subjectId = adminUow.AppointmentRepository.GetById(apptForm.AppointmentId).SubjectId;

				adminUow.FormRepository.UnlockFormFromReadOnly(
					new FormInProcess
						{
							AppUserId = CurrentAppUser == null ? 0 : CurrentAppUser.Id,
							FormId = apptForm.FormId,
							IsLocked = false,
							MaxLockTimeMin = 0,
							OpenendOn = DateTime.UtcNow,
							SubjectId = subjectId
						});
			}
		}

		#endregion
	}
}