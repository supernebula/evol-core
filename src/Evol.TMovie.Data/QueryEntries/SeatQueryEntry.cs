using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evol.TMovie.Domain.Models.Entities;
using Evol.TMovie.Domain.QueryEntries;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.Common;
using Evol.TMovie.Domain.Models.Entities;

namespace Evol.TMovie.Data.QueryEntries
{
    public class SeatQueryEntry : ISeatQueryEntry
    {
        public Seat Fetch(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Seat> FetchAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Seat> Retrieve(ActorQueryParameter param)
        {
            throw new NotImplementedException();
        }

        public Task<List<Seat>> RetrieveAsync(ActorQueryParameter param)
        {
            throw new NotImplementedException();
        }

        public IPaged<Seat> RetrievePaged(ActorQueryParameter param)
        {
            throw new NotImplementedException();
        }

        public Task<IPaged<Seat>> RetrievePagedAsync(ActorQueryParameter param)
        {
            throw new NotImplementedException();
        }
    }
}
