using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Evol.Common;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.QueryEntries;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.TMovie.Domain.Repositories;
using Evol.EntityFramework.Repository;

namespace Evol.TMovie.Data.QueryEntries
{
    public class UserQueryEntry : BaseEntityFrameworkQuery<User, TMovieDbContext>, IUserQueryEntry
    {
        public UserQueryEntry(IEfDbContextProvider efDbContextProvider) : base(efDbContextProvider)
        {
        }

        public async Task<List<User>> GetByIdsAsync(Guid[] ids)
        {
            return (await base.RetrieveAsync(e => ids.Contains(e.Id))).ToList();
        }

        public async Task<List<User>> RetrieveAsync(UserQueryParameter param)
        {
            if (param == null)
                throw new ArgumentNullException(nameof(param));
            if (param.Key == null)
                throw new ArgumentNullException((nameof(param.Key)));

            var list = (await base.RetrieveAsync(e => e.Username.StartsWith(param.Key) || e.RealName.StartsWith(param.Key) || e.Mobile.StartsWith(param.Key) || e.Email.StartsWith(param.Key))).ToList();
            return list;
        }

        public async Task<IPaged<User>> PagedAsync(UserQueryParameter param, int pageIndex, int pageSize)
        {
            if (param == null)
                throw new ArgumentNullException(nameof(param));
            if (param.Key == null)
                throw new ArgumentNullException((nameof(param.Key)));

            var result = await base.PagedAsync(e => e.Username.StartsWith(param.Key) || e.RealName.StartsWith(param.Key) || e.Mobile.StartsWith(param.Key) || e.Email.StartsWith(param.Key), pageIndex, pageSize);
            return result;
        }
    }
}
