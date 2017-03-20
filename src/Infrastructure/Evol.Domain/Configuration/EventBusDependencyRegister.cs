using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Evol.Common;
using Evol.Domain.Messaging;
using Microsoft.Extensions.DependencyInjection;

namespace Evol.Domain.Configuration
{
    public class EventBusDependencyRegister : IDependencyRegister
    {

        public class DefaultEventBusTypeProvider : IDependencyMapProvider
        {
            public IEnumerable<InterfaceImplPair> GetDependencyMap(params Assembly[] assemblies)
            {
                if (assemblies.Any(e => e != null))
                    throw new ArgumentException(nameof(assemblies) + "项均为null， 至少指定一个Assembly");
                var types = new List<Type>();
                assemblies.ToList().ForEach(a => types.AddRange(a.GetExportedTypes()));
                var result = types
                    .Where(t => t.GetTypeInfo().GetInterfaces().Any(i => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(IEventBus)))
                    .Select(t => new InterfaceImplPair { Interface = t.GetTypeInfo().GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(IEventBus)), Impl = t });
                return result.ToList();
            }
        }

        private readonly Func<IDependencyMapProvider> _eventBusTypeProviderThunk;
        private readonly Func<IServiceCollection> _containerThunk;
        private readonly Func<Assembly[]> _assembliesThunk;

        public EventBusDependencyRegister(IServiceCollection container, IDependencyMapProvider commandBusTypeProvider, params Assembly[] assemblies)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            _containerThunk = () => container;
            if (_eventBusTypeProviderThunk != null)
                _eventBusTypeProviderThunk = () => commandBusTypeProvider;
            _assembliesThunk = () => assemblies;
        }

        public EventBusDependencyRegister(IServiceCollection container, params Assembly[] assemblies) : this(container, null, assemblies)
        {
            _eventBusTypeProviderThunk = () => new DefaultEventBusTypeProvider();
        }

        public EventBusDependencyRegister(IServiceCollection container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            _containerThunk = () => container;
            _eventBusTypeProviderThunk = () => new DefaultEventBusTypeProvider();
        }

        public void Register()
        {
            var eventBusMap = _eventBusTypeProviderThunk().GetDependencyMap(_assembliesThunk()).FirstOrDefault();
            if (eventBusMap == default(InterfaceImplPair))
                throw new NotImplementedException("没有找到" + nameof(IEventBus) + "的实现");
            _containerThunk().AddTransient(eventBusMap.Interface, eventBusMap.Impl);
        }

        public void Register(Type from, Type to, ServiceLifetime lifetime)
        {
            if (lifetime == ServiceLifetime.Scoped)
                _containerThunk().AddScoped(from, to);
            else if (lifetime == ServiceLifetime.Singleton)
                _containerThunk().AddSingleton(from, to);
            else
                _containerThunk().AddTransient(from, to);
        }
    }
}
