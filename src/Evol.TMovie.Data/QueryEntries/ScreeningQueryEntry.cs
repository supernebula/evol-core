using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.QueryEntries;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.Common;
using Evol.EntityFramework.Repository;

namespace Evol.TMovie.Data.QueryEntries
{
    public class ScreeningQueryEntry : BaseEntityFrameworkQuery<Screening, TMovieDbContext>, IScreeningQueryEntry
    {
        public ScreeningQueryEntry(IEfDbContextProvider efDbContextProvider) : base(efDbContextProvider)
        {
        }

        public async Task<List<Screening>> SelectAsync(ScreeningQueryParameter param)
        {
            var items = await base.SelectAsync(e => e.CinemaId == param.CinemaId);
            return items.ToList();
        }


        public async Task<IPaged<Screening>> PagedAsync(ScreeningQueryParameter param, int pageIndex, int pageSize)
        {
            var result = await base.PagedAsync(e => e.CinemaId == param.CinemaId, pageIndex, pageSize);
            return result;
        }

    }
}
