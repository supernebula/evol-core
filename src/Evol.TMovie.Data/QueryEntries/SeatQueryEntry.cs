using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evol.TMovie.Domain.Models.Entities;
using Evol.TMovie.Domain.QueryEntries;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.Common;
using Evol.EntityFramework.Repository;

namespace Evol.TMovie.Data.QueryEntries
{
    public class SeatQueryEntry : BaseEntityFrameworkQuery<Seat, TMovieDbContext>, ISeatQueryEntry
    {

        public SeatQueryEntry(IEfDbContextProvider efDbContextProvider) : base(efDbContextProvider)
        {
        }

        public Task<IPaged<Seat>> PagedAsync(SeatQueryParameter param, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<List<Seat>> SelectAsync(SeatQueryParameter param)
        {
            throw new NotImplementedException();
        }
    }
}
