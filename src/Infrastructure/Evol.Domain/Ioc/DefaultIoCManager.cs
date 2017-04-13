using System;
using Microsoft.Extensions.DependencyInjection;

namespace Evol.Domain.Ioc
{
    public class DefaultIoCManager : IIoCManager
    {
        public IServiceCollection Container { get; }

        public IServiceProvider ServiceProvider { get; }

        public DefaultIoCManager(IServiceCollection serviceCollection, IServiceProvider serviceProvider)
        {
            Container = serviceCollection;
            ServiceProvider = serviceProvider;
        }

        /// <summary>
        /// Resolve dependency injection service
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetService<T>()
        {
            return ServiceProvider.GetService<T>();
        }
    }
}
