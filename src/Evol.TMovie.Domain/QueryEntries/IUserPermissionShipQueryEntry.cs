using Evol.Common;
using Evol.Domain.Data;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.Models.Entities;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Evol.Common.Data;

namespace Evol.TMovie.Domain.QueryEntries
{
    public interface IUserPermissionShipQueryEntry : IQueryEntry
    {
        Task<UserPermissionShip> FindAsync(Guid id);

        Task<IList<UserPermissionShip>> RetrieveAsync(UserPermissionShipQueryParameter param);

        Task<IPaged<UserPermissionShip>> PagedAsync(UserPermissionShipQueryParameter param, int pageIndex, int pageSize);

        Task<IList<Role>> GetRolesByUserIdAsync(Guid userId);

        Task<IList<Permission>> GetCustomPermissionsByUserIdAsync(Guid userId);

        Task<IList<User>> GetUsersByRoleIdAsync(Guid roleId);

        Task<IList<User>> GetUsersByRoleCodeAsync(string roleCode);
    }
}
