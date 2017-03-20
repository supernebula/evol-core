using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Evol.Common;
using Evol.Domain.Messaging;
using Microsoft.Extensions.DependencyInjection;

namespace Evol.Domain.Configuration
{
    public class EventHandlerDependencyRegister : IDependencyRegister
    {
        public class DefaultEventHandlerTypeProvider : IDependencyMapProvider
        {
            public IEnumerable<InterfaceImplPair> GetDependencyMap(params Assembly[] assemblies)
            {
                if (assemblies.Any(e => e != null))
                    throw new ArgumentException(nameof(assemblies) + "项均为null， 至少指定一个Assembly");
                var types = new List<Type>();
                assemblies.ToList().ForEach(a => types.AddRange(a.GetExportedTypes()));
                var result = types
                    .Where(t => t.GetTypeInfo().GetInterfaces().Any(i => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>)))
                    .Select(t => new InterfaceImplPair { Interface = t.GetTypeInfo().GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(ICommandHandler<>)), Impl = t });
                return result.ToList();
            }
        }


        private readonly Func<IDependencyMapProvider> _eventHandlerTypeProviderThunk;
        private readonly Func<IServiceCollection> _containerThunk;
        private readonly Func<Assembly[]> _assembliesThunk;
        public EventHandlerDependencyRegister(IServiceCollection container, IDependencyMapProvider commandHandlerTypeProvider, params Assembly[] assemblies)
        {
            if (container != null)
                _containerThunk = () => container;
            if (commandHandlerTypeProvider != null)
                _eventHandlerTypeProviderThunk = () => commandHandlerTypeProvider;
            _assembliesThunk = () => assemblies;
        }

        public EventHandlerDependencyRegister(IServiceCollection container, params Assembly[] assemblies) : this(container, null, assemblies)
        {
            _eventHandlerTypeProviderThunk = () => new DefaultEventHandlerTypeProvider();
        }


        public void Register()
        {
            var maps = _eventHandlerTypeProviderThunk().GetDependencyMap(_assembliesThunk()).ToList();
            maps.ForEach(e => _containerThunk().AddTransient(e.Interface, e.Impl));
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
