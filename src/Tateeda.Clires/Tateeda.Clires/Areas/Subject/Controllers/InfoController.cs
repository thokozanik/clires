namespace Tateeda.Clires.Areas.Subject.Controllers
{
	using global::System;

	using global::System.Collections.Generic;

	using global::System.Linq;

	using global::System.Threading;

	using global::System.Web.Mvc;

	using Tateeda.Clires.Areas.Subject.Model;
	using Tateeda.Clires.Core.Data.EF;
	using Tateeda.Clires.Core.Data.Enums;
	using Tateeda.Clires.Data.UOW;
	using Tateeda.Clires.Extensions;
	using Tateeda.Clires.System;
	using Tateeda.Clires.Utility;

	/// <summary>
	/// The info controller.
	/// </summary>
	[Authorize(Roles = GlobalVariables.RoleSiteAdminAndAppUser)]
	public class InfoController : BaseController
	{
		/// <summary>
		/// The index.
		/// </summary>
		/// <returns>
		/// The <see cref="ActionResult"/>.
		/// </returns>
		public ActionResult Index()
		{
			var siteId = CurrentAppUser.SiteId;
			ViewBag.SiteId = siteId;
			ViewBag.StudyId = DefaultStudyId;

			return View();
		}

		/// <summary>
		/// The details.
		/// </summary>
		/// <param name="id">
		/// The id.
		/// </param>
		/// <returns>
		/// The <see cref="ActionResult"/>.
		/// </returns>
		public ActionResult Details(int id)
		{
			//NOTE: Not disposing DbContext here because it is used on the UI page.
			var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>();
			var subject = adminUow.SubjectRepository.GetById(id);
			var model = subject.ToModel();
			var appts = adminUow.AppointmentRepository.GetSubjectVisits(id).ToList();
			model.Appointments = appts;

			return View(model);
		}

		/// <summary>
		/// The create subject.
		/// </summary>
		/// <param name="sub">
		/// The sub.
		/// </param>
		/// <returns>
		/// The <see cref="JsonResult"/>.
		/// </returns>
		public JsonResult CreateSubject(SubjectViewModel sub)
		{
			ModelState.Remove("Id");
			TryValidateModel(sub);

			if (sub.PhoneTypeId == 0)
			{
				sub.PhoneTypeId = 1;
			}

			if (ModelState.IsValid)
			{
				var siteId = CurrentAppUser.SiteId;
				var curUser = Thread.CurrentPrincipal.Identity.Name;
				var subject = sub.ToEntity();
				subject.Status = (int)EntityStatusType.Current;
				subject.SiteId = siteId;
				subject.StudyId = DefaultStudyId;
				subject.IsActive = sub.IsActive;

				subject.Contact = Contact(sub, curUser, null);
				subject.SSN = sub.SSN;
				subject.DateOfBirth = sub.DateOfBirth;
				subject.YearBorn = DateTime.Parse(sub.DateOfBirth).Year;

				using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
				{
					if (sub.Id > 0)
					{
						adminUow.SubjectRepository.Update(subject);
					}
					else
					{
						adminUow.SubjectRepository.Insert(subject);
					}

					adminUow.Commit();
				}

				if (sub.Id > 0)
				{
					using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
					{
						var updateContact = adminUow.SubjectRepository.GetSubjectContact(sub.Id);
						updateContact = Contact(sub, curUser, updateContact);
						updateContact.UpdatedBy = User.Identity.Name;
						adminUow.SubjectRepository.UpdateSubjectContactInfo(updateContact);
						adminUow.Commit();
					}
				}

				return Json(string.Format("sub.vm.getSubjects({0})", siteId), JsonRequestBehavior.AllowGet);
			}

			return Json("toastr.error('Missing Required Fields')", JsonRequestBehavior.DenyGet);
		}

		/// <summary>
		/// The contact.
		/// </summary>
		/// <param name="sub">
		/// The sub.
		/// </param>
		/// <param name="curUser">
		/// The cur user.
		/// </param>
		/// <returns>
		/// The <see cref="Contact"/>.
		/// </returns>
		private static Contact Contact(SubjectViewModel sub, string curUser, Contact curContact)
		{
			var areaCode = 0;
			if (!string.IsNullOrWhiteSpace(sub.Telephone))
				areaCode = Common.GetAreaCodeFromTelephone(sub.Telephone);

			if (curContact == null)
			{
				curContact = new Contact();
			}

			var firstPhone = curContact.Phones.FirstOrDefault() ?? new Phone();
			var firstAddr = curContact.Addresses.FirstOrDefault() ?? new Address();
			var firstEmail = curContact.Emails.FirstOrDefault() ?? new Email();

			var curPhoneId = firstPhone.Id;
			var curAddrId = firstAddr.Id;
			var curEmailId = firstEmail.Id;

			return new Contact
				{
					Id = curContact.Id,
					ContactTypeId = (int)ContactType.Subject,
					CreatedOn = DateTime.UtcNow,
					CreatedBy = curUser,
					Addresses =
						new List<Address>
							{
								Address(sub, curUser, curAddrId)
							},
					Emails =
						new List<Email>
							{
								Email(sub, curUser, curEmailId)
							},
					Phones =
						new List<Phone>
							{
								Phone(sub, areaCode, curUser, curPhoneId)
							},
					FirstName = sub.FirstName,
					LastName = sub.LastName,
					MiddleName = sub.MiddleName,
					Status = (int)EntityStatusType.Current
				};
		}

		/// <summary>
		/// The address.
		/// </summary>
		/// <param name="sub">
		/// The sub.
		/// </param>
		/// <param name="curUser">
		/// The cur user.
		/// </param>
		/// <returns>
		/// The <see cref="Address"/>.
		/// </returns>
		private static Address Address(SubjectViewModel sub, string curUser, int addressId = 0)
		{
			return new Address
				{
					Id = addressId,
					Street = sub.Street,
					City = sub.City,
					PostalCode = sub.PostalCode,
					StateId = sub.StateId,
					CountryId = sub.CountryId,
					AddressTypeId = sub.AddressTypeId,
					CreatedBy = curUser,
					CreatedOn = DateTime.UtcNow
				};
		}

		/// <summary>
		/// The email.
		/// </summary>
		/// <param name="sub">
		/// The sub.
		/// </param>
		/// <param name="curUser">
		/// The cur user.
		/// </param>
		/// <returns>
		/// The <see cref="Email"/>.
		/// </returns>
		private static Email Email(SubjectViewModel sub, string curUser, int emailId = 0)
		{
			return new Email
				{
					Id = emailId,
					Address = sub.Address,
					CreatedBy = curUser,
					CreatedOn = DateTime.UtcNow,
					IsActive = true,
					SortOrder = 0,
					Status = (int)EntityStatusType.Current
				};
		}

		/// <summary>
		/// The phone.
		/// </summary>
		/// <param name="sub">
		/// The sub.
		/// </param>
		/// <param name="areaCode">
		/// The area code.
		/// </param>
		/// <param name="curUser">
		/// The cur user.
		/// </param>
		/// <returns>
		/// The <see cref="Phone"/>.
		/// </returns>
		private static Phone Phone(SubjectViewModel sub, int areaCode, string curUser, int phoneId = 0)
		{
			return new Phone
				{
					Id = phoneId,
					AreaCode = areaCode,
					Number = 0, // TODO: Get Proper value from the telephone string
					Telephone = sub.Telephone,
					PhoneTypeId = sub.PhoneTypeId,
					IsActive = true,
					Status = (int)EntityStatusType.Current,
					CreatedBy = curUser,
					CreatedOn = DateTime.UtcNow,
					CountryCode = sub.CountryCode ?? "1"
				};
		}
	}
}