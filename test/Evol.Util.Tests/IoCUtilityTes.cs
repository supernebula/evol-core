using System;
using System.Reflection;
using System.Diagnostics;
using Xunit;
using Evol.Util;

namespace Evol.Utilities.Test
{
    public class IoCUtilityTes
    {
        [Fact]
        public void GetInterfaceAndClassFromAssemblyTest()
        {
            var interfaceClassPaires = IoCUtil.GetInterfaceAndClass(
                    "Evol.FirstEC.Domain.Repositories"
                    , "Evol.FirstEC.Data.Repositories"
                    , Assembly.Load(new AssemblyName("Evol.FirstEC.Domain"))
                    , Assembly.Load(new AssemblyName("Evol.FirstEC.Data"))
                );
            
            interfaceClassPaires.ForEach(p => Trace.WriteLine(p.Interface.FullName + "\r\n : " + p.Impl.FullName));
        }
    }
}
