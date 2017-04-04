using Evol.Domain.Uow;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Evol.EntityFramework.Uow
{
    public class EfUnitOfWork : UnitOfWorkBase
    {

        public Dictionary<string, IDbContextTransaction> Transactions { get; }

        public Dictionary<string, NamedDbContext> ActiveDbContexts { get; }

        private delegate void OnDbContextAdded(NamedDbContext context);

        private OnDbContextAdded _dbContextAddedEvent = null;

        public EfUnitOfWork()
        {
            ActiveDbContexts = new Dictionary<string, NamedDbContext>();
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
                    Transactions.Add(context.Name, trans);
                }
            };
        }

        public async override Task SaveChangesAsync()
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

        protected override Task CommitUowAsync()
        {
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
            return Task.FromResult(0);
        }


        public void AddDbContext(NamedDbContext dbContext)
        {
            if (ActiveDbContexts.ContainsKey(dbContext.Name))
                return;
            ActiveDbContexts.Add(dbContext.Name, dbContext);
            _dbContextAddedEvent(dbContext);
        }

        public NamedDbContext GetDbContext(string name)
        {
            if (!ActiveDbContexts.ContainsKey(name))
                return null;
            NamedDbContext context;
            ActiveDbContexts.TryGetValue(name, out context);
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

        public override void AddDbContext<TDbContext>(string name, TDbContext dbContext)
        {
            ActiveDbContexts.Add(name, dbContext as NamedDbContext);
        }
    }
}
