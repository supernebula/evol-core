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
    public class ScreeningQueryEntry : IScreeningQueryEntry
    {

        public Task<Screening> FetchAsync(Guid id)
        {
            throw new NotImplementedException();
        }


        public Task<List<Screening>> RetrieveAsync(ScreeningQueryParameter param)
        {
            throw new NotImplementedException();
        }


        public Task<IPaged<Screening>> PagedAsync(ScreeningQueryParameter param, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
