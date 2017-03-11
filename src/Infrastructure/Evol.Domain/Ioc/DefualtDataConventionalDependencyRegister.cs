using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.Unity;
using Evol.Common;
using Evol.Domain.Data;

namespace Evol.Domain.Ioc
{
    public class DefualtDataConventionalDependencyRegister : IConventionalDependencyRegister
    {
        public void Register(IUnityContainer container, Assembly assembly)
        {
            var queryInterfaceImpls = FindQueryEntry(assembly);
            queryInterfaceImpls.ForEach(p => container.RegisterType(p.Interface, p.Impl, new PerResolveLifetimeManager()));
            var repositoryInterfaceImpls = FindRepository(assembly);
            repositoryInterfaceImpls.ForEach(p => container.RegisterType(p.Interface, p.Impl, new PerResolveLifetimeManager()));
        }


        private List<InterfaceImplPair> FindQueryEntry(Assembly assembly)
        {
            Func<Type, bool> filter = type => type.IsPublic && !type.IsAbstract && type.IsClass && typeof(IQueryEntry).IsAssignableFrom(type);
            var impls = assembly.GetTypes().Where(filter).ToList();
            var interfaceImpls = new List<InterfaceImplPair>();
            if (impls.Count == 0)
                return interfaceImpls;
            impls.ForEach(t =>
            {
                var @interface = t.GetInterfaces().SingleOrDefault(i => i.IsGenericType && typeof(IQueryEntry).IsAssignableFrom(i));
                interfaceImpls.Add(new InterfaceImplPair() { Interface = @interface, Impl = t });
            });
            return interfaceImpls;
        }

        private List<InterfaceImplPair> FindRepository(Assembly assembly)
        {
            Func<Type, bool> filter = type => type.IsPublic && !type.IsAbstract && type.IsClass && typeof(IRepository<>).IsAssignableFrom(type);
            var impls = assembly.GetTypes().Where(filter).ToList();
            var interfaceImpls = new List<InterfaceImplPair>();
            if (impls.Count == 0)
                return interfaceImpls;
            impls.ForEach(t =>
            {
                var @interface = t.GetInterfaces().SingleOrDefault(i => i.IsGenericType && typeof(IRepository<>).IsAssignableFrom(i));
                interfaceImpls.Add(new InterfaceImplPair() { Interface = @interface, Impl = t });
            });
            return interfaceImpls;
        }
    }
}
