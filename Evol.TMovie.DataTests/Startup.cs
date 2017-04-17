using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Evol.Domain;

namespace Evol.TMovie.DataTests
{
    class Startup
    {
        public void Init()
        {
            IServiceCollection services = null;
            var serviceProvider = services.BuildServiceProvider(true);
            AppConfig.InitCurrent(services, serviceProvider);
        }
    }
}
