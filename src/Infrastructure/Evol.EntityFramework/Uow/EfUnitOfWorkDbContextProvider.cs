using Evol.Domain;
using Evol.Domain.Uow;
using Evol.EntityFramework.Uow;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace Evol.EntityFramework.Repository
{
    public class EfUnitOfWorkDbContextProvider : IEfDbContextProvider
    {
        public IUnitOfWorkManager UowManager
        {
            get;
            private set;
        }

        //public EfUnitOfWorkDbContextProvider(IUnitOfWork uow)
        //{
        //    UnitOfWork = uow;
        //}

        public EfUnitOfWorkDbContextProvider(IUnitOfWorkManager uowManager, ILoggerFactory logger)
        {
            UowManager = uowManager;
            logger.CreateLogger<EfUnitOfWorkDbContextProvider>().LogDebug("CONSTRUCT> EfUnitOfWorkDbContextProvider");
        }

        public TDbContext Get<TDbContext>() where TDbContext : DbContext
        {
            TDbContext context;
            if (UowManager.Current == null)
            {
                context = AppConfig.Current.IoCManager.GetService<TDbContext>();
                return context;
            }

            context = UowManager.Current.GetDbContext<TDbContext>();
            if (context != null)
                return context;
            context = AppConfig.Current.IoCManager.GetService<TDbContext>();
            UowManager.Current.AddDbContext(context);
            return context;
        }
    }
}
