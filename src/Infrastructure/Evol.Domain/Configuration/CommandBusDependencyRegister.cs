using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Evol.Domain.Messaging;
using Evol.Common;
using Evol.Common.IoC;

namespace Evol.Domain.Configuration
{
    public class CommandBusDependencyRegister : IDependencyRegister
    {

        public class DefaultCommandBusTypeProvider : IDependencyMapProvider
        {
            public IEnumerable<InterfaceImplPair> GetDependencyMap(params Assembly[] assemblies)
            {
                if (assemblies.Any(e => e != null))
                    throw new ArgumentException(nameof(assemblies) + "项均为null， 至少指定一个Assembly");
                var types = new List<Type>();
                assemblies.ToList().ForEach(a => types.AddRange(a.GetExportedTypes()));
                var result = types
                    .Where(t => t.GetTypeInfo().GetInterfaces().Any(i => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandBus)))
                    .Select(t => new InterfaceImplPair { Interface = t.GetTypeInfo().GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(ICommandBus)), Impl = t });
                return result.ToList();
            }
        }

        private readonly IIoCManager _ioCManager;
        private readonly Func<IDependencyMapProvider> _commandBusTypeProviderThunk;
        private readonly Func<IIoCManager> _ioCManagerThunk;
        private readonly Func<Assembly[]> _assembliesThunk;

        public CommandBusDependencyRegister(IIoCManager ioCManager, IDependencyMapProvider commandBusTypeProvider, params Assembly[] assemblies)
        {
            if (_ioCManager != null)
                _ioCManagerThunk = () => ioCManager;
            if (_commandBusTypeProviderThunk != null)
                _commandBusTypeProviderThunk = () => commandBusTypeProvider;
            if(assemblies != null)
                _assembliesThunk = () => assemblies;
        }

        public CommandBusDependencyRegister(IIoCManager ioCManager, params Assembly[] assemblies) : this(ioCManager, null, assemblies)
        {
            _commandBusTypeProviderThunk = () => new DefaultCommandBusTypeProvider();
        }

        public CommandBusDependencyRegister(IIoCManager ioCManager)
        {
            if (_ioCManager != null)
                _ioCManagerThunk = () => _ioCManager;
            _commandBusTypeProviderThunk = () => new DefaultCommandBusTypeProvider();
        }

        public void Register()
        {
            var commandBusMap = _commandBusTypeProviderThunk().GetDependencyMap(_assembliesThunk()).FirstOrDefault();
            if(commandBusMap == default(InterfaceImplPair))
                throw new NotImplementedException("没有找到" + nameof(ICommandBus) + "的实现");
            _ioCManagerThunk().AddPerRequest(commandBusMap.Interface, commandBusMap.Impl);  
        }
       

        public void Register(Type from, Type to, IocLifetime lifetime)
        {
            if(lifetime == IocLifetime.PerRequest)
                _ioCManagerThunk().AddPerRequest(from, to);
            else if(lifetime == IocLifetime.SingleInstance)
                _ioCManagerThunk().AddSingleInstance(from, to);
            else
                _ioCManagerThunk().AddPerDependency(from, to);
        }
    }
}
