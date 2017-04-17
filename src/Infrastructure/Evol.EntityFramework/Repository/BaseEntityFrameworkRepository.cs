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
    public abstract class BaseEntityFrameworkRepository<T, TDbContext> where TDbContext : DbContext where T : class, IPrimaryKey
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

        public void Delete(T item)
        {
            DbSet.Remove(item);
        }

        public void Delete(Guid id)
        {
            var item = Find(id);
            Delete(item);
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
            var list = await DbSet.OrderBy(e => e.Id).Skip(pageIndex * (pageSize - 1)).Take(pageSize).ToListAsync();
            var paged = new PagedList<T>(list, total, pageIndex, pageSize);
            return paged;
        }

        public IPaged<T> Paged(Expression<Func<T, bool>> predicate, int pageIndex, int pageSize)
        {
            var total = DbSet.Count(predicate);
            var list = DbSet.OrderBy(e => e.Id).Skip(pageIndex * (pageSize - 1)).Take(pageSize).ToList();
            var paged = new PagedList<T>(list, total, pageIndex, pageSize);
            return paged;
        }

        public async Task<IPaged<T>> PagedAsync(Expression<Func<T, bool>> predicate, int pageIndex, int pageSize)
        {
            var total = await DbSet.CountAsync(predicate);
            var list = await DbSet.Where(predicate).OrderBy(e => e.Id).Skip(pageIndex * (pageIndex - 1)).Take(pageSize).ToListAsync();
            var paged = new PagedList<T>(list, total, pageIndex, pageSize);
            return paged;
        }
    }
}
