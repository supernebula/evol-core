using Evol.Common;
using Evol.EntityFramework.Repository;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.QueryEntries;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evol.TMovie.Data.QueryEntries
{
    public class OrderQueryEntry : BaseEntityFrameworkQuery<Order, TMovieDbContext>, IOrderQueryEntry
    {

        public IOrderDetailQueryEntry OrderDetailQueryEntry { get; set; }

        public OrderQueryEntry(IEfDbContextProvider efDbContextProvider, IOrderDetailQueryEntry orderDetailQueryEntry) 
            : base(efDbContextProvider)
        {
            OrderDetailQueryEntry = orderDetailQueryEntry;
        }

        public async Task<Order> FindByOrderNoAsync(string orderNo)
        {
            var item = await base.FindAsync(e => e.No == orderNo);
            return item;
        }

        public async Task<List<Order>> SelectAsync(OrderQueryParameter param)
        {

            var result = await SelectAsync(query => {
                if (!string.IsNullOrWhiteSpace(param.No))
                    query = query.Where(e => e.No ==param.No);
                if (param.UserId != null)
                    query = query.Where(e => e.UserId == (param.UserId.Value));
                if (!string.IsNullOrWhiteSpace(param.Title))
                    query = query.Where(e => e.Title.Contains(param.Title));
                if (param.MinAmount != null)
                    query = query.Where(e => e.Amount >= (param.MinAmount.Value));
                if (param.MaxAmount != null)
                    query = query.Where(e => e.Amount <= (param.MaxAmount.Value));
                if (param.StartPayTime != null)
                    query = query.Where(e => e.PayTime >= param.StartPayTime.Value);
                if (param.EndPayTime != null)
                    query = query.Where(e => e.PayTime >= param.EndPayTime.Value);
                return query;
            });

            return result.ToList();
        }

        public async Task<IPaged<Order>> PagedAsync(OrderQueryParameter param, int pageIndex, int pageSize)
        {
            var result = await base.PagedAsync(query => {
                if (!string.IsNullOrWhiteSpace(param.No))
                    query = query.Where(e => e.No == param.No);
                if (param.UserId != null)
                    query = query.Where(e => e.UserId == (param.UserId.Value));
                if (!string.IsNullOrWhiteSpace(param.Title))
                    query = query.Where(e => e.Title.Contains(param.Title));
                if (param.MinAmount != null)
                    query = query.Where(e => e.Amount >= (param.MinAmount.Value));
                if (param.MaxAmount != null)
                    query = query.Where(e => e.Amount <= (param.MaxAmount.Value));
                if (param.StartPayTime != null)
                    query = query.Where(e => e.PayTime >= param.StartPayTime.Value);
                if (param.EndPayTime != null)
                    query = query.Where(e => e.PayTime >= param.EndPayTime.Value);
                return query;
            }, pageIndex, pageSize);

            return result;
        }

        public Task<List<Order>> GetByIdsAsync(Guid[] ids)
        {
            var items = base.SelectAsync(ids);
            return items;
        }
    }
}
