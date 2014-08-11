namespace Tateeda.Clires.Extensions
{
    using Tateeda.Clires.Areas.Admin.Model.Users;

    using global::System.Collections.Generic;
    using global::System.Linq;
    using Core.Data.EF;
    using Core.Data.Enums;
    using Core.Users;

    public static class UserExtension
    {
        public static AppUserViewModel ToModel(this IAppUser user)
        {
            var contact = user.Contact;
            var phone = contact.Phones.FirstOrDefault() ?? new Phone();
            var email = contact.Emails.FirstOrDefault() ?? new Email();
            var address = contact.Addresses.FirstOrDefault() ?? new Address();

            return new AppUserViewModel
                {
                    Comments = user.Comments,
                    CreatedBy = user.CreatedBy,
                    CreatedOn = user.CreatedOn,
                    Id = user.Id,
                    IsActive = user.IsActive,
                    MembershipUserId = user.MembershipUserId,
                    RoleId = user.RoleId,
                    SiteId = user.SiteId,
                    SiteName = user.Site.Name,
                    SortOrder = user.SortOrder,
                    Status = user.Status,
                    Title = user.Title,
                    UpdatedBy = user.UpdatedBy,
                    UpdatedOn = user.UpdatedOn,
                    ContactId = user.ContactId,
                    UserName = user.User.UserName,
                    Email = email.Address,
                    Contact = new Contact
                        {
                            FirstName = contact.FirstName,
                            LastName = contact.LastName,
                            ContactTypeId = contact.ContactTypeId,
                            Phones = new List<Phone>
                                {
                                    new Phone
                                        {
                                            AreaCode = phone.AreaCode,
                                            Number = phone.Number,
                                            Telephone = phone.Telephone,
                                            PhoneTypeId = phone.PhoneTypeId
                                        }
                                },
                            Addresses =
                                new List<Address>
                                    {
                                        new Address
                                            {
                                                Street = address.Street,
                                                City = address.City,
                                                PostalCode = address.PostalCode,
                                                StateId = address.StateId,
                                                CountryId = address.CountryId,
                                                AddressTypeId = address.AddressTypeId
                                            }
                                    },
                            Emails = new List<Email>
                                {
                                    new Email {Address = email.Address}
                                }
                        }
                };
        }

        public static IAppUser ToEntity(this AppUserViewModel appuser)
        {            

            return new AppUser
                {
                    Comments = appuser.Comments,
                    CreatedBy = appuser.CreatedBy,
                    CreatedOn = appuser.CreatedOn,
                    Id = appuser.Id,
                    IsActive = appuser.IsActive,
                    MembershipUserId = appuser.MembershipUserId,
                    SiteId = appuser.SiteId,
                    SortOrder = appuser.SortOrder,
                    Status = appuser.Status,
                    Title = appuser.Title,
                    UpdatedBy = appuser.UpdatedBy,
                    UpdatedOn = appuser.UpdatedOn,
                    RoleId = appuser.RoleId,
                    Contact = appuser.Contact
                };
        }

        public static IRegistringUser ToRegistringUser(this AppUserViewModel model)
        {
            return new RegistringUser { Email = model.Email, Password = model.Password, Role = model.RoleName, UserName = model.UserName };
        }
    }
}