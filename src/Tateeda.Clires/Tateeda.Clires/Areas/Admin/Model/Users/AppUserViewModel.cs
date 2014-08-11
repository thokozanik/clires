// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppUserViewModel.cs" company="Tateeda Media Network">
//   
// </copyright>
// <summary>
//   The app user view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Areas.Admin.Model.Users
{
    using Tateeda.Clires.Core.Data.EF;

    using global::System;
    using global::System.Collections.Generic;
    using global::System.ComponentModel.DataAnnotations;

    public interface IAppUserViewModel
    {
        [Required]
        string Email { get; set; }

        [Required]
        string Password { get; set; }

        [Required]
        string RoleName { get; set; }

        [Required]
        string UserName { get; set; }

        Guid MembershipUserId { get; set; }
        int SiteId { get; set; }
        Guid RoleId { get; set; }
        int ContactId { get; set; }
        string Title { get; set; }
        int ContactTypeId { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        ICollection<AppUser> AppUsers { get; set; }
        ICollection<Subject> Subjects { get; set; }
        ICollection<Address> Addresses { get; set; }
        ICollection<Email> Emails { get; set; }
        ICollection<Phone> Phones { get; set; }
        string CountryCode { get; set; }
        int AreaCode { get; set; }
        int Number { get; set; }
        int? PhoneTypeId { get; set; }
        string Telephone { get; set; }
        int AddressTypeId { get; set; }
        string Street { get; set; }
        string City { get; set; }
        string PostalCode { get; set; }
        int? StateId { get; set; }
        int? CountryId { get; set; }
        string Address { get; set; }
        int SortOrder { get; set; }
        string Comments { get; set; }
        int Status { get; set; }
        DateTime? UpdatedOn { get; set; }
        DateTime? CreatedOn { get; set; }
        string UpdatedBy { get; set; }
        string CreatedBy { get; set; }
        bool IsActive { get; set; }
        ICollection<Contact> Contacts { get; set; }
        Contact Contact { get; set; }
        Role Role { get; set; }
        Site Site { get; set; }
        User User { get; set; }
        int Id { get; set; }

        string SiteName { get; set; }
    }

    /// <summary>
    ///   The app user view model.
    /// </summary>
    public class AppUserViewModel : IAppUser, IContact, IPhone, IAddress, IEmail, IAppUserViewModel
    {
        #region - Model Custom -

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string RoleName { get; set; }

        [Required]
        public string UserName { get; set; }

        public Guid MembershipUserId { get; set; }
        public int SiteId { get; set; }
        public Guid RoleId { get; set; }
        public int ContactId { get; set; }
        public string Title { get; set; }
        public int ContactTypeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public ICollection<AppUser> AppUsers { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Email> Emails { get; set; }
        public ICollection<Phone> Phones { get; set; }
        public string CountryCode { get; set; }
        public int AreaCode { get; set; }
        public int Number { get; set; }
        public int? PhoneTypeId { get; set; }
        public string Telephone { get; set; }
        public int AddressTypeId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public string Address { get; set; }
        public int SortOrder { get; set; }
        public string Comments { get; set; }
        public int Status { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public Contact Contact { get; set; }
        public Role Role { get; set; }
        public Site Site { get; set; }
        public User User { get; set; }
        public int Id { get; set; }
        public string SiteName { get; set; }

        #endregion

        #region - Private -

        ICollection<Contact> IEmail.Contacts { get; set; }
        ICollection<Contact> IAddress.Contacts { get; set; }
        DateTime IEmail.CreatedOn { get; set; }
        DateTime IAddress.CreatedOn { get; set; }
        DateTime IPhone.CreatedOn { get; set; }
        DateTime IContact.CreatedOn { get; set; }
        DateTime? IContact.UpdatedOn { get; set; }
        string IContact.CreatedBy { get; set; }
        string IContact.UpdatedBy { get; set; }
        bool IContact.IsActive { get; set; }
        int IContact.SortOrder { get; set; }
        int IContact.Status { get; set; }

        #endregion
    }
}