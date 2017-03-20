using System;
using Evol.Domain.Ioc;
using Evol.Domain.Modules;

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
                    _currentIoCManager = new DefaultIoCManager(Container);
                return _currentIoCManager;
            }
        }

        private IUnityContainer _container;

        public IUnityContainer Container => _container ?? (_container = new UnityContainer());

        private static AppConfiguration _current;
        public static AppConfiguration Current => _current ?? (_current = new AppConfiguration());

        public void InitModuleFrom<TModule>() where TModule : AppModule, new()
        {
            (new TModule()).Initailize();
        }

        public AppConfiguration Use<TFrom, TTo>(LifetimeManager life) where TTo : TFrom
        {
            //throw new NotImplementedException();
            Container.RegisterType<TFrom, TTo>(life);
            return this;
        }

        public AppConfiguration Use(Type from, Type to, LifetimeManager life)
        {
            //throw new NotImplementedException();
            Container.RegisterType(from, to, life);
            return this;
        }

    }
}
