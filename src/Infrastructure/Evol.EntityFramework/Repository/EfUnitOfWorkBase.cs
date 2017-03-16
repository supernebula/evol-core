using System;
using System.Collections.Generic;

namespace Evol.EntityFramework.Repository
{
    public abstract class EfUnitOfWorkBase : IEfUnitOfWork, IEfActiveUnitOfWork
    {
        public bool IsDisposed { get; protected set; }

        public bool IsCommited { get; protected set; }

        public Dictionary<string, DbContextTransaction> Transactions { get; }

        public Dictionary<string, NamedDbContext> ActiveDbContexts { get; }

        protected IUnitOfWorkOptions UnitOfWorkOptions { get; set; }

        protected EfUnitOfWorkBase()
        {
            ActiveDbContexts = new Dictionary<string, NamedDbContext>();
            Transactions = new Dictionary<string, DbContextTransaction>();
        }
        private delegate void OnDbContextAdded(NamedDbContext context);

        private OnDbContextAdded _dbContextAddedEvent = (context) => { };

        public virtual void BeginTransaction(IUnitOfWorkOptions unitOfWorkOptions)
        {
            _dbContextAddedEvent += context =>
            {
                if (unitOfWorkOptions.IsolationLevel == null)
                    unitOfWorkOptions.IsolationLevel = System.Data.IsolationLevel.ReadCommitted;

                UnitOfWorkOptions = unitOfWorkOptions;
                if (UnitOfWorkOptions.IsolationLevel != null)
                {
                    var tran = context.Database.BeginTransaction(UnitOfWorkOptions.IsolationLevel.Value);
                    Transactions.Add(context.Name, tran);
                }
            };
        }

        public virtual void Commit()
        {
            try
            {
                foreach (var context in ActiveDbContexts.Values)
                {
                    context.SaveChanges();
                    DbContextTransaction tran;
                    if (Transactions.TryGetValue(context.Name, out tran))
                        tran.Commit();
                }
                IsCommited = true;
            }
            catch (Exception ex)
            {
                //logger.Error(ex, "UnitOfWork Commit Error");
                throw ex;
            }
        }

        public virtual void Dispose()
        {
            ActiveDbContexts.Values.ForEach(c => c.Dispose());
            Transactions.Values.ForEach(t => t.Dispose());
        }

        public virtual void RollBack()
        {
            Transactions.Values.ForEach(t => t.Rollback());
        }

        public virtual void AddDbContext(string name, NamedDbContext dbContext)
        {
            if (ActiveDbContexts.ContainsKey(name))
                return;
            ActiveDbContexts.Add(name, dbContext);
            _dbContextAddedEvent(dbContext);
        }

        public virtual NamedDbContext GetDbContext(string name)
        {
            if (!ActiveDbContexts.ContainsKey(name))
                return null;
            NamedDbContext context;
            ActiveDbContexts.TryGetValue(name, out context);
            return context;
        }
    }
}
