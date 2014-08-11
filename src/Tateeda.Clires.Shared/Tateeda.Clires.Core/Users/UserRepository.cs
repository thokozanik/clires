// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The user repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Users
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading;
	using System.Web.Security;

	using Tateeda.Clires.Core.Data.EF;
	using Tateeda.Clires.Core.Data.Enums;
	using Tateeda.Clires.Extensions;

	using MsMembership = System.Web.Security.Membership;

	/// <summary>
	/// The user repository.
	/// </summary>
	public class UserRepository : IUserRepository
	{
		#region Fields

		/// <summary>
		/// The _context.
		/// </summary>
		private readonly IDbContext _context;

		#endregion

		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="UserRepository"/> class.
		/// </summary>
		/// <param name="context">
		/// The context.
		/// </param>
		public UserRepository(IDbContext context)
		{
			_context = context;
			All = _context.AppUsers.AsQueryable();
		}

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets the all.
		/// </summary>
		public IQueryable<AppUser> All { get; private set; }

		#endregion

		#region Public Methods and Operators

		/// <summary>
		/// The add contact.
		/// </summary>
		/// <param name="contact">
		/// The contact.
		/// </param>
		public void AddContact(IContact contact)
		{
			_context.Contacts.Add(contact as Contact);
		}

		/// <summary>
		/// The commit.
		/// </summary>
		public void Commit()
		{
			_context.Commit();
		}

		/// <summary>
		/// The create app user with membership.
		/// </summary>
		/// <param name="appUser">
		/// The app user.
		/// </param>
		/// <param name="registeringUser">
		/// The registering user.
		/// </param>
		/// <param name="contact">
		/// The contact.
		/// </param>
		public void CreateAppUserWithMembership(IAppUser appUser, IRegistringUser registeringUser, IContact contact)
		{
			var memUser = MsMembership.CreateUser(registeringUser.UserName, registeringUser.Password, registeringUser.Email);
			var appuser = appUser.ToEntity();
			if (memUser.ProviderUserKey != null)
			{
				var user = GetUser(Guid.Parse(memUser.ProviderUserKey.ToString()));
				user.AppUsers.Add(appuser);
				Roles.AddUserToRole(registeringUser.UserName, registeringUser.Role);
				AddContact(contact);
				contact.AppUsers.Add(appuser);
				Commit();
			}
		}

		/// <summary>
		/// The delete.
		/// </summary>
		/// <param name="entity">
		/// The entity.
		/// </param>
		public void Delete(AppUser entity)
		{
			var item = _context.AppUsers.FirstOrDefault(a => a.Id == entity.Id);
			if (item == null)
			{
				return;
			}

			item.IsActive = false;
			item.Status = (int)EntityStatusType.Deleted;
			item.UpdatedBy = entity.UpdatedBy ?? Thread.CurrentPrincipal.Identity.Name;
			item.UpdatedOn = DateTime.UtcNow;
		}

		/// <summary>
		/// The get by id.
		/// </summary>
		/// <param name="id">
		/// The id.
		/// </param>
		/// <returns>
		/// The <see cref="AppUser"/>.
		/// </returns>
		public AppUser GetById(object id)
		{
			return _context.AppUsers.FirstOrDefault(u => u.Id == (int)id);
		}

		/// <summary>
		/// The get site users.
		/// </summary>
		/// <param name="siteId">
		/// The site id.
		/// </param>
		/// <returns>
		/// The <see cref="IEnumerable"/>.
		/// </returns>
		public IEnumerable<IAppUser> GetSiteUsers(int siteId)
		{
			_context.AutoDetectChangesEnabled = false;
			var users = _context.AppUsers.Where(u => u.SiteId == siteId && u.IsActive).AsEnumerable();
			_context.AutoDetectChangesEnabled = true;
			return users;
		}

		/// <summary>
		/// The get user.
		/// </summary>
		/// <param name="id">
		/// The id.
		/// </param>
		/// <returns>
		/// The <see cref="User"/>.
		/// </returns>
		public User GetUser(int id)
		{
			return _context.Users.FirstOrDefault(u => u.Id == id);
		}

		/// <summary>
		/// The get user.
		/// </summary>
		/// <param name="id">
		/// The id.
		/// </param>
		/// <returns>
		/// The <see cref="User"/>.
		/// </returns>
		public User GetUser(Guid id)
		{
			return _context.Users.FirstOrDefault(u => u.UserId == id);
		}

		/// <summary>
		/// The insert.
		/// </summary>
		/// <param name="entity">
		/// The entity.
		/// </param>
		public void Insert(AppUser entity)
		{
			entity.CreatedOn = DateTime.UtcNow;
			entity.CreatedBy = Thread.CurrentPrincipal.Identity.Name;
			_context.AppUsers.Add(entity);
		}

		/// <summary>
		/// The update.
		/// </summary>
		/// <param name="entity">
		/// The entity.
		/// </param>
		/// <exception cref="Exception">
		/// </exception>
		public void Update(AppUser entity)
		{
			var user = _context.AppUsers.FirstOrDefault(u => u.Id == entity.Id);
			if (user == null)
			{
				throw new Exception(string.Format("Record Id:{0} Not found", entity.Id));
			}

			user.Contact.FirstName = entity.Contact.FirstName;
			user.Contact.LastName = entity.Contact.LastName;

			user.IsActive = entity.IsActive;
			user.SiteId = entity.SiteId;
			user.SortOrder = entity.SortOrder;
			user.Status = entity.Status;
			user.Title = entity.Title;
			user.UpdatedBy = Thread.CurrentPrincipal.Identity.Name;
			user.UpdatedOn = DateTime.UtcNow;
		}

		/// <summary>
		/// The update app user.
		/// </summary>
		/// <param name="appUser">
		/// The app user.
		/// </param>
		/// <param name="additionaUserInfo">
		/// The reg user.
		/// </param>
		public void UpdateAppUser(IAppUser appUser, IRegistringUser additionaUserInfo)
		{
			//var curUser = GetUser(appUser.Id);
			var curMemUser = MsMembership.GetUser(additionaUserInfo.UserName);
			var curAppUser = GetById(appUser.Id);

			curAppUser.Contact.FirstName = appUser.Contact.FirstName;
			curAppUser.Contact.LastName = appUser.Contact.LastName;
			curAppUser.SiteId = appUser.SiteId;
			curAppUser.IsActive = appUser.IsActive;
			curAppUser.Title = appUser.Title;
			curAppUser.UpdatedBy = Thread.CurrentPrincipal.Identity.Name;
			curAppUser.UpdatedOn = DateTime.UtcNow;
			curAppUser.SortOrder = appUser.SortOrder;
			curAppUser.Status = appUser.Status;
			curAppUser.RoleId = appUser.RoleId;

			if (curMemUser != null)
			{
				curMemUser.Email = additionaUserInfo.Email;
			}

			//curUser.UserName = additionaUserInfo.UserName;
			MsMembership.UpdateUser(curMemUser);

			SetUserRole(additionaUserInfo, curAppUser.User, curAppUser);
		}

		private static void SetUserRole(IRegistringUser regUser, User curUser, AppUser curAppUser)
		{
			try
			{
				Roles.AddUserToRole(curUser.UserName, regUser.Role);
			}
			catch { }

			if (Roles.IsUserInRole(curUser.UserName, curAppUser.Role.RoleName))
			{
				Roles.RemoveUserFromRole(curUser.UserName, curAppUser.Role.RoleName);
				Roles.AddUserToRole(curUser.UserName, regUser.Role);
			}
		}

		#endregion
	}
}