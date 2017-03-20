using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Evol.Common;
using Evol.Domain.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Evol.Domain.Ioc
{
    public class DefualtDataConventionalDependencyRegister : IConventionalDependencyRegister
    {
        public void Register(IServiceCollection container, Assembly assembly)
        {
            var queryInterfaceImpls = FindQueryEntry(assembly);
            queryInterfaceImpls.ForEach(p => container.AddTransient(p.Interface, p.Impl));
            var repositoryInterfaceImpls = FindRepository(assembly);
            repositoryInterfaceImpls.ForEach(p => container.AddTransient(p.Interface, p.Impl));
        }


        private List<InterfaceImplPair> FindQueryEntry(Assembly assembly)
        {
            Func<Type, bool> filter = type => {
                var tInfo = type.GetTypeInfo();
                return tInfo.IsPublic && !tInfo.IsAbstract && tInfo.IsClass && (typeof(IQueryEntry)).GetTypeInfo().IsAssignableFrom(type);
            };
            var impls = assembly.GetTypes().Where(filter).ToList();
            var interfaceImpls = new List<InterfaceImplPair>();
            if (impls.Count == 0)
                return interfaceImpls;
            impls.ForEach(t =>
            {
                var @interface = t.GetTypeInfo().GetInterfaces().SingleOrDefault(i => i.GetTypeInfo().IsGenericType && (typeof(IQueryEntry)).GetTypeInfo().IsAssignableFrom(i));
                interfaceImpls.Add(new InterfaceImplPair() { Interface = @interface, Impl = t });
            });
            return interfaceImpls;
        }

        private List<InterfaceImplPair> FindRepository(Assembly assembly)
        {
            Func<Type, bool> filter = type =>
            {
                var tInfo = type.GetTypeInfo();
                return tInfo.IsPublic && !tInfo.IsAbstract && tInfo.IsClass && (typeof(IRepository<>)).GetTypeInfo().IsAssignableFrom(type);
            };
            var impls = assembly.GetTypes().Where(filter).ToList();
            var interfaceImpls = new List<InterfaceImplPair>();
            if (impls.Count == 0)
                return interfaceImpls;
            impls.ForEach(t =>
            {
                var @interface = t.GetTypeInfo().GetInterfaces().SingleOrDefault(i => i.GetTypeInfo().IsGenericType && (typeof(IRepository<>)).GetTypeInfo().IsAssignableFrom(i));
                interfaceImpls.Add(new InterfaceImplPair() { Interface = @interface, Impl = t });
            });
            return interfaceImpls;
        }
    }
}
