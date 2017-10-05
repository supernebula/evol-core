using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public Task<List<Screening>> SelectAsync(ScreeningQueryParameter param)
        {
            throw new NotImplementedException();
        }


        public Task<IPaged<Screening>> PagedAsync(ScreeningQueryParameter param, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

    }
}
