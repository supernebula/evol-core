using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Util.Configuration
{
    public interface ITypedConfigurationRoot
    {
        IList<ITypedConfiguration> Configurations { get; }

        T GetValue<T>();

        object GetValue(Type type);
    }
}
