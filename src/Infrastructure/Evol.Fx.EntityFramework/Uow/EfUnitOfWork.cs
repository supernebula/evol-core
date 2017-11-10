using Evol.Domain.Uow;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Evol.Fx.EntityFramework.Uow
{
    public class EfUnitOfWork : UnitOfWorkBase
    {

        public Dictionary<string, DbContextTransaction> Transactions { get; }

        public Dictionary<string, DbContext> ActiveDbContexts { get; }

        private delegate void OnDbContextAdded(DbContext context);

        private OnDbContextAdded _dbContextAddedEvent = null;

        public EfUnitOfWork(ILoggerFactory logger)
        {
            ActiveDbContexts = new Dictionary<string, DbContext>();
            Transactions = new Dictionary<string, DbContextTransaction>();
            logger.CreateLogger<EfUnitOfWork>().LogDebug("CONSTRUCT> EfUnitOfWork");
        }

        protected override void BeginUow()
        {
            _dbContextAddedEvent += context =>
            {
                if (Option.IsolationLevel == null)
                    Option.IsolationLevel = IsolationLevel.ReadCommitted;

                if (Option.IsolationLevel != null)
                {
                    var trans = context.Database.BeginTransaction(); //为实现事务级别设置
                    Transactions.Add(context.GetType().Name, trans);
                }
            };
        }

        private async Task SaveChangesAsync()
        {
            try
            {
                foreach (var context in ActiveDbContexts.Values)
                {
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                //log
                throw ex;
            }
        }

        protected async override Task CommitUowAsync()
        {
            await SaveChangesAsync();

            bool exceptioned = false;
            Exception exception = null;
            foreach (var trans in Transactions.Values)
            {
                if (exceptioned)
                {
                    trans.Rollback();
                    continue;
                }

                try
                {
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    exception = ex;
                    exceptioned = true;
                    trans.Rollback();
                }
            }

            if(exceptioned)
                throw exception;
        }

        /// <summary>
        /// <see cref="DbContextExtensions"/>
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public DbContext GetDbContext(string key)
        {
            if (!ActiveDbContexts.ContainsKey(key))
                return null;
            DbContext context;
            ActiveDbContexts.TryGetValue(key, out context);
            return context;
        }

        public override TDbContext GetDbContext<TDbContext>()
        {
            TDbContext value = default(TDbContext);
            foreach (var item in ActiveDbContexts.Values)
            {
                if (item.GetType() == typeof(TDbContext))
                {
                    value = item as TDbContext;
                    break;
                }
            }
            return value;
        }

        public void AddDbContext(DbContext dbContext)
        {
            if (ActiveDbContexts.ContainsKey(dbContext.GetKey()))
                return;
            ActiveDbContexts.Add(dbContext.GetKey(), dbContext);
            if(_dbContextAddedEvent != null)
                _dbContextAddedEvent(dbContext);
        }

        public override void AddDbContext<TDbContext>(TDbContext dbContext)
        {
            var context = dbContext as DbContext;
            AddDbContext(context);
        }
    }
}
