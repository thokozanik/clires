namespace Tateeda.Clires.Controllers
{
	#region Usings

	using global::System;
	using global::System.Collections.Generic;
	using global::System.Linq;
	using global::System.Web.Mvc;
	using Areas.Admin.Model.Drugs;
	using Areas.Admin.Model.Forms;
	using Areas.Admin.Model.Matrix;
	using Areas.Admin.Model.Users;
	using Areas.Schedule.Model;
	using Core.Data.EF;
	using Core.Data.Enums;
	using Data.UOW;
	using Extensions;
	using System;
	using Utility;

	#endregion

	[Authorize]
	public class JsonController : BaseController
	{

		#region - Sites -
		public JsonResult GetSites()
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var sites = adminUow.CodeRepository.GetSitesList();

				if (User != null)
				{
					var name = global::System.Web.Security.Membership.GetUser(User.Identity.Name);
					if (User != null)
					{
						var user = adminUow.UserRepository.GetUser(new Guid(name.ProviderUserKey.ToString()));
						var appUser = user.AppUsers.FirstOrDefault();
						if (appUser != null && appUser.SiteId > 0)
						{
							sites = sites.Where(s => s.Id == appUser.SiteId);
						}
					}
				}
				sites = sites.ToList();
				var data = sites.Select(site => site.ToModel()).ToList();
				var json = Json(data, JsonRequestBehavior.AllowGet);
				return json;
			}
		}

		public JsonResult GetSiteUsers(int id)
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var roles = adminUow.CodeRepository.GetRolesList();
				var siteUsers = adminUow.UserRepository.GetSiteUsers(id);
				var data = new List<AppUserViewModel>();
				var list = roles as List<IRole> ?? roles.ToList();

				foreach (var user in siteUsers)
				{
					var u = user.ToModel();
					var role = list.FirstOrDefault(r => r.RoleId == user.RoleId);
					if (role != null)
					{
						u.RoleName = role.RoleName;
					}
					data.Add(u);
				}
				return Json(data, JsonRequestBehavior.AllowGet);
			}
		}

		public JsonResult GetStates(int id)
		{
			var helper = new EnumerationHelper();
			var data = helper.GetStates(id);
			return Json(data, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetStudies()
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var studies = adminUow.StudyRepository.GetAllStudies(true);
				var data = studies.Select(s => s.ToModel()).ToList();
				return Json(data, JsonRequestBehavior.AllowGet);
			}
		}

		/// <summary>
		/// Get arms per study
		/// </summary>
		/// <param name="id">Study ID</param>
		/// <returns></returns>
		public JsonResult GetArms(int id)
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var arms = adminUow.StudyRepository.GetStudyArms(id);
				var data = arms.ToList().Select(a => a.ToModel());
				return Json(data, JsonRequestBehavior.AllowGet);
			}
		}
		#endregion

		#region - Forms - Question - Answer -

		/// <summary>
		/// The get form.
		/// </summary>
		/// <param name="id">
		/// The id - Form ID
		/// </param>
		/// <returns>
		/// The <see cref="JsonResult"/>.
		/// </returns>
		public JsonResult GetForm(int id)
		{
			var fvm = GetFormViewModel(id);

			return Json(fvm, JsonRequestBehavior.AllowGet);
		}

		/// <summary>
		/// The get appointment form.
		/// </summary>
		/// <param name="id">
		/// The id - Appointment Form ID
		/// </param>
		/// <returns>
		/// The <see cref="JsonResult"/>.
		/// </returns>
		public JsonResult GetAppointmentForm(int id)
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var apptForm = adminUow.AppointmentRepository.GetAppointmentForm(id);
				var formId = apptForm != null ? apptForm.FormId : 0;
				var fvm = GetFormViewModel(formId);
				fvm.QuestionsViewModel = fvm.QuestionsViewModel.OrderBy(q => q.SortOrder).ToList();
				FillForm(fvm, apptForm);

				return Json(fvm, JsonRequestBehavior.AllowGet);
			}
		}

		private void FillForm(FormViewModel fvm, IAppointmentForm apptForm)
		{
			//fvm.Questions.OrderBy(q => q.SortOrder);

			fvm.ApptFormStatus = (ApptFormStatusType)apptForm.FormStatusTypeId;
			foreach (var a in apptForm.FormAnswers)
			{
				var question = fvm.QuestionsViewModel.FirstOrDefault(q => q.Id == a.QuestionId);
				if (question != null)
				{
					var answer = question.AnswersViewModel.FirstOrDefault(an => an.Id == a.AnswerId);
					if (answer != null)
					{
						answer.Selected = true;
						answer.FormAnswerId = a.Id;
						answer.SelectedId = a.AnswerId;
					}
					else
					{
						var ans = question.AnswersViewModel.FirstOrDefault();
						if (ans != null && ans.CssInputType == "checkbox" && !string.IsNullOrWhiteSpace(ans.AnswerText))
						{
							var answersList = ans.AnswerText.Split(new[] { ',' });
							foreach (var ch in answersList)
							{
								int chId;
								int.TryParse(ch, out chId);
								var box = question.AnswersViewModel.FirstOrDefault(item => item.Id == chId);
								if (box == null) continue;
								box.Selected = true;
								box.FormAnswerId = chId;
							}
						}
						else
						{
							if (ans != null)
							{
								ans.AnswerText = a.FreeTextAnswer;
								ans.FormAnswerId = a.Id;
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// The get form view model.
		/// </summary>
		/// <param name="id">
		/// The id - Form ID
		/// </param>
		/// <returns>
		/// The <see cref="FormViewModel"/>.
		/// </returns>
		private FormViewModel GetFormViewModel(int id)
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var form = adminUow.FormRepository.GetForm(id);
				if (form == null) return new FormViewModel();

				var fieldDataTypes = adminUow.CodeRepository.GetFieldDataTypes();

				var fvm = form.ToModel();

				fvm.QuestionsViewModel = new List<QuestionViewModel>();
				foreach (var q in form.Questions)
				{
					if (q.IsActive)
					{
						var questionVm = q.ToModel();
						fvm.QuestionsViewModel.Add(questionVm);
						questionVm.AnswersViewModel = new List<AnswerViewModel>();
						var dataTypesList = fieldDataTypes as List<ICode> ?? fieldDataTypes.ToList();
						questionVm.FieldDataTypeName = dataTypesList.FirstOrDefault(f => f.EnumId == q.FieldDataTypeId).Name;
						foreach (var a in q.Answers)
						{
							if (a.IsActive)
							{
								var answerVm = a.ToModel();
								answerVm.CssClass = string.Format("{0}", q.CssType.CssClassName).Trim();
								answerVm.CssInputType = q.CssType.InputType;
								answerVm.FieldDataTypeId = q.FieldDataTypeId;
								answerVm.FieldDataTypeName = questionVm.FieldDataTypeName;

							    questionVm.AnswersViewModel.Add(answerVm);
							}
						}
						questionVm.AnswersViewModel = questionVm.AnswersViewModel.OrderBy(op => op.SortOrder).ToList();
					}
				}

				fvm.QuestionsViewModel = fvm.QuestionsViewModel.OrderBy(q => q.SortOrder).ToList();

				return fvm;
			}
		}

		public JsonResult GetForms(int studyId, int size = 10, int page = 0)
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				//var studyId = 0;
				//var study = adminUow.FormRepository.GetCurrentStudyId();
				//if (study != null)
				//{
				//    studyId = study.FirstOrDefault();
				//}

				var allStudyForms = adminUow.FormRepository.GetAllFormsPerStudy(studyId, size, page);
				var formTypes = adminUow.CodeRepository.GetFormTypes();
				var layoutTypes = adminUow.CodeRepository.GetFormLayoutTypes();
				var formsList = new List<FormViewModel>();

				foreach (var frm in allStudyForms)
				{
					var form = frm.ToModel();
					var formTypesList = formTypes as List<ICode> ?? formTypes.ToList();
					var formType = formTypesList.FirstOrDefault(t => t.EnumId == frm.FormTypeId);
					if (formType != null)
					{
						form.FormTypeName = formType.Name;
					}
					var layoutTypesList = layoutTypes as List<ICode> ?? layoutTypes.ToList();
					var layoutType = layoutTypesList.FirstOrDefault(t => t.EnumId == frm.LayoutTypeId);
					if (layoutType != null)
					{
						form.LayoutTypeName = layoutType.Name;
					}
					if (frm.Study != null)
					{
						form.StudyName = frm.Study.Name;
					}
					form.QuestionCount = frm.Questions.Count();
					formsList.Add(form);
				}

				return Json(formsList, JsonRequestBehavior.AllowGet);
			}
		}

		public JsonResult GetFormQuestions(int formId)
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var data = adminUow.FormRepository.GetFormQuestions(formId);

				var questionsList = new List<QuestionViewModel>();
				var fieldDataTypes = adminUow.CodeRepository.GetFieldDataTypes();
				foreach (var question in data)
				{
					var q = question.ToModel();
					var fieldsDataTypesList = fieldDataTypes as List<ICode> ?? fieldDataTypes.ToList();
					q.FieldDataTypeName = fieldsDataTypesList.FirstOrDefault(f => f.EnumId == question.FieldDataTypeId).Name;
					q.AnswersCount = question.Answers.Count();
					questionsList.Add(q);
				}
				var json = Json(questionsList, JsonRequestBehavior.AllowGet);
				return json;
			}
		}

		public JsonResult GetQuestionAnswers(int questionId)
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var data = adminUow.FormRepository.GetQuestionAnswers(questionId);
				var answersList = data.Select(answer => answer.ToModel()).ToList();
				return Json(answersList, JsonRequestBehavior.AllowGet);
			}
		}

		#endregion

		#region - Visits -

		public JsonResult GetVisits(int id)
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var arm = adminUow.StudyRepository.GetArm(id);
				if (arm != null)
				{
					var visits = adminUow.VisitRepository.GetAllVisits(arm.StudyId).Select(v => v.ToModel()).ToList();
					return Json(visits, JsonRequestBehavior.DenyGet);
				}
				return Json("", JsonRequestBehavior.DenyGet);
			}
		}

		public JsonResult GetMappingSettings(int id)
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var data = new MatrixSettingsViewModel();
				var visits = adminUow.VisitRepository.GetAllVisits(id).Select(v => v.ToModel());
				var forms = adminUow.FormRepository.GetAllFormsPerStudy(id, FormType.DefaultForm);
				var labs = adminUow.FormRepository.GetAllFormsPerStudy(id, FormType.LabForm);

				data.Forms = forms.Select(form => form.ToModel()).OrderBy(f => f.Name).ToList();
				data.Labs = labs.Select(lab => lab.ToModel()).OrderBy(f => f.Name).ToList();
				data.Visits = visits.OrderBy(v => v.Id).ThenBy(v => v.SortOrder).ToList();

				var json = Json(data, JsonRequestBehavior.AllowGet);
				return json;
			}
		}

		public JsonResult GetVisitSettings(int id)
		{
			var data = new VisitSettingsViewModel();
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var visit = adminUow.VisitRepository.GetById(id);

				data.VisitId = visit.Id;
				data.VisitName = visit.Name;
				data.Forms = visit.VisitForms.Where(f => f.Form.FormTypeId == (int)FormType.DefaultForm).OrderBy(f => f.Form.Name).Select(v => v.Form.ToModel()).ToList();
				data.Labs = visit.VisitForms.Where(f => f.Form.FormTypeId == (int)FormType.LabForm).OrderBy(f => f.Form.Name).Select(v => v.Form.ToModel()).ToList();

				var json = Json(data, JsonRequestBehavior.AllowGet);
				return json;
			}
		}

		public JsonResult GetArmSteps(int armId)
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var data = adminUow.StudyRepository.GetArmSteps(armId);
				return Json(data.Select(s => s.ToModel()).ToList(), JsonRequestBehavior.AllowGet);
			}
		}

		public JsonResult GetStepVisits(int stepId)
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var data = adminUow.StudyRepository.GetStepVisits(stepId);
				return Json(data.Select(s => s.ToModel()).OrderBy(d => d.SortOrder).ToList(), JsonRequestBehavior.DenyGet);
			}
		}

		public JsonResult GetAllVisits(int studyId)
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var data = adminUow.VisitRepository.GetAllVisits(studyId, true);
				return Json(data.Select(s => s.ToModel()).OrderBy(d => d.SortOrder).ToList(), JsonRequestBehavior.DenyGet);
			}
		}
		#endregion

		#region - Subjects -

		public JsonResult GetSubjects(int id)
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var studyId = DefaultStudyId;
				var subjects = adminUow.SubjectRepository.GetAllSiteSubjects(studyId, id).ToList();
				var subModel = subjects.Select(s => s.ToModel());
				return Json(subModel, JsonRequestBehavior.AllowGet);
			}
		}

		public JsonResult FindSubjects(string what)
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var studyId = DefaultStudyId;
				var subjects = adminUow.SubjectRepository.FindSubjects(what, CurrentAppUser).ToList();
				var subModel = subjects.Select(s => s.ToModel());
				return Json(subModel, JsonRequestBehavior.AllowGet);
			}
		}

		public JsonResult GetSubjectInfo(int subjectId)
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var subject = adminUow.SubjectRepository.GetById(subjectId);
				var subModel = subject.ToModel();
				return Json(subModel, JsonRequestBehavior.AllowGet);
			}
		}
		#endregion

		#region - Schedule - Calendar -
        [Authorize(Roles = GlobalVariables.RoleSiteAdminAndAppUser)]
		public ActionResult LoadCalendarEvents(DateTime start, DateTime end)
		{
            if (CurrentAppUser == null)
            {                
                Response.StatusCode = 500;
                return new ContentResult { Content = "Sys admin is not allowed to view this information" };
            }



		    var currentUserSiteId = CurrentAppUser.SiteId;
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
                var data = adminUow.AppointmentRepository.SiteAppointmentsByDates(start, end, currentUserSiteId).ToList();
				var events = data.Select(a => a.ToModel());
				var appts = new List<AppointmentViewModel>();
				foreach (var ev in events)
				{
					var appUser = adminUow.UserRepository.GetById(ev.AppUserId);
					var subj = adminUow.SubjectRepository.GetById(ev.SubjectId);
					ev.AppUserFullName = string.Format("{0} {1}", appUser.Contact.FirstName, appUser.Contact.LastName);
					ev.SubjectFullName = string.Format("{0} {1}", subj.Contact.FirstName, subj.Contact.LastName);
					appts.Add(ev);
				}
				return Json(appts, JsonRequestBehavior.AllowGet);
			}
		}

		#endregion

		#region - Drugs and Medications -

		public JsonResult GetDrugCategories()
		{
			IEnumerable<DrugCategoryViewModel> json;
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var data = adminUow.DrugsRepository.GetAllDrugCategories();
				json = data.Select(d => d.ToModel()).ToList();
			}
			return Json(json, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetDrugClasses(int id)
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var data = adminUow.DrugsRepository.GetDrugClasses(id);
				return Json(data.Select(d => d.ToModel()).ToList(), JsonRequestBehavior.AllowGet);
			}
		}

		public JsonResult GetDrugs(int classId, int pageIndex, int pageSize = 20)
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				int totalRecords = 0;
				var data = adminUow.DrugsRepository.GetClassDrugs(classId, pageIndex, out totalRecords, pageSize).ToList();
				var drugsGroup = new DrugsGroupViewModel { GroupTotal = totalRecords, Drugs = data.Select(d => d.ToModel()).ToList() };
				var json = Json(drugsGroup, JsonRequestBehavior.AllowGet);

				return json;
			}
		}

		public JsonResult FindDrugs(string text, int max)
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var data = adminUow.DrugsRepository.FindByName(text, max).ToModel().ToList();
				var json = Json(data, JsonRequestBehavior.AllowGet);

				return json;
			}
		}

		#endregion
	}
}