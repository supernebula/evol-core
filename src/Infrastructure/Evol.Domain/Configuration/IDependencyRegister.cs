
using System;
using Microsoft.Extensions.DependencyInjection;

namespace Evol.Domain.Configuration
{
    public interface IDependencyRegister
    {
        //void Register(ServiceLifetime? lifetime = null);

        //void Register(Type from, Type to, ServiceLifetime? lifetime = null);

        void Register();

        void Register(Type from, Type to, ServiceLifetime lifetime);
    }
}
