using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.Unity;
using Evol.Common;
using Evol.Domain.Messaging;

namespace Evol.Domain.Ioc
{

    public class DefualtDomainConventionalDependencyRegister : IConventionalDependencyRegister
    {
        public void Register(IUnityContainer container, Assembly assembly)
        {
            var commandHandlerImpls = FindCommandHandler(assembly);
            commandHandlerImpls.ForEach(p => container.RegisterType(p.Interface, p.Impl, new PerResolveLifetimeManager()));

            var eventHandlerImpls = FindEventHandler(assembly);
            eventHandlerImpls.ForEach(p => container.RegisterType(p.Interface, p.Impl, new PerResolveLifetimeManager()));
        }

        private List<InterfaceImplPair> FindCommandHandler(Assembly assembly)
        {
            Func<Type, bool> filter = type => type.IsPublic && !type.IsAbstract && type.IsClass && type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>));
            var impls = assembly.GetTypes().Where(filter).ToList();
            var interfaceImpls = new List<InterfaceImplPair>();
            if (impls.Count == 0)
                return interfaceImpls;
            impls.ForEach(t =>
            {
                var @interfaces = t.GetInterfaces().Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>)).ToList();
                interfaceImpls.AddRange(@interfaces.Select(@interface => new InterfaceImplPair() { Interface = @interface, Impl = t }));
            });
            return interfaceImpls;
        }

        private List<InterfaceImplPair> FindEventHandler(Assembly assembly)
        {
            Func<Type, bool> filter = type => type.IsPublic && !type.IsAbstract && type.IsClass && type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEventHandler<>));
            var impls = assembly.GetTypes().Where(filter).ToList();
            var interfaceImpls = new List<InterfaceImplPair>();
            if (impls.Count == 0)
                return interfaceImpls;
            impls.ForEach(t =>
            {
                var @interfaces = t.GetInterfaces().Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEventHandler<>)).ToList();
                interfaceImpls.AddRange(@interfaces.Select(@interface => new InterfaceImplPair() { Interface = @interface, Impl = t }));
            });
            return interfaceImpls;
        }
    }
}
