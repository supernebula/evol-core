using System;
using System.Data.Entity;
using Evol.Common.Logging;
using Evol.Common.IoC;
using Evol.UnitOfWork.Abstractions;

namespace Evol.Fx.EntityFramework.Repository
{
    public class EfUnitOfWorkDbContextProvider : IEfUnitOfWorkDbContextProvider
    {
        private IIoCManager _ioCManager;

        private IUnitOfWorkManager _uowManager;

        public EfUnitOfWorkDbContextProvider(IUnitOfWorkManager uowManager, IIoCManager ioCManager, ILoggerFactory logger)
        {
            if (uowManager == null)
                throw new ArgumentNullException(nameof(uowManager));
            if(ioCManager == null)
                throw new ArgumentNullException(nameof(_ioCManager));

            _ioCManager = ioCManager;
            _uowManager = uowManager;
            logger.CreateLogger<EfUnitOfWorkDbContextProvider>().LogDebug("CONSTRUCT> EfUnitOfWorkDbContextProvider");
        }

        public TDbContext Get<TDbContext>() where TDbContext : DbContext
        {
            TDbContext context;
            if (_uowManager.Current == null)
            {
                context = _ioCManager.GetService<TDbContext>();
                return context;
            }

            context = _uowManager.Current.GetDbContext<TDbContext>();
            if (context != null)
                return context;
            context = _ioCManager.GetService<TDbContext>();
            _uowManager.Current.AddDbContext(context);
            return context;
        }
    }
}
