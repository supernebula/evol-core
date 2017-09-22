using Evol.Domain.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Evol.Common;
using Microsoft.AspNetCore.Mvc;

namespace Evol.TMovie.Manage.Tests
{
    public class DefaultTManageTestConventionalDependencyRegister : IConventionalDependencyRegister
    {
        public void Register(IServiceCollection container, Assembly assembly)
        {
            var containerImpls = FindController(assembly);
            containerImpls.ForEach(p => container.AddTransient(p.Interface, p.Impl));
        }

        private List<InterfaceImplPair> FindController(Assembly assembly)
        {
            Func<Type, bool> filter = type => {
                var tInfo = type.GetTypeInfo();
                return tInfo.IsPublic && !tInfo.IsAbstract && tInfo.IsClass && typeof(Controller).GetTypeInfo().IsAssignableFrom(type);
            };

            List<Type> impls;

            try
            {
                impls = assembly.GetTypes().Where(filter).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }


            var interfaceImpls = new List<InterfaceImplPair>();
            if (impls.Count == 0)
                return interfaceImpls;
            impls.ForEach(t =>
            {
                interfaceImpls.Add(new InterfaceImplPair() { Interface = t, Impl = t });
            });
            return interfaceImpls;
        }
    }
}
