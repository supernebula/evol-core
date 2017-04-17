using Evol.Domain;
using Evol.Domain.Uow;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Evol.EntityFramework.Uow
{
    public class EfUnitOfWorkManager : IUnitOfWorkManager
    {


        private IServiceProvider ServiceProvider { get; set; }

        public EfUnitOfWorkManager(IServiceProvider serviceProvider, ILoggerFactory logger)
        {
            ServiceProvider = serviceProvider;
            logger.CreateLogger<EfUnitOfWorkManager>().LogDebug("CONSTRUCT> EfUnitOfWorkManager");
        }

        public IUnitOfWork _current;
        public IActiveUnitOfWork Current
        {
            get
            {
                return _current;
            }
        }

        public IUnitOfWork Build()
        {
            if (_current != null)
                return _current;
            _current = ServiceProvider.GetService<IUnitOfWork>();
            return _current;
        }
    }
}
