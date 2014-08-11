using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Transactions;
using System.Web.WebPages.Scope;

namespace Tateeda.Clires.Areas.Admin.Controllers
{
	#region

	using global::System;

	using global::System.Collections.Generic;

	using global::System.Globalization;

	using global::System.Linq;
	using global::System.Text;
	using global::System.Threading;

	using global::System.Web.Mvc;

	using Tateeda.Clires.Areas.Admin.Model.Users;
	using Tateeda.Clires.Core.Data.EF;
	using Tateeda.Clires.Core.Data.Enums;
	using Tateeda.Clires.Core.Users;
	using Tateeda.Clires.Data.UOW;
	using Tateeda.Clires.Extensions;
	using Tateeda.Clires.System;
	using Tateeda.Clires.Utility;

	#endregion

	[Authorize(Roles = GlobalVariables.RoleSiteAdminAndSysAdmin)]
	public class UsersController : BaseController
	{
		private object _lock = new object();

		public ActionResult Index()
		{
			LoadViewBagItems();
			return View();
		}

	    [HttpPost]
	    public ActionResult NewUser(AppUserViewModel user)
	    {
	        lock (_lock) {
	            LoadViewBagItems();

	            if (user.Id > 0) {
	                return EditUser(user);
	            }

	            var curUser = Thread.CurrentPrincipal.Identity.Name;
	            var appUser = user.ToEntity();
	            appUser.Status = (int) EntityStatusType.Current;
	            var regUser = user.ToRegistringUser();
	            regUser.Password = "Password1";

                try {
                    using (var scope = new TransactionScope()) {
                        using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>()) {
                            var roleName =
                                adminUow.CodeRepository.GetRolesList().FirstOrDefault(r => r.RoleId == user.RoleId);
                            if (roleName != null) {
                                regUser.Role = roleName.RoleName;
                            }

                            var contact = Contact(user, curUser);

                            adminUow.UserRepository.CreateAppUserWithMembership(appUser, regUser, contact);
                            adminUow.Commit();
                        }
                        scope.Complete();
                    }
                }
                catch (Exception ex) {
                    _logger.ErrorException("Can't Create New User.", ex);
                    Response.StatusCode = 500;
                    return new ContentResult {
                        Content = string.Format("Error creating a new user: Error:{0}", ex.Message)
                    };
                }

	            return Json("admin.vm.sites();", "text/html", JsonRequestBehavior.AllowGet);
	        }
	    }

	    private static Contact Contact(AppUserViewModel user, string curUser)
		{
			return new Contact
				{
					ContactTypeId = (int)ContactType.AppUser,
					CreatedOn = DateTime.UtcNow,
					CreatedBy = curUser,
					Addresses =
						new List<Address>
							{
								Address(user, curUser)
							},
					Emails =
						new List<Email>
							{
								Email(user, curUser)
							},
					Phones =
						new List<Phone>
							{
								Phone(user, curUser)
							},
					FirstName = user.FirstName,
					LastName = user.LastName,
					MiddleName = user.MiddleName,
					Status = (int)EntityStatusType.Current
				};
		}

		private static Phone Phone(AppUserViewModel user, string curUser)
		{
			const int NAphoneType = 4;
			return new Phone
				{
					AreaCode = Common.GetAreaCodeFromTelephone(user.Telephone),
					Number = 0, //TODO: Get proper value from telephone
					Telephone = user.Telephone,
					PhoneTypeId = user.PhoneTypeId == 0 ? NAphoneType : user.PhoneTypeId, //TODO: [SK] Fix this code for proper phone type. For now default to N/A
					IsActive = true,
					Status = (int)EntityStatusType.Current,
					CreatedBy = curUser,
					CreatedOn = DateTime.UtcNow,
					CountryCode = user.CountryCode ?? "1"
				};
		}

		private static Email Email(AppUserViewModel user, string curUser)
		{
			return new Email
				{
					Address = user.Email,
					CreatedBy = curUser,
					CreatedOn = DateTime.UtcNow,
					IsActive = true,
					SortOrder = 0,
					Status = (int)EntityStatusType.Current
				};
		}

		private static Address Address(AppUserViewModel user, string curUser)
		{
			return new Address
				{
					Street = user.Street,
					City = user.City,
					PostalCode = user.PostalCode,
					StateId = user.StateId,
					CountryId = user.CountryId,
					AddressTypeId = user.AddressTypeId,
					CreatedBy = curUser,
					CreatedOn = DateTime.UtcNow
				};
		}

		private ActionResult EditUser(AppUserViewModel user)
		{
			try
			{
				using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
				{
					var usr = adminUow.UserRepository.GetById(user.Id);
					var appUser = user.ToEntity();
					appUser.Contact = usr.Contact;

					appUser.Status = (int)EntityStatusType.Current;
					var additionaUserInfo = user.ToRegistringUser();

					var roleName = adminUow.CodeRepository.GetRolesList().FirstOrDefault(r => r.RoleId == user.RoleId);
					if (roleName != null)
					{
						additionaUserInfo.Role = roleName.RoleName;
					}
					appUser.Contact.FirstName = user.FirstName;
					appUser.Contact.LastName = user.LastName;
					appUser.Contact.IsActive = user.IsActive;

					adminUow.UserRepository.UpdateAppUser(appUser, additionaUserInfo);
					adminUow.Commit();
				}
				return Json("alert('ok');", JsonRequestBehavior.DenyGet);
			}
			catch (Exception ex)
			{
				_logger.Debug(ex.Message);
				using (var uow = DependencyResolver.Current.GetService<IUtilUnitOfWork>())
				{
					uow.ErrorLogRepository.Log(ex.Message, ex.StackTrace);
					uow.Commit();
				}
				return Json(ex.Message, JsonRequestBehavior.DenyGet);
			}
		}

		private void LoadViewBagItems()
		{
			var enumHelper = new EnumerationHelper();
			var sites = enumHelper.GetSites();
			var allRoles = enumHelper.GetRoles();
			var roles = new List<SelectListItem>();
			if (User != null)
			{
				var name = global::System.Web.Security.Membership.GetUser(User.Identity.Name);
				if (name != null)
				{
					using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
					{
						var user = adminUow.UserRepository.GetUser(new Guid(name.ProviderUserKey.ToString()));
						var appUser = user.AppUsers.FirstOrDefault();
						if (appUser != null && (appUser.SiteId > 0 || !User.IsInRole(GlobalVariables.RoleSystemAdmin)))
						{
							sites = sites.Where(s => s.Value == appUser.SiteId.ToString(CultureInfo.InvariantCulture));
							roles.AddRange(allRoles.Where(r => r.Text != GlobalVariables.RoleSystemAdmin));
						}
						else
						{
							roles.AddRange(allRoles);
						}
					}
				}
			}

			ViewBag.Sites = sites;
			ViewBag.Roles = roles;
		}
	}
}