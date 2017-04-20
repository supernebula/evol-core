using Evol.TMovie.Manage.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using System.Threading;
using Evol.TMovie.Domain.QueryEntries;

namespace Evol.TMovie.Manage.Core.Identity
{
    public class AppRoleStore : IRoleStore<AppRole>
    {
        private IRoleQueryEntry _roleQueryEntry;

        public AppRoleStore(IRoleQueryEntry roleQueryEntry)
        {
            if (roleQueryEntry == null)
                throw new ArgumentNullException(nameof(roleQueryEntry));
            _roleQueryEntry = roleQueryEntry;
        }

        public Task<IdentityResult> CreateAsync(AppRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(AppRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        public async Task<AppRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            Guid id;
            if (!Guid.TryParse(roleId, out id))
                throw new ArgumentException($"{nameof(roleId)} not a guid");
            var item = await _roleQueryEntry.FindAsync(id);
            if (item == null)
                return null;
            return new AppRole() { Id = item.Id, Code = item.Code, Title = item.Title };
        }

        public async Task<AppRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            var item = await _roleQueryEntry.FindByCodeAsync(normalizedRoleName);
            if (item == null)
                return null;
            return new AppRole() { Id = item.Id, Code = item.Code, Title = item.Title };
        }

        public Task<string> GetNormalizedRoleNameAsync(AppRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Title);
        }

        public Task<string> GetRoleIdAsync(AppRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Id.ToString());
        }

        public Task<string> GetRoleNameAsync(AppRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Title);
        }

        public Task SetNormalizedRoleNameAsync(AppRole role, string normalizedName, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Title);
        }


        #region 不实现

        public Task SetRoleNameAsync(AppRole role, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(AppRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
