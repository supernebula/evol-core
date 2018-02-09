using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Evol.Common;
using Evol.Common.IoC;
using Evol.Domain.Messaging;

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

        private readonly IIoCManager _ioCManager;
        private readonly Func<IDependencyMapProvider> _eventBusTypeProviderThunk;
        private readonly Func<IIoCManager> _ioCManagerThunk;
        private readonly Func<Assembly[]> _assembliesThunk;

        public EventBusDependencyRegister(IIoCManager ioCManager, IDependencyMapProvider eventBusTypeProvider, params Assembly[] assemblies)
        {
            if (_ioCManager == null)
                throw new ArgumentNullException(nameof(_ioCManager));
            _ioCManagerThunk = () => _ioCManager;
            if (_eventBusTypeProviderThunk != null)
                _eventBusTypeProviderThunk = () => eventBusTypeProvider;
            _assembliesThunk = () => assemblies;
        }

        public EventBusDependencyRegister(IIoCManager ioCManager, params Assembly[] assemblies) : this(ioCManager, null, assemblies)
        {
            _eventBusTypeProviderThunk = () => new DefaultEventBusTypeProvider();
        }

        public EventBusDependencyRegister(IIoCManager ioCManager)
        {
            if (ioCManager == null)
                throw new ArgumentNullException(nameof(ioCManager));
            _ioCManagerThunk = () => ioCManager;
            _eventBusTypeProviderThunk = () => new DefaultEventBusTypeProvider();
        }

        public void Register()
        {
            var eventBusMap = _eventBusTypeProviderThunk().GetDependencyMap(_assembliesThunk()).FirstOrDefault();
            if (eventBusMap == default(InterfaceImplPair))
                throw new NotImplementedException("没有找到" + nameof(IEventBus) + "的实现");
            _ioCManagerThunk().AddPerDependency(eventBusMap.Interface, eventBusMap.Impl);
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
