// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TasksController.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the TasksController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Tateeda.Clires.Areas.Admin.Model.Report;
using Tateeda.Clires.Utility;

namespace Tateeda.Clires.Areas.Dashboard.Controllers
{
	using global::System;

	using global::System.Collections.Generic;

	using global::System.Collections.ObjectModel;

	using global::System.Linq;

	using global::System.Web.Mvc;

	using Admin.Model.Users;
	using Models;
	using Core.Data.EF;
	using Data.UOW;
	using Extensions;
	using System;

	[Authorize]
	public class TasksController : BaseController
	{
		/// <summary>
		/// The index.
		/// </summary>
		/// <returns>
		/// The <see cref="ActionResult"/>.
		/// </returns>
		public ActionResult Index()
		{
			var model = new DashboardViewModel
				{
					Appointments = new List<IAppointment>(),
					AppUserView =
						new AppUserViewModel
							{
								Addresses = new List<Address> { new Address() },
								Phones = new List<Phone> { new Phone() }
							},
					Messages = new List<IMessageQueue>()
				};

			if (CurrentAppUser != null)
			{
				var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>();
				{
					var siteAppts =
						adminUow.AppointmentRepository.SiteAppointmentsByDates(CurrentAppUser.SiteId, DateTime.UtcNow.AddDays(-14), DateTime.UtcNow.AddDays(14)).
							ToList();
					model.Appointments = siteAppts.Where(a => a.AppUserId == CurrentAppUser.Id).OrderBy(a => a.StartDate);
					model.AppUserView = adminUow.UserRepository.GetById(CurrentAppUser.Id).ToModel();
					model.AppUserView.Addresses = model.AppUserView.Contact.Addresses;
					model.AppUserView.Subjects = new Collection<Subject>();
					LoadAppUserSubjects(model.AppUserView.Subjects, adminUow);
				}
			}

			var reportModel = new ReportModel { SubjectsReportModel = new SubjectsReportModel() };
			Common.FillReportModel(reportModel, DefaultStudyId);

			model.AdminReport = reportModel;
			model.IsAdmin = IsUserInAdminRole();

			return View(model);
		}

		private bool IsUserInAdminRole()
		{
			if (User != null)
			{
				if (User.IsInRole(GlobalVariables.RoleSiteAdmin))
				{
					IsSiteAdmin = true;
					IsGuest = IsAppUser = IsSysAdmin = false;
					return true;
				}
				else if (User.IsInRole(GlobalVariables.RoleSystemAdmin))
				{
					IsSysAdmin = true;
					IsGuest = IsAppUser = IsSysAdmin = false;
					return true;
				}
				else if (User.IsInRole(GlobalVariables.RoleAppUser))
				{
					IsAppUser = true;
					IsGuest = IsSysAdmin = IsSysAdmin = false;
					return false;
				}
			}
			return false;
		}

		private void LoadAppUserSubjects(ICollection<Subject> subjList, IAdminUnitOfWork adminUow)
		{
			var subjects =
				adminUow.SubjectRepository.GetAllSiteSubjects(GlobalVariables.CurrentStudyId, CurrentAppUser.SiteId).Where(
					s => s.CreatedBy == CurrentAppUser.User.UserName);
			foreach (var s in subjects.Cast<Subject>())
			{
				var sub = adminUow.SubjectRepository.GetById(s.Id);
				subjList.Add(sub);
			}
		}

	}
}
