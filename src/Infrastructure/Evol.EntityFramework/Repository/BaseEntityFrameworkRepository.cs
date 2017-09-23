using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Evol.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Evol.EntityFramework.Repository
{
    /// <summary>
    /// 基础仓储
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TDbContext"></typeparam>
    public abstract class BaseEntityFrameworkRepository<T, TDbContext> where TDbContext : DbContext where T : class, IPrimaryKey, new()
    {
        private TDbContext _context;

        //[Dependency]
        public IEfDbContextProvider DbContextProvider { get; set; }

        private DbContext Context
        {
            get
            {
                return _context = _context ?? DbContextProvider.Get<TDbContext>();
            }
        }

        public DbSet<T> DbSet => Context.Set<T>();

        public DatabaseFacade Database => Context.Database;

        protected BaseEntityFrameworkRepository(IEfDbContextProvider dbContextProvider)
        {
            DbContextProvider = dbContextProvider;
        }

        public void Insert(T item)
        {
            DbSet.Add(item);
        }

        public async Task InsertAsync(T item)
        {
            await DbSet.AddAsync(item);
        }

        public void InsertRange(IEnumerable<T> items)
        {
            DbSet.AddRange(items);
        }

        public async Task InsertRangeAsync(IEnumerable<T> items)
        {
            await DbSet.AddRangeAsync(items);
        }

        public Task DeleteAsync(T item)
        {
            DbSet.Remove(item);
            return Task.FromResult(1);
        }

        public Task DeleteAsync(Guid id)
        {
            //方式一: 先创建附加，再删除。一次数据库操作
            var delObj = new T() { Id = id };
            DbSet.Attach(delObj);
            DbSet.Remove(delObj);
            return Task.FromResult(1);

            ////方式二： 先查找，在删除（EF官方推荐）。两次数据库操作
            //var item = await DbSet.FindAsync(id);
            //DbSet.Remove(item);


        }

        public void Save()
        {
            //wait for Context.SaveChange(),  item is being tracked object
        }

        public T Find(Guid id)
        {
            return DbSet.Find(id);
        }
        public async Task<T> FindAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }


        public async Task<List<T>> SelectAsync(Guid[] ids)
        {
            return await DbSet.Where(e => ids.Contains(e.Id)).ToListAsync();
        }


        public T Find(Expression<Func<T, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.Where(predicate).FirstOrDefaultAsync();
        }



        public IQueryable<T> Query()
        {
            return DbSet.AsQueryable();
        }


        public IEnumerable<T> Retrieve(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public async Task<IEnumerable<T>> RetrieveAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
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

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Any(predicate);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.AnyAsync(predicate);
        }

        public IPaged<T> Paged(int pageIndex, int pageSize)
        {
            var total = DbSet.Count();
            var list = DbSet.OrderBy(e => e.Id).Skip(pageIndex*(pageSize - 1)).Take(pageSize).ToList();
            var paged = new PagedList<T>(list, total, pageIndex, pageSize);
            return paged;
        }

        public async Task<IPaged<T>> PagedAsync(int pageIndex, int pageSize)
        {
            var total = await DbSet.CountAsync();
            var list = await DbSet.OrderBy(e => e.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            var paged = new PagedList<T>(list, total, pageIndex, pageSize);
            return paged;
        }

        public IPaged<T> Paged(Expression<Func<T, bool>> predicate, int pageIndex, int pageSize)
        {
            var total = DbSet.Count(predicate);
            var list = DbSet.OrderBy(e => e.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
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
    }
}
