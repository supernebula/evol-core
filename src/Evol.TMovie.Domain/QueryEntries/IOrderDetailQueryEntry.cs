using Evol.Domain.Data;
using Evol.TMovie.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evol.TMovie.Domain.QueryEntries
{
    public interface IOrderDetailQueryEntry : IQueryEntry
    {

        Task<OrderDetail> FindAsync(Guid id);

        Task<List<OrderDetail>> FindByOrderNoAsync(string orderNo);

        Task<List<OrderDetail>> FindByOrderIdAsync(Guid orderId);

        Task<List<OrderDetail>> GetByIdsAsync(Guid[] ids);
    }
}
