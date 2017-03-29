using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Util.Configuration
{

    public interface IStrongConfiguration
    {
        Type StrongType { get; }

        object GetValue();

        IStrongConfigurationSource Source { get; }

        IChangeToken GetReloadToken();

        void Reload();

    }
}
