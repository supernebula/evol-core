using System;
using System.Reflection;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Evol.Utilities.Test
{
    [TestClass]
    public class IoCUtilityTes
    {
        [TestMethod]
        public void GetInterfaceAndClassFromAssemblyTest()
        {
            var interfaceClassPaires = IoCUtility.GetInterfaceAndClass(
                    "Evol.FirstEC.Domain.Repositories"
                    , "Evol.FirstEC.Data.Repositories"
                    , Assembly.Load("Evol.FirstEC.Domain")
                    , Assembly.Load("Evol.FirstEC.Data")
                );
            
            interfaceClassPaires.ForEach(p => Trace.WriteLine(p.Interface.FullName + "\r\n : " + p.Impl.FullName));
        }
    }
}
