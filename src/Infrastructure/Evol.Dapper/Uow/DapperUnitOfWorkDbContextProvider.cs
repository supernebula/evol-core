using Evol.Configuration;
using Evol.Dapper.Repository;
using Evol.Domain.Uow;
using Microsoft.Extensions.Logging;

namespace Evol.Dapper.Uow
{
    public class DapperUnitOfWorkDbContextProvider : IDapperUnitOfWorkDbContextProvider
    {
        public IUnitOfWorkManager UowManager
        {
            get;
            private set;
        }

        public DapperUnitOfWorkDbContextProvider(IUnitOfWorkManager uowManager, ILoggerFactory logger)
        {
            UowManager = uowManager;
            logger.CreateLogger<DapperUnitOfWorkDbContextProvider>().LogDebug("CONSTRUCT> EfUnitOfWorkDbContextProvider");
        }

        public TDbContext Get<TDbContext>() where TDbContext : DapperDbContext
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
