using Evol.UnitOfWork.Abstractions;
using Evol.Common.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Evol.Dapper.Uow
{
    public class DapperUnitOfWork : UnitOfWorkBase
    {

        public Dictionary<string, IDbTransaction> Transactions { get; }

        public Dictionary<string, DapperDbContext> ActiveDbContexts { get; }

        private delegate void OnDbContextAdded(DapperDbContext context);

        private OnDbContextAdded _dbContextAddedEvent = null;

        public DapperUnitOfWork(ILoggerFactory logger)
        {
            ActiveDbContexts = new Dictionary<string, DapperDbContext>();
            Transactions = new Dictionary<string, IDbTransaction>();
            logger.CreateLogger<DapperUnitOfWork>().LogDebug("CONSTRUCT> EfUnitOfWork");
        }

        protected override void BeginUow()
        {
            _dbContextAddedEvent += context =>
            {
                if (Option.IsolationLevel == null)
                    Option.IsolationLevel = IsolationLevel.ReadCommitted;

                if (Option.IsolationLevel != null)
                {
                    var trans = context.DbConnection.BeginTransaction(); //为实现事务级别设置
                    Transactions.Add(context.GetType().Name, trans);
                }
            };
        }

        protected override Task CommitUowAsync()
        {
            bool exceptioned = false;
            Exception exception = null;
            foreach (var trans in Transactions.Values)
            {
                try
                {
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    exception = ex;
                    exceptioned = true;
                    break;
                }
            }

            if (exceptioned)
            {
                Rollback();
                throw exception;
            }
            return Task.FromResult(0);
        }


        public override void Rollback()
        {
            //todo: 后续升级为分布式事务
            foreach (var trans in Transactions.Values)
            {
                trans.Rollback();
            }

            Child?.Rollback();
            Parent?.Rollback();
        }

        /// <summary>
        /// <see cref="DbContextExtensions"/>
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public DapperDbContext GetDbContext(string key)
        {
            if (!ActiveDbContexts.ContainsKey(key))
                return null;
            DapperDbContext context;
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

        public void AddDbContext(DapperDbContext dbContext)
        {
            if (ActiveDbContexts.ContainsKey(dbContext.GetKey()))
                return;
            ActiveDbContexts.Add(dbContext.GetKey(), dbContext);
            if (_dbContextAddedEvent != null)
                _dbContextAddedEvent(dbContext);
        }

        public override void AddDbContext<TDbContext>(TDbContext dbContext)
        {
            var context = dbContext as DapperDbContext;
            AddDbContext(context);
        }


    }
}
