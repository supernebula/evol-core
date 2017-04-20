using Evol.Common;
using Evol.Domain.Data;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evol.TMovie.Domain.QueryEntries
{
    public interface IUserQueryEntry : IQueryEntry
    {

        Task<User> FindAsync(Guid id);

        Task<User> FindByUsernameAsync(string username);

        Task<List<User>> RetrieveAsync(UserQueryParameter param);


        Task<IPaged<User>> PagedAsync(UserQueryParameter param, int pageIndex, int pageSize);

        Task<List<User>> GetByIdsAsync(Guid[] ids);
    }
}
