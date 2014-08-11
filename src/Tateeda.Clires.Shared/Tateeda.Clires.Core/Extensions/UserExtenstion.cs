// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserExtenstion.cs" company="">
//   
// </copyright>
// <summary>
//   The user extenstion.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Extensions
{
    using Tateeda.Clires.Core.Data.EF;

    /// <summary>
    /// The user extenstion.
    /// </summary>
    public static class UserExtenstion
    {
        #region Public Methods and Operators

        /// <summary>
        /// The to entity.
        /// </summary>
        /// <param name="appuser">
        /// The appuser.
        /// </param>
        /// <returns>
        /// The <see cref="AppUser"/>.
        /// </returns>
        public static AppUser ToEntity(this IAppUser appuser)
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
                    RoleId = appuser.RoleId
                };
        }

        #endregion
    }
}