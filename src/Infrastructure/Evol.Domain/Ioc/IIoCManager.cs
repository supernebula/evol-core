using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Evol.Common.IoC;

namespace Evol.Domain.Ioc
{
    public interface IIoCManager : IIoCServiceGetter
    {
        IServiceCollection Container { get; }

        IServiceProvider ServiceProvider { get; }

    }
}
