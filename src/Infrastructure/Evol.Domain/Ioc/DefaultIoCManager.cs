using System;
using Microsoft.Extensions.DependencyInjection;

namespace Evol.Domain.Ioc
{
    public class DefaultIoCManager : IIoCManager
    {
        public IServiceCollection Container { get; }

        public DefaultIoCManager(IServiceCollection serviceCollection)
        {
            Container = serviceCollection;
        }
    }
}
