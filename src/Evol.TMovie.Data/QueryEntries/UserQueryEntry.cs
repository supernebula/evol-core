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
using System.Linq.Expressions;

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

        public async Task<User> FindByUsernameAsync(string username)
        {
            return (await base.RetrieveAsync(e => e.Username == username)).FirstOrDefault();
        }

        public async Task<List<User>> RetrieveAsync(UserQueryParameter param)
        {
            Expression<Func<User, bool>> query = null;
            if (param != null && !string.IsNullOrWhiteSpace(param.Key))
                query = e => e.Username.Contains(param.Key) || e.Email.Contains(param.Key) || e.Mobile.Contains(param.Key) || e.RealName.Contains(param.Key);
            else
                query = e => true;

            var list = (await base.RetrieveAsync(query)).ToList();
            return list;
        }

        public async Task<IPaged<User>> PagedAsync(UserQueryParameter param, int pageIndex, int pageSize)
        {
            Expression<Func<User, bool>> query = null;
            if (param != null && !string.IsNullOrWhiteSpace(param.Key))
                query = e => e.Username.Contains(param.Key) || e.Email.Contains(param.Key) || e.Mobile.Contains(param.Key) || e.RealName.Contains(param.Key);
            else
                query = e => true;

            var result = await base.PagedAsync(query, pageIndex, pageSize);
            return result;
        }


    }
}
