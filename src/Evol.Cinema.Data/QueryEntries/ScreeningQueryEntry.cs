using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evol.Cinema.Domain.Models.AggregateRoots;
using Evol.Cinema.Domain.QueryEntries;
using Evol.Cinema.Domain.QueryEntries.Parameters;
using Evol.Common;

namespace Evol.Cinema.Data.QueryEntries
{
    public class ScreeningQueryEntry : IScreeningQueryEntry
    {
        public Screening Fetch(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Screening> FetchAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Screening> Retrieve(ScreeningQueryParameter param)
        {
            throw new NotImplementedException();
        }

        public Task<List<Screening>> RetrieveAsync(ScreeningQueryParameter param)
        {
            throw new NotImplementedException();
        }

        public IPaged<Screening> RetrievePaged(ScreeningQueryParameter param)
        {
            throw new NotImplementedException();
        }

        public Task<IPaged<Screening>> RetrievePagedAsync(ScreeningQueryParameter param)
        {
            throw new NotImplementedException();
        }
    }
}
