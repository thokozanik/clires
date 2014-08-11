using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tateeda.Clires.Core.Data.EF;
using Tateeda.Clires.Core.Users;

namespace Tateeda.Clires.CodeTest.EFFakes {
    internal class UserRepositoryFake: IUserRepository {
        #region Implementation of IRepository<AppUser>
        List<AppUser> _users = new List<AppUser>(); 

        public IQueryable<AppUser> All { get; private set; }
        public AppUser GetById(object id)
        {
            return _users.FirstOrDefault(u => u.Id == (int) id);
        }

        public void Insert(AppUser entity)
        {
            _users.Add(entity);
        }

        public void Update(AppUser entity)
        {
            var cur = GetById(entity.Id);
            Delete(cur);
            Insert(entity);
        }

        public void Delete(AppUser entity)
        {
            _users.Remove(entity);
        }

        public void Commit()
        {
            
        }

        #endregion

        #region Implementation of IUserRepository

        public User GetUser(int id)
        {
            return _users.FirstOrDefault(u => u.User.Id == id).User;
        }

        public User GetUser(Guid id)
        {
            return _users.FirstOrDefault(u => u.MembershipUserId == id).User;
        }

        public IEnumerable<IAppUser> GetSiteUsers(int siteId)
        {
            return _users.Where(u => u.SiteId == siteId);
        }

        public void AddContact(IContact contact)
        {
            var user = contact.AppUsers.FirstOrDefault();
            Insert(user);
        }

        public void CreateAppUserWithMembership(IAppUser appUser, IRegistringUser registringUser, IContact contact)
        {
            throw new NotImplementedException();
        }

        public void UpdateAppUser(IAppUser appUser, IRegistringUser regUser)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IDisposable

        public void Dispose()
        {
            
        }

        #endregion
    }
}
