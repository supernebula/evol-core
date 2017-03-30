using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Util.Configuration
{
    public interface ITypedConfigurationSource
    {
        Type StrongType { get; }
        ITypedConfigurationProvider Build(ITypedConfigurationBuilder builder);
    }
}
