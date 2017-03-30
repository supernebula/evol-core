using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Util.Configuration
{

    public interface ITypedConfiguration
    {
        Type StrongType { get; }

        object GetValue();

        ITypedConfigurationSource Source { get; }

        IChangeToken GetReloadToken();

        void Reload();

    }
}
