using Evol.Common;
using Evol.EntityFramework.Repository;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.QueryEntries;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.TMovie.Domain.Repositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evol.TMovie.Data.QueryEntries
{
    public class CinemaQueryEntry : BaseEntityFrameworkQuery<Cinema, TMovieDbContext>, ICinemaQueryEntry
    {

        public CinemaQueryEntry(IEfDbContextProvider efDbContextProvider) : base(efDbContextProvider)
        {
        }

        public async Task<List<Cinema>> RetrieveAsync(CinemaQueryParameter param)
        {
            if (param == null || string.IsNullOrWhiteSpace(param.Name))
                return new List<Cinema>();
            var items = await base.RetrieveAsync(e => e.Name.Contains(param.Name));
            return items.ToList();
        }


        public async Task<IPaged<Cinema>> PagedAsync(CinemaQueryParameter param, int pageIndex, int pageSize)
        {
            if (param == null || string.IsNullOrWhiteSpace(param.Name))
                return await base.PagedAsync(pageIndex, pageSize);
            return await base.PagedAsync(e => e.Name.Contains(param.Name), pageIndex, pageSize);
        }
    }
}
