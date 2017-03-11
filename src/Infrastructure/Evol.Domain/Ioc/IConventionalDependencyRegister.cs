using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace Evol.Domain.Ioc
{
    public interface IConventionalDependencyRegister
    {
        void Register(IUnityContainer container, Assembly assembly);
    }
}
