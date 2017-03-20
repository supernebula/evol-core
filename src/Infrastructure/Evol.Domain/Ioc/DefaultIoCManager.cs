using System;
using Microsoft.Extensions.DependencyInjection;

namespace Evol.Domain.Ioc
{
    public class DefaultIoCManager : IIoCManager
    {
        public IServiceCollection ServiceCollection { get; }

        public DefaultIoCManager(IServiceCollection serviceCollection)
        {
            ServiceCollection = serviceCollection;
        }
    }
}
