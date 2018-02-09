using Evol.Dapper.Repository;
using Evol.UnitOfWork.Abstractions;
using Evol.Common.Logging;
using Evol.Common.IoC;
using System;

namespace Evol.Dapper.Uow
{
    public class DapperUnitOfWorkDbContextProvider : IDapperUnitOfWorkDbContextProvider
    {

        private IIoCManager _ioCManager;

        public IUnitOfWorkManager UowManager { get; private set; }

        public DapperUnitOfWorkDbContextProvider(IUnitOfWorkManager uowManager, IIoCManager ioCManager, ILoggerFactory logger)
        {
            if (ioCManager == null)
                throw new ArgumentNullException(nameof(_ioCManager));

            UowManager = uowManager;
            logger.CreateLogger<DapperUnitOfWorkDbContextProvider>().LogDebug("CONSTRUCT> EfUnitOfWorkDbContextProvider");
        }

        public TDbContext Get<TDbContext>() where TDbContext : DapperDbContext
        {
            TDbContext context;
            if (UowManager.Current == null)
            {
                context = _ioCManager.GetService<TDbContext>();
                return context;
            }

            context = UowManager.Current.GetDbContext<TDbContext>();
            if (context != null)
                return context;
            context = _ioCManager.GetService<TDbContext>();
            UowManager.Current.AddDbContext(context);
            return context;
        }
    }
}
