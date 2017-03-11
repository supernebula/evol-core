using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Evol.Common;
using Evol.Domain.Messaging;
using Microsoft.Practices.Unity;

namespace Evol.Domain.Configuration
{
    public class CommandHandlerDependencyRegister : IDependencyRegister
    {
        public class DefaultCommandHandlerTypeProvider : IDependencyMapProvider
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


        private readonly Func<IDependencyMapProvider> _commandHandlerTypeProviderThunk;
        private readonly Func<IUnityContainer> _containerThunk;
        private readonly Func<Assembly[]> _assembliesThunk;
        public CommandHandlerDependencyRegister(IUnityContainer unityContainer, IDependencyMapProvider commandHandlerTypeProvider, params Assembly[] assemblies)
        {
            if(unityContainer != null)
                _containerThunk = () => unityContainer;
            if (commandHandlerTypeProvider != null)
                _commandHandlerTypeProviderThunk = () => commandHandlerTypeProvider;
            _assembliesThunk = () => assemblies;
        }

        public CommandHandlerDependencyRegister(IUnityContainer unityContainer, params Assembly[] assemblies) : this(unityContainer, null, assemblies)
        {
            _commandHandlerTypeProviderThunk = () => new DefaultCommandHandlerTypeProvider();
        }

        public void Register(LifetimeManager lifetimeManager = null)
        {
            var maps = _commandHandlerTypeProviderThunk().GetDependencyMap(_assembliesThunk()).ToList();
            maps.ForEach(e => _containerThunk().RegisterType(e.Interface, e.Impl, lifetimeManager ?? new PerResolveLifetimeManager()));
        }

        public void Register(Type from, Type to, LifetimeManager lifetimeManager = null)
        {
            _containerThunk().RegisterType(from, to, lifetimeManager ?? new PerResolveLifetimeManager());
        }
    }


}
