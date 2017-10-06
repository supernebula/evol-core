using Evol.Common;
using Evol.Domain.Data;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evol.TMovie.Domain.QueryEntries
{
    public interface IOrderQueryEntry : IQueryEntry
    {

        Task<Order> FindAsync(Guid id);

        Task<Order> FindByOrderNoAsync(string orderNo);

        Task<List<Order>> SelectAsync(OrderQueryParameter param);


        Task<IPaged<Order>> PagedAsync(OrderQueryParameter param, int pageIndex, int pageSize);

        Task<List<Order>> GetByIdsAsync(Guid[] ids);
    }
}
