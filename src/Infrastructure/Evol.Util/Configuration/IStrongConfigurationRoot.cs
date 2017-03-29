using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Util.Configuration
{
    public interface IStrongConfigurationRoot
    {
        IList<IStrongConfiguration> Configurations { get; }

        T GetValue<T>();

        object GetValue(Type type);
    }
}
