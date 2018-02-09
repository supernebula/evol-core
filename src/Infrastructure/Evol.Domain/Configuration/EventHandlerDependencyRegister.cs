using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Evol.Common;
using Evol.Domain.Messaging;
using Evol.Common.IoC;

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

        private IIoCManager _ioCManager;
        private readonly Func<IDependencyMapProvider> _eventHandlerTypeProviderThunk;
        private readonly Func<IIoCManager> _ioCManagerThunk;
        private readonly Func<Assembly[]> _assembliesThunk;
        public EventHandlerDependencyRegister(IIoCManager ioCManager, IDependencyMapProvider commandHandlerTypeProvider, params Assembly[] assemblies)
        {
            if (_ioCManager != null)
                _ioCManagerThunk = () => ioCManager;
            if (commandHandlerTypeProvider != null)
                _eventHandlerTypeProviderThunk = () => commandHandlerTypeProvider;
            _assembliesThunk = () => assemblies;
        }

        public EventHandlerDependencyRegister(IIoCManager ioCManager, params Assembly[] assemblies) : this(ioCManager, null, assemblies)
        {
            _eventHandlerTypeProviderThunk = () => new DefaultEventHandlerTypeProvider();
        }


        public void Register()
        {
            var maps = _eventHandlerTypeProviderThunk().GetDependencyMap(_assembliesThunk()).ToList();
            maps.ForEach(e => _ioCManagerThunk().AddPerDependency(e.Interface, e.Impl));
        }


        public void Register(Type from, Type to, IocLifetime lifetime)
        {
            if (lifetime == IocLifetime.PerRequest)
                _ioCManagerThunk().AddPerRequest(from, to);
            else if (lifetime == IocLifetime.SingleInstance)
                _ioCManagerThunk().AddSingleInstance(from, to);
            else
                _ioCManagerThunk().AddPerDependency(from, to);
        }
    }
}
