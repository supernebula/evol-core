using Evol.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Evol.EntityFramework.Repository
{
    public abstract class BaseEntityFrameworkQuery<T, TDbContext> where TDbContext : DbContext where T : class, IPrimaryKey, new()
    {
        private InnerBaseEntityFrameworkRepository<T, TDbContext> innerBaseRepository;

        public BaseEntityFrameworkQuery(IEfDbContextProvider efDbContextProvider)
        {
            innerBaseRepository = new InnerBaseEntityFrameworkRepository<T, TDbContext>(efDbContextProvider);
        }

        public async Task<T> FindAsync(Guid id)
        {
            return await innerBaseRepository.FindAsync(id);
        }

        protected async Task<T> FindAsync(Expression<Func<T, bool>> condition)
        {
            return await innerBaseRepository.FindAsync(condition);
        }

        public async Task<List<T>> SelectAsync(Guid[] ids)
        {
            return await innerBaseRepository.SelectAsync(ids);
        }

        protected IQueryable<T> Query()
        {
            return innerBaseRepository.Query();
        }

        protected async Task<IEnumerable<T>> SelectAsync(Expression<Func<T, bool>> condition)
        {
            return await innerBaseRepository.SelectAsync(condition);
        }

        protected async Task<IEnumerable<T>> SelectAsync(Func<IQueryable<T>, IQueryable<T>> condition)
        {
            return await innerBaseRepository.SelectAsync(condition);
        }

        protected async Task<bool> AnyAsync(Expression<Func<T, bool>> condition)
        {
            return await innerBaseRepository.AnyAsync(condition);
        }

        protected async Task<bool> AnyAsync(Func<IQueryable<T>, IQueryable<T>> condition)
        {
            return await innerBaseRepository.AnyAsync(condition);
        }


        public async Task<IPaged<T>> PagedAsync(int pageIndex, int pageSize)
        {
            return await innerBaseRepository.PagedAsync(pageIndex, pageSize);
        }

        protected async Task<IPaged<T>> PagedAsync(Expression<Func<T, bool>> condition, int pageIndex, int pageSize)
        {
            return await innerBaseRepository.PagedAsync(condition, pageIndex, pageSize);
        }

        protected async Task<IPaged<T>> PagedAsync(Func<IQueryable<T>, IQueryable<T>> condition, int pageIndex, int pageSize)
        {
            return await innerBaseRepository.PagedAsync(condition, pageIndex, pageSize);
        }
    }


    public class InnerBaseEntityFrameworkRepository<T, TDbContext> : BaseEntityFrameworkRepository<T, TDbContext> where TDbContext : DbContext where T : class, IPrimaryKey, new()
    {
        public InnerBaseEntityFrameworkRepository(IEfDbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
