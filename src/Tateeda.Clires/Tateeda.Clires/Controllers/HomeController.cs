using System.Web.Mvc;
using System.Net;
using Tateeda.Clires.System;

namespace Tateeda.Clires.Controllers
{
	using Tateeda.Clires.Models;

	using global::System;
	using global::System.Net.Mail;

	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Message = "";

			ViewBag.LayoutLink = ValidateCurrentUser();

			return View();
		}


		public ActionResult About()
		{
			ViewBag.Message = "";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "";

			return View();
		}

		[HttpPost]
		public ActionResult DemoRequest(DemoRequestModel model)
		{
			try
			{
				string body = string.Format(
					@"<h1>Contact Email:{6}</h1><br/>
						Demo Request from: <b>{0}, {1}</b> 
						<br/> Organization: {2} 
						<br/> Phone: {3} 
						<br/> Comments: {4}. 
						<br/> Sent On:{5}",
					model.FirstName,
					model.LastName,
					model.Organization,
					model.ContactPhone,
					model.Comment,
					DateTime.Now,
					model.ContactEmail);
				using (var mail = new MailMessage(model.ContactEmail, "odesuk@yahoo.com", "Demo Request for Tateeda", body))
				{
					var smtp = new SmtpClient { EnableSsl = true };
					mail.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(body, null, "text/html"));
					smtp.Send(mail);
				}
			}
			catch (Exception ex)
			{
				//Log error here.
			}
			return RedirectToAction("About");
		}

		private string ValidateCurrentUser()
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
}