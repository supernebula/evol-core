using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evol.TMovie.Domain.Models.Entities;
using Evol.TMovie.Domain.QueryEntries;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.Common;

namespace Evol.TMovie.Data.QueryEntries
{
    public class SeatQueryEntry : ISeatQueryEntry
    {

        public Task<Seat> FetchAsync(Guid id)
        {
            throw new NotImplementedException();
        }


        public Task<List<Seat>> RetrieveAsync(ActorQueryParameter param)
        {
            throw new NotImplementedException();
        }


        public Task<IPaged<Seat>> PagedAsync(ActorQueryParameter param, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
