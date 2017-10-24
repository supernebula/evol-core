using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Evol.Common;

namespace Evol.Domain.Data
{
    public interface IRepository<T> where T : IPrimaryKey
    {

        Task<T> FindAsync(Guid id);

        Task<T> FindAsync(Expression<Func<T, bool>> predicate);

        Task<List<T>> SelectAsync(Guid[] ids);

        Task<List<T>> SelectAsync(Expression<Func<T, bool>> predicate);

        IQueryable<T> Query();

        Task InsertAsync(T entity);

        Task InsertRangeAsync(IEnumerable<T> items);

        Task UpdateAsync(T item);

        Task DeleteAsync(T item);

        Task DeleteAsync(Guid id);

        Task<IPaged<T>> PagedAsync(int pageIndex, int pageSize);

        Task<IPaged<T>> PagedAsync(Expression<Func<T, bool>> predicate, int pageIndex, int pageSize);

    }
}
