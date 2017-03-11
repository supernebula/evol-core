using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.Unity;
using Evol.Common;
using Evol.Domain.Messaging;

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
                    .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>)))
                    .Select(t => new InterfaceImplPair { Interface = t.GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(ICommandHandler<>)), Impl = t });
                return result.ToList();
            }
        }


        private readonly Func<IDependencyMapProvider> _eventHandlerTypeProviderThunk;
        private readonly Func<IUnityContainer> _containerThunk;
        private readonly Func<Assembly[]> _assembliesThunk;
        public EventHandlerDependencyRegister(IUnityContainer unityContainer, IDependencyMapProvider commandHandlerTypeProvider, params Assembly[] assemblies)
        {
            if (unityContainer != null)
                _containerThunk = () => unityContainer;
            if (commandHandlerTypeProvider != null)
                _eventHandlerTypeProviderThunk = () => commandHandlerTypeProvider;
            _assembliesThunk = () => assemblies;
        }

        public EventHandlerDependencyRegister(IUnityContainer unityContainer, params Assembly[] assemblies) : this(unityContainer, null, assemblies)
        {
            _eventHandlerTypeProviderThunk = () => new DefaultEventHandlerTypeProvider();
        }


        public void Register(LifetimeManager lifetimeManager = null)
        {
            var maps = _eventHandlerTypeProviderThunk().GetDependencyMap(_assembliesThunk()).ToList();
            maps.ForEach(e => _containerThunk().RegisterType(e.Interface, e.Impl, lifetimeManager ?? new PerResolveLifetimeManager()));
        }


        public void Register(Type from, Type to, LifetimeManager lifetimeManager = null)
        {
            _containerThunk().RegisterType(from, to, lifetimeManager ?? new PerResolveLifetimeManager());
        }
    }
}
