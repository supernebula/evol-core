using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Evol.Domain.Messaging;
using Evol.Common;
using Microsoft.Extensions.DependencyInjection;

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

        private readonly Func<IDependencyMapProvider> _commandBusTypeProviderThunk;
        private readonly Func<IServiceCollection> _containerThunk;
        private readonly Func<Assembly[]> _assembliesThunk;

        public CommandBusDependencyRegister(IServiceCollection container, IDependencyMapProvider commandBusTypeProvider, params Assembly[] assemblies)
        {
            if (container != null)
                _containerThunk = () => container;
            if (_commandBusTypeProviderThunk != null)
                _commandBusTypeProviderThunk = () => commandBusTypeProvider;
            if(assemblies != null)
                _assembliesThunk = () => assemblies;
        }

        public CommandBusDependencyRegister(IServiceCollection container, params Assembly[] assemblies) : this(container, null, assemblies)
        {
            _commandBusTypeProviderThunk = () => new DefaultCommandBusTypeProvider();
        }

        public CommandBusDependencyRegister(IServiceCollection container)
        {
            if (container != null)
                _containerThunk = () => container;
            _commandBusTypeProviderThunk = () => new DefaultCommandBusTypeProvider();
        }

        public void Register()
        {
            var commandBusMap = _commandBusTypeProviderThunk().GetDependencyMap(_assembliesThunk()).FirstOrDefault();
            if(commandBusMap == default(InterfaceImplPair))
                throw new NotImplementedException("没有找到" + nameof(ICommandBus) + "的实现");
            _containerThunk().AddScoped(commandBusMap.Interface, commandBusMap.Impl);  
        }
       

        public void Register(Type from, Type to, ServiceLifetime lifetime)
        {
            if(lifetime == ServiceLifetime.Scoped)
                _containerThunk().AddScoped(from, to);
            else if(lifetime == ServiceLifetime.Singleton)
                _containerThunk().AddSingleton(from, to);
            else
                _containerThunk().AddTransient(from, to);
        }
    }
}
