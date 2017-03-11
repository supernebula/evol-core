using System.Collections.Generic;
using System.Reflection;
using Evol.Common;

namespace Evol.Domain.Configuration
{
    public interface IDependencyMapProvider
    {
        IEnumerable<InterfaceImplPair> GetDependencyMap(params Assembly[] assemblies);
    }
}
