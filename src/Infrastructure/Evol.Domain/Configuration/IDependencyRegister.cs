
using System;
using Microsoft.Practices.Unity;

namespace Evol.Domain.Configuration
{
    public interface IDependencyRegister
    {
        void Register(LifetimeManager lifetimeManager = null);

        void Register(Type from, Type to, LifetimeManager lifetimeManager = null);
    }
}
