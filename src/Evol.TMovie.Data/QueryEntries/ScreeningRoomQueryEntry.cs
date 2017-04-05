using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.QueryEntries;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.Common;

namespace Evol.TMovie.Data.QueryEntries
{
    public class ScreeningRoomQueryEntry : IScreeningRoomQueryEntry
    {
        public ScreeningRoom Fetch(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ScreeningRoom> FetchAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<ScreeningRoom> Retrieve(ScreeningRoomQueryParameter param)
        {
            throw new NotImplementedException();
        }

        public Task<List<ScreeningRoom>> RetrieveAsync(ScreeningQueryParameter param)
        {
            throw new NotImplementedException();
        }

        public IPaged<ScreeningRoom> RetrievePaged(ScreeningQueryParameter param)
        {
            throw new NotImplementedException();
        }

        public Task<IPaged<ScreeningRoom>> RetrievePagedAsync(ScreeningQueryParameter param)
        {
            throw new NotImplementedException();
        }
    }
}
