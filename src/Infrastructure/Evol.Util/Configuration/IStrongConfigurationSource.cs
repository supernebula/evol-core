using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Util.Configuration
{
    public interface IStrongConfigurationSource
    {
        Type StrongType { get; }
        IStrongConfigurationProvider Build(IStrongConfigurationBuilder builder);
    }
}
