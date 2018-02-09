using System.Reflection;
using Evol.Common.IoC;

namespace Evol.Configuration.IoC
{
    public interface IConventionalDependencyRegister
    {
        void Register(IIoCManager ioCManager, Assembly assembly);
    }
}
