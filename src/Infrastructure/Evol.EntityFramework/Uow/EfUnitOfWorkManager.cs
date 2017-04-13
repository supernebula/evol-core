using Evol.Domain;
using Evol.Domain.Uow;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace Evol.EntityFramework.Uow
{
    public class EfUnitOfWorkManager : IUnitOfWorkManager
    {
        private IServiceProvider ServiceProvider { get; set; }

        public EfUnitOfWorkManager(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
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
