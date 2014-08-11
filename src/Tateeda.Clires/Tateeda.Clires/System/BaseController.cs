using System;
using System.Web.Mvc;
using Tateeda.Clires.Core.Data.EF;
using Tateeda.Clires.Data.UOW;
using System.Linq;
using MsMembership = System.Web.Security.Membership;

namespace Tateeda.Clires.System
{
    using NLog;

    [Authorize]
	public abstract class BaseController : Controller
	{
		protected static readonly Logger _logger = LogManager.GetCurrentClassLogger();

		public JsonMessage JsonMessage { get; set; }
		protected bool IsSiteAdmin { get; set; }
		protected bool IsSysAdmin { get; set; }
		protected bool IsAppUser { get; set; }
		protected bool IsGuest { get; set; }

		public void LeaveFeedback(string text, int score)
		{
			if (text.Length > 0 || score >= 0)
			{
				var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>();
				adminUow.FeedbackRepository.Insert(new Feedback
					{
						Comment = text,
						LikeScore = score,
						Uri = Request.RawUrl,
						CreatedBy = User.Identity.Name,
						CreatedOn = DateTime.UtcNow
					});
				adminUow.Commit();
			}
		}

		protected int DefaultStudyId
		{
			get
			{
				using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
				{
					return adminUow.StudyRepository.GetDefaultStudy();
				}
			}
		}

		protected string LayoutLink
		{
			get
			{
				var link = "~/Views/Shared/_Layout.cshtml";

				if (Request.Browser.IsMobileDevice)
				{
					link = "~/Views/Shared/_Layout.Mobile.cshtml";
				}

				if (User == null) return link;

				if (User.IsInRole(GlobalVariables.RoleSiteAdmin))
				{
					link = "~/Views/Shared/_AdminLayout.cshtml";
				}
				else if (User.IsInRole(GlobalVariables.RoleSystemAdmin))
				{
					link = "~/Views/Shared/_SysAdminLayout.cshtml";
				}
				else if (User.IsInRole(GlobalVariables.RoleAppUser))
				{
					link = "~/Views/Shared/_UserLayout.cshtml";
				}
				return link;
			}
		}

		protected AppUser CurrentAppUser
		{
			get
			{
				if (User != null)
				{
					var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>();
					var name = MsMembership.GetUser(User.Identity.Name);
					var user = adminUow.UserRepository.GetUser(new Guid(name.ProviderUserKey.ToString()));
				    return user.AppUsers.FirstOrDefault();
				}
				return null;
			}
		}

		protected override ViewResult View(IView view, object model)
		{
			ViewBag.Layout = LayoutLink;
			ViewBag.DefaultStudyId = DefaultStudyId;
			return base.View(view, model);
		}

		protected override ViewResult View(string viewName, string masterName, object model)
		{
			ViewBag.Layout = LayoutLink;
			ViewBag.DefaultStudyId = DefaultStudyId;
			return base.View(viewName, masterName, model);
		}
	}

	public class JsonMessage
	{
		public string Message { get; set; }
	}
}
