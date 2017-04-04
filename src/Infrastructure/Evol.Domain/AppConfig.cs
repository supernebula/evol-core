using System;
using Evol.Domain.Ioc;
using Evol.Domain.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace Evol.Domain
{
    public class AppConfig
    {
        private IIoCManager _currentIoCManager;

        public IIoCManager IoCManager
        {
            get
            {
                if (_currentIoCManager == null)
                    _currentIoCManager = new DefaultIoCManager(Services, ServiceProvider);
                return _currentIoCManager;
            }
        }
        public AppConfig(IServiceCollection services, IServiceProvider serviceProvider)
        {
            Services = services;
            ServiceProvider = serviceProvider;
        }



        public static void InitCurrent(IServiceCollection services, IServiceProvider serviceProvider)
        {
            _current = new AppConfig(services, serviceProvider);
        }


        public IServiceCollection Services { get; private set; }

        public IServiceProvider ServiceProvider { get; private set; }


        private static AppConfig _current;
        public static AppConfig Current => _current;

        public void InitModuleFrom<TModule>() where TModule : AppModule, new()
        {
            (new TModule()).Initailize();
        }




    }
}
