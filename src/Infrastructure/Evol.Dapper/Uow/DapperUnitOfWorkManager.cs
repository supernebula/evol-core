using Evol.Domain.Uow;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Evol.Dapper.Uow
{
    public class DapperUnitOfWorkManager : IUnitOfWorkManager
    {


        private IServiceProvider ServiceProvider { get; set; }

        public DapperUnitOfWorkManager(IServiceProvider serviceProvider, ILoggerFactory logger)
        {
            ServiceProvider = serviceProvider;
            logger.CreateLogger<DapperUnitOfWorkManager>().LogDebug("CONSTRUCT> DapperUnitOfWorkManager");
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
