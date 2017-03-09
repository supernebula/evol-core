using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Evol.Util.Ioc
{
    public class IoCUtility
    {
        public static List<InterfaceImplPair> GetInterfaceAndClass(string interfaceNamespace, string classNamespace, params Assembly[] assemblies)
        {
            if (string.IsNullOrWhiteSpace(interfaceNamespace))
                throw new NullReferenceException(nameof(interfaceNamespace));
            if (string.IsNullOrWhiteSpace(classNamespace))
                throw new NullReferenceException(nameof(classNamespace));
            if (assemblies == null)
                throw new ArgumentNullException(nameof(assemblies));
            if (assemblies.Length == 0)
                throw new ArgumentException(nameof(assemblies) + ".Length is 0");



            var interfaces  = FindTypeOfNamespace(interfaceNamespace, true, assemblies).Where(t => t.GetTypeInfo().IsPublic).ToList();
            var impls = FindTypeOfNamespace(classNamespace, false, assemblies).Where(t =>
            {
                var tInfo = t.GetTypeInfo();
                return tInfo.IsClass && tInfo.IsPublic && t.Namespace == classNamespace && tInfo.GetInterfaces().Length > 0;
            }).ToList();

            var interfClassPairs = new List<InterfaceImplPair>();
            interfaces.ForEach(i =>
            {
                var @class = impls.FirstOrDefault(t => t.GetTypeInfo().GetInterfaces().Select(e => e.FullName).Contains(i.FullName));
                if (@class != null)
                    interfClassPairs.Add(new InterfaceImplPair { Interface = i, Impl = @class });


            });
            return interfClassPairs;
        }

        public static List<Type> FindTypeOfNamespace(string @namespace, bool isInterface, params Assembly[] assemblies)
        {
            List<Type> types = new List<Type>();
            assemblies.ToList().ForEach(assem =>
            {
                types.AddRange(assem.GetTypes());
            });

            types = types.Where(t => t.Namespace == @namespace).ToList();

            if (isInterface)
                types = types.Where(t => t.GetTypeInfo().IsInterface).ToList();
            return types;
        }

        public List<Type> FindSpecifyTypes(Func<Type, bool>  filter, Assembly assembly)
        {
            return assembly.GetTypes().Where(filter).ToList();
        }

    }
}
