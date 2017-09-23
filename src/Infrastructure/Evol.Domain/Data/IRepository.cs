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


        //T Find(Guid id);

        Task<T> FindAsync(Guid id);

        Task<IEnumerable<T>> SelectAsync(Guid[] ids);

        T Find(Expression<Func<T, bool>> predicate);

        Task<T> FindAsync(Expression<Func<T, bool>> predicate);

        IQueryable<T> Query();

        //IEnumerable<T> Retrieve(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> RetrieveAsync(Expression<Func<T, bool>> predicate);

        Task InsertAsync(T entity);

        Task UpdateAsync(T item);

        Task DeleteAsync(T item);

        Task DeleteAsync(Guid id);

        //IPaged<T> Paged(int index, int size);

        Task<IPaged<T>> PagedAsync(int pageIndex, int pageSize);

        //IPaged<T> Paged(Expression<Func<T, bool>> predicate, int index, int size);

        Task<IPaged<T>> PagedAsync(Expression<Func<T, bool>> predicate, int pageIndex, int pageSize);

    }
}
