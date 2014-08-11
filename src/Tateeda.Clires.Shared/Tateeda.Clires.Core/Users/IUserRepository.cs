// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The UserRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Users
{
	using System;
	using System.Collections.Generic;

	using Tateeda.Clires.Core.Data;
	using Tateeda.Clires.Core.Data.EF;

	/// <summary>
	/// The UserRepository interface.
	/// </summary>
	public interface IUserRepository : IRepository<AppUser>
	{
		#region Public Methods and Operators

		/// <summary>
		/// The add contact.
		/// </summary>
		/// <param name="contact">
		/// The contact.
		/// </param>
		void AddContact(IContact contact);

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
		void CreateAppUserWithMembership(IAppUser appUser, IRegistringUser registeringUser, IContact contact);

		/// <summary>
		/// The get site users.
		/// </summary>
		/// <param name="siteId">
		/// The site id.
		/// </param>
		/// <returns>
		/// The <see cref="IEnumerable"/>.
		/// </returns>
		IEnumerable<IAppUser> GetSiteUsers(int siteId);

		/// <summary>
		/// The get user.
		/// </summary>
		/// <param name="id">
		/// The id.
		/// </param>
		/// <returns>
		/// The <see cref="User"/>.
		/// </returns>
		User GetUser(int id);

		/// <summary>
		/// The get user.
		/// </summary>
		/// <param name="id">
		/// The id.
		/// </param>
		/// <returns>
		/// The <see cref="User"/>.
		/// </returns>
		User GetUser(Guid id);

		/// <summary>
		/// The update app user.
		/// </summary>
		/// <param name="appUser">
		/// The app user.
		/// </param>
		/// <param name="regUser">
		/// The reg user.
		/// </param>
		void UpdateAppUser(IAppUser appUser, IRegistringUser additionaUserInfo);

		#endregion
	}
}