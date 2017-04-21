using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Evol.TMovie.Manage.Models.Identity;
using Evol.TMovie.Domain.QueryEntries;
using Evol.TMovie.Domain.Services;

namespace Evol.TMovie.Manage.Core.Identity
{
    public class AppUserStore : IUserRoleStore<AppUser>, IUserPasswordStore<AppUser>
    {
        private IEmployeeQueryEntry _employeeQueryEntry;

        private IEmployeePermissionShipQueryEntry _employeePermissionShipQueryEntry;

        private IEmployeePermissionService _employeePermissionService;

        private IPasswordHasher<AppUser> _passwordHasher;

        public AppUserStore(IEmployeeQueryEntry userQueryEntry, IEmployeePermissionShipQueryEntry userPermissionShipQueryEntry, IEmployeePermissionService employeePermissionService, IPasswordHasher<AppUser> passwordHasher)
        {
            if (userQueryEntry == null)
                throw new ArgumentNullException(nameof(userQueryEntry));

            _employeeQueryEntry = userQueryEntry;
            _employeePermissionShipQueryEntry = userPermissionShipQueryEntry;
            _employeePermissionService = employeePermissionService;
            _passwordHasher = passwordHasher;
        }

        public void Dispose()
        {
        }

        #region  不实现

        public Task AddToRoleAsync(AppUser user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> CreateAsync(AppUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(AppUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        public async Task<AppUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            Guid id;
            if (!Guid.TryParse(userId, out id))
                throw new ArgumentException($"{nameof(userId)} not a guid");
            var item = await _employeeQueryEntry.FindAsync(id);
            if (item == null)
                return null;

            var userPermission = await _employeePermissionService.GetAsync(id);

            return new AppUser() { Id = item.Id, Username = item.Username, RealName = item.RealName, Roles  = userPermission.Roles.Select(e => e.Value).ToArray()};
        }

        public Task<AppUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //var user = await _employeeQueryEntry.FindByUsernameAsync(normalizedUserName);
            //if (user == null)
            //    return null;
            //var roles = await _employeePermissionShipQueryEntry.GetRolesByUserIdAsync(user.Id);
            //return new AppUser() { Id = user.Id, Username = user.Username, RealName = user.RealName, Roles = roles.Select(e => e.Code).ToArray()};
        }

        public Task<string> GetNormalizedUserNameAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Username);
        }

        //lg-2.
        public async Task<string> GetPasswordHashAsync(AppUser user, CancellationToken cancellationToken)
        {
            var userEntity = await _employeeQueryEntry.FindByUsernameAsync(user.Username);
            if (user == null)
                return string.Empty;
            return userEntity.Password;
        }

        //lg-6.
        public async Task<IList<string>> GetRolesAsync(AppUser user, CancellationToken cancellationToken)
        {
            var roles = await _employeePermissionShipQueryEntry.GetRolesByEmployeeIdAsync(user.Id);
            var result = roles.Select(e => e.Code).ToList();
            return result;
        }

        //lg-4.
        public Task<string> GetUserIdAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        //lg-5.
        public Task<string> GetUserNameAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Username);
        }

        public async Task<IList<AppUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            var users = await _employeePermissionShipQueryEntry.GetEmployeesByRoleCodeAsync(roleName);
            var result = users.Select(e => new AppUser() { Id = e.Id, Username = e.Username, RealName = e.RealName }).ToList();
            return result;
        }

        public async Task<bool> HasPasswordAsync(AppUser user, CancellationToken cancellationToken)
        {
            var userEntity = await _employeeQueryEntry.FindByUsernameAsync(user.Username);
            return user != null && !string.IsNullOrWhiteSpace(userEntity.Password);
        }

        public async Task<bool> IsInRoleAsync(AppUser user, string roleName, CancellationToken cancellationToken)
        {
            var users = await _employeePermissionShipQueryEntry.GetEmployeesByRoleCodeAsync(roleName);
            return users.Any(e => e.Id == user.Id);
        }

        #region 不实现

        public Task RemoveFromRoleAsync(AppUser user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(AppUser user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(AppUser user, string passwordHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync(AppUser user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(AppUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
