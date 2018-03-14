using System;
using Microsoft.EntityFrameworkCore;
using Evol.Common.Logging;
using Evol.Common.IoC;
using Evol.UnitOfWork.Abstractions;
using Evol.EntityFrameworkCore.MySql.Repository;

namespace Evol.EntityFrameworkCore.MySql.Uow
{
    public class EfCoreUnitOfWorkDbContextProvider : IEfCoreUnitOfWorkDbContextProvider
    {
        private IIoCManager _ioCManager;

        private IUnitOfWorkManager _uowManager;

        public EfCoreUnitOfWorkDbContextProvider(IUnitOfWorkManager uowManager, IIoCManager ioCManager, ILoggerFactory logger)
        {
            if (uowManager == null)
                throw new ArgumentNullException(nameof(uowManager));
            if(ioCManager == null)
                throw new ArgumentNullException(nameof(_ioCManager));

            _ioCManager = ioCManager;
            _uowManager = uowManager;
            logger.CreateLogger<EfCoreUnitOfWorkDbContextProvider>().LogDebug("CONSTRUCT> EfUnitOfWorkDbContextProvider");
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
