using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Evol.Common;
using Evol.Domain.Messaging;
using Microsoft.Extensions.DependencyInjection;
using Evol.Domain.Service;

namespace Evol.Domain.Ioc
{

    public class DefualtDomainConventionalDependencyRegister : IConventionalDependencyRegister
    {
        public void Register(IServiceCollection container, Assembly assembly)
        {
            var commandHandlerImpls = FindCommandHandler(assembly);
            commandHandlerImpls.ForEach(p => container.AddTransient(p.Interface, p.Impl));

            var eventHandlerImpls = FindEventHandler(assembly);
            eventHandlerImpls.ForEach(p => container.AddTransient(p.Interface, p.Impl));

            var domainServiceImpls = FindService(assembly);
            domainServiceImpls.ForEach(p => container.AddTransient(p.Interface, p.Impl));
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
