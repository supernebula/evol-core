using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Common.IoC
{
    public interface IIoCServiceGetter
    {
        T GetService<T>();

        IEnumerable<T> GetServices<T>();
    }
}
