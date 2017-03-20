using System;
using Evol.Domain.Ioc;
using Evol.Domain.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace Evol.Domain
{
    public class AppConfiguration
    {
        private IIoCManager _currentIoCManager;

        public IIoCManager IoCManager
        {
            get
            {
                if(_currentIoCManager == null)
                    _currentIoCManager = new DefaultIoCManager(Services);
                return _currentIoCManager;
            }
        }

        public static void InitCurrent(IServiceCollection services)
        {
            _current = new AppConfiguration(services);
        }

        public AppConfiguration(IServiceCollection services)
        {
            Services = services;
        }

        private IServiceCollection _services;

        public IServiceCollection Services { get; private set; }

        private static AppConfiguration _current;
        public static AppConfiguration Current => _current;

        public void InitModuleFrom<TModule>() where TModule : AppModule, new()
        {
            (new TModule()).Initailize();
        }

        //public AppConfiguration Use<TFrom, TTo>(LifetimeManager life) where TTo : TFrom
        //{
        //    //throw new NotImplementedException();
        //    Container.RegisterType<TFrom, TTo>(life);
        //    return this;
        //}

        //public AppConfiguration Use(Type from, Type to, LifetimeManager life)
        //{
        //    //throw new NotImplementedException();
        //    Container.RegisterType(from, to, life);
        //    return this;
        //}

    }
}
