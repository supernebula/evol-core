using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace Evol.Domain.Ioc
{
    public interface IIoCManager
    {
        IUnityContainer Container { get; }
    }
}
