using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Evol.Common;
using Microsoft.EntityFrameworkCore;

namespace Evol.EntityFrameworkCore.MySql.Repository
{
    public class NormalEntityFrameworkCoreRepository<T, TDbContext> : IDisposable where TDbContext : DbContext where T : class, IPrimaryKey
    {
        private readonly TDbContext _context;
        public NormalEntityFrameworkCoreRepository(TDbContext context)
        {
            _context = context;
        }

        protected DbSet<T> DbSet => _context.Set<T>();

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task InsertAsync(T item)
        {
            await DbSet.AddAsync(item);
        }

        public async Task InsertRangeAsync(IEnumerable<T> items)
        {
            await DbSet.AddRangeAsync(items);
        }

        public Task DeleteAsync(T item)
        {
            DbSet.Remove(item);
            return Task.FromResult(0);
        }

        public async Task<T> FindAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.FirstOrDefaultAsync(predicate);
        }

        public IQueryable<T> Query()
        {
            return DbSet.AsQueryable();
        }

        public async Task<IEnumerable<T>> RetrieveAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public void Update(T item)
        {
            //启用实体跟踪
            //外部执行 _context.SaveChanges();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.AnyAsync(predicate);
        }

        public async Task<List<T>> SelectAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public async Task<List<T>> SelectAsync(Func<IQueryable<T>, IQueryable<T>> condition)
        {
            var query = Query();
            query = condition.Invoke(query);
            var items = await query.ToListAsync();
            return items;
        }

        public async Task<IPaged<T>> PagedAsync(int pageIndex, int pageSize)
        {
            var total = await DbSet.CountAsync();
            var queryable = DbSet.Skip(pageSize * (pageIndex - 1)).Take(pageSize).AsQueryable();
            var items = await queryable.ToListAsync();
            var result = new PagedList<T>(items, total, pageIndex, pageSize);
            return result;
        }

        public async Task<IPaged<T>> PagedAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, bool>> order, int pageIndex, int pageSize)
        {
            var total = await DbSet.Where(predicate).OrderBy(order).CountAsync();
            var queryable = DbSet.Where(predicate).OrderBy(order).Skip(pageSize * (pageIndex - 1)).Take(pageSize).AsQueryable();
            var items = await queryable.ToListAsync();
            var result = new PagedList<T>(items, total, pageIndex, pageSize);
            return result;
        }

        public async Task<IPaged<T>> PagedAsync(Func<IQueryable<T>, IQueryable<T>> condition, int pageIndex, int pageSize)
        {
            var query = Query();
            query = condition.Invoke(query);

            var total = await query.CountAsync();
            var skip = (pageIndex - 1) * pageSize;
            if (skip > 0)
                query = query.Skip(skip);
            var list = await query.Take(pageSize).OrderBy(e => e.Id).ToListAsync();
            var paged = new PagedList<T>(list, total, pageIndex, pageSize);
            return paged;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
