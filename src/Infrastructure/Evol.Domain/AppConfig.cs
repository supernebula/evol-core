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
                    _currentIoCManager = new DefaultIoCManager(_services, EnsureServiceProvider);
                return _currentIoCManager;
            }
        }
        public AppConfig(IServiceCollection services)
        {
            _services = services;
            
        }


        public static void Init(IServiceCollection services)
        {
            _current = new AppConfig(services);
        }

        public static void ConfigServiceProvider(IServiceProvider rootServiceProvider)
        {
            _current._rootServiceProvider = rootServiceProvider;
        }

        public static void ConfigPerRequestServiceProvider(Func<IServiceProvider> requestServicesThunk)
        {
            _current._perRequestServicesThunk = requestServicesThunk;
        }


        private IServiceCollection _services;

        private IServiceProvider _rootServiceProvider;

        private Func<IServiceProvider> _perRequestServicesThunk;

        /// <summary>
        /// 优先使用 <see cref="HttpContext.RequestServices"/>
        /// </summary>
        /// <returns></returns>
        private IServiceProvider EnsureServiceProvider()
        {
            IServiceProvider provider = null;
            if (_perRequestServicesThunk != null)
                provider = _perRequestServicesThunk.Invoke();
            if (provider != null)
                return provider;
            if (_rootServiceProvider != null)
                return _rootServiceProvider;
            return _services.BuildServiceProvider();
        }


        private static AppConfig _current;
        public static AppConfig Current => _current;

        public void RegisterAppModuleFrom<TModule>() where TModule : AppModule, new()
        {
            (new TModule()).Initailize();
        }
    }
}
