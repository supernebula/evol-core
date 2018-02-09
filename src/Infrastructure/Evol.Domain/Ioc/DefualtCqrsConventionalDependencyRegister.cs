using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Evol.Common;
using Evol.Common.IoC;
using Evol.Configuration.IoC;
using Evol.Domain.Messaging;
using Evol.Domain.Service;

namespace Evol.Domain.Ioc
{

    public class DefualtCqrsConventionalDependencyRegister : IConventionalDependencyRegister
    {
        public void Register(IIoCManager _ioCManager, Assembly assembly)
        {
            var commandHandlerImpls = FindCommandHandler(assembly);
            commandHandlerImpls.ForEach(p => _ioCManager.AddPerDependency(p.Interface, p.Impl));

            var eventHandlerImpls = FindEventHandler(assembly);
            eventHandlerImpls.ForEach(p => _ioCManager.AddPerDependency(p.Interface, p.Impl));

            var domainServiceImpls = FindService(assembly);
            domainServiceImpls.ForEach(p => _ioCManager.AddPerDependency(p.Interface, p.Impl));
        }

        private List<InterfaceImplPair> FindCommandHandler(Assembly assembly)
        {
            Func<Type, bool> filter = type =>
            {
                var tInfo = type.GetTypeInfo();
                return tInfo.IsPublic && !tInfo.IsAbstract && tInfo.IsClass && tInfo.GetInterfaces().Any(i => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>));
            };
            var impls = assembly.GetTypes().Where(filter).ToList();
            var interfaceImpls = new List<InterfaceImplPair>();
            if (impls.Count == 0)
                return interfaceImpls;
            impls.ForEach(t =>
            {
                var @interfaces = t.GetTypeInfo().GetInterfaces().Where(i => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>)).ToList();
                interfaceImpls.AddRange(@interfaces.Select(@interface => new InterfaceImplPair() { Interface = @interface, Impl = t }));
            });
            return interfaceImpls;
        }

        private List<InterfaceImplPair> FindEventHandler(Assembly assembly)
        {
            Func<Type, bool> filter = type =>
            {
                var tInfo = type.GetTypeInfo();
                return tInfo.IsPublic && !tInfo.IsAbstract && tInfo.IsClass && tInfo.GetInterfaces().Any(i => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(IEventHandler<>));
            };
            var impls = assembly.GetTypes().Where(filter).ToList();
            var interfaceImpls = new List<InterfaceImplPair>();
            if (impls.Count == 0)
                return interfaceImpls;
            impls.ForEach(t =>
            {
                var @interfaces = t.GetTypeInfo().GetInterfaces().Where(i => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(IEventHandler<>)).ToList();
                interfaceImpls.AddRange(@interfaces.Select(@interface => new InterfaceImplPair() { Interface = @interface, Impl = t }));
            });
            return interfaceImpls;
        }

        private List<InterfaceImplPair> FindService(Assembly assembly)
        {
            Func<Type, bool> filter = type => {
                var tInfo = type.GetTypeInfo();
                return tInfo.IsPublic && !tInfo.IsAbstract && tInfo.IsClass && typeof(IService).GetTypeInfo().IsAssignableFrom(type);
            };
            var impls = assembly.GetTypes().Where(filter).ToList();
            var interfaceImpls = new List<InterfaceImplPair>();
            if (impls.Count == 0)
                return interfaceImpls;
            impls.ForEach(t =>
            {
                var @interface = t.GetTypeInfo().GetInterfaces().SingleOrDefault(i => i != typeof(IService) && typeof(IService).GetTypeInfo().IsAssignableFrom(i));
                interfaceImpls.Add(new InterfaceImplPair() { Interface = @interface, Impl = t });
            });
            return interfaceImpls;
        }
    }
}
