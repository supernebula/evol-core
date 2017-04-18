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
    public abstract class BaseEntityFrameworkQuery<T, TDbContext> where TDbContext : DbContext where T : class, IPrimaryKey
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

        public async Task<IPaged<T>> PagedAsync(int pageIndex, int pageSize)
        {
            return await innerBaseRepository.PagedAsync(pageIndex, pageSize);
        }

        protected async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await innerBaseRepository.FindAsync(predicate);
        }

        protected IQueryable<T> Query()
        {
            return innerBaseRepository.Query();
        }

        protected async Task<IEnumerable<T>> RetrieveAsync(Expression<Func<T, bool>> predicate)
        {
            return await innerBaseRepository.RetrieveAsync(predicate);
        }

        protected bool Any(Expression<Func<T, bool>> predicate)
        {
            return innerBaseRepository.Any(predicate);
        }

        protected async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await innerBaseRepository.AnyAsync(predicate);
        }


        protected async Task<IPaged<T>> PagedAsync(Expression<Func<T, bool>> predicate, int pageIndex, int pageSize)
        {
            return await innerBaseRepository.PagedAsync(predicate, pageIndex, pageSize);
        }
    }


    public class InnerBaseEntityFrameworkRepository<T, TDbContext> : BaseEntityFrameworkRepository<T, TDbContext> where TDbContext : DbContext where T : class, IPrimaryKey
    {
        public InnerBaseEntityFrameworkRepository(IEfDbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
