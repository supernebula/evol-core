using Evol.Configuration;
using Evol.Domain.Uow;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace Evol.EntityFramework.Repository
{
    public class EfUnitOfWorkDbContextProvider : IEfUnitOfWorkDbContextProvider
    {
        private IUnitOfWorkManager _uowManager;

        public EfUnitOfWorkDbContextProvider(IUnitOfWorkManager uowManager, ILoggerFactory logger)
        {
            if (uowManager == null)
                throw new ArgumentNullException(nameof(uowManager));

            _uowManager = uowManager;
            logger.CreateLogger<EfUnitOfWorkDbContextProvider>().LogDebug("CONSTRUCT> EfUnitOfWorkDbContextProvider");
        }

        public TDbContext Get<TDbContext>() where TDbContext : DbContext
        {
            TDbContext context;
            if (_uowManager.Current == null)
            {
                context = AppConfig.Current.IoCManager.GetService<TDbContext>();
                return context;
            }

            context = _uowManager.Current.GetDbContext<TDbContext>();
            if (context != null)
                return context;
            context = AppConfig.Current.IoCManager.GetService<TDbContext>();
            _uowManager.Current.AddDbContext(context);
            return context;
        }
    }
}
