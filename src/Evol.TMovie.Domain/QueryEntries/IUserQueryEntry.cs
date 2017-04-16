using Evol.Common;
using Evol.Domain.Data;
using Evol.TMovie.Domain.Models.AggregateRoots;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evol.TMovie.Domain.QueryEntries
{
    public interface IUserQueryEntry : IQueryEntry
    {

        Task<User> FetchAsync(Guid id);

        Task<List<User>> RetrieveAsync(UserQueryParameter param);


        Task<IPaged<User>> RetrievePagedAsync(UserQueryParameter param, int pageIndex, int pageSize);
    }
}
