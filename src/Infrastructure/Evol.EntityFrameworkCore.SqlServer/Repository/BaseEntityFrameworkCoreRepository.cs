using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Evol.Common;
using Microsoft.EntityFrameworkCore;

namespace Evol.EntityFrameworkCore.SqlServer.Repository
{
    /// <summary>
    /// 基础仓储抽象类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TDbContext"></typeparam>
    public abstract class BaseEntityFrameworkCoreRepository<T, TDbContext> where TDbContext : DbContext where T : class, IPrimaryKey, new()
    {
        private TDbContext _context;

        //[Dependency]
        public IEfCoreDbContextProvider DbContextProvider { get; set; }

        protected DbContext Context
        {
            get
            {
                return _context = _context ?? DbContextProvider.Get<TDbContext>();
            }
        }

        public DbSet<T> DbSet => Context.Set<T>();

        protected BaseEntityFrameworkCoreRepository(IEfCoreDbContextProvider dbContextProvider)
        {
            DbContextProvider = dbContextProvider;
        }


        public Task InsertAsync(T item)
        {
            DbSet.Add(item);
            return Task.FromResult(1);
        }

        public Task InsertRangeAsync(IEnumerable<T> items)
        {
            DbSet.AddRange(items);
            return Task.FromResult(1);
        }

        public Task DeleteAsync(T item)
        {
            if (item is ISoftDelete)
            {
                //如果软删除
                var softItem = (ISoftDelete)item;
                softItem.DeleteTime = DateTime.Now;
                softItem.IsDeleted = true;
                //由工作单元自动保存到数据库
            }
            else
                DbSet.Remove(item);
            return Task.FromResult(1);
        }

        public async Task DeleteAsync(Guid id)
        {
            //方式二： 先查找，在删除（EF官方推荐）。两次数据库操作
            var item = await DbSet.FindAsync(id);
            await DeleteAsync(item);
        }

        public void Save()
        {
            //wait for Context.SaveChange(),  item is being tracked object
        }

        public async Task<T> FindAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<List<T>> SelectAsync(Guid[] ids)
        {
            return await DbSet.Where(e => ids.Contains(e.Id)).ToListAsync();
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

        public IQueryable<T> Query()
        {
            return DbSet.AsQueryable();
        }



        public void Update(T item)
        {
            //wait for Context.SaveChange(),  item is being tracked object
        }

        public Task UpdateAsync(T item)
        {
            return Task.FromResult(1);
            //wait for Context.SaveChange(),  item is being tracked object
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.AnyAsync(predicate);
        }

        public async Task<IPaged<T>> PagedAsync(int pageIndex, int pageSize)
        {
            var total = await DbSet.CountAsync();
            var list = await DbSet.OrderBy(e => e.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            var paged = new PagedList<T>(list, total, pageIndex, pageSize);
            return paged;
        }

        public async Task<IPaged<T>> PagedAsync(Expression<Func<T, bool>> predicate, int pageIndex, int pageSize)
        {
            var total = await DbSet.CountAsync(predicate);
            var skip = (pageIndex - 1) * pageSize;
            var query = DbSet.Where(predicate);
            if (skip > 0)
                query = query.Skip(skip);
            var list = await query.Take(pageSize).OrderBy(e => e.Id).ToListAsync();
            var paged = new PagedList<T>(list, total, pageIndex, pageSize);
            return paged;
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

    }
}
