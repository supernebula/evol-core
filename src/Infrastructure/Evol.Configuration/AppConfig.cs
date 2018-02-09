using System;
using Evol.Configuration.Modules;
using Evol.Common.IoC;

namespace Evol.Configuration
{
    public class AppConfig
    {
        private static AppConfig _current;
        public static AppConfig Current
        {
            get
            {
                if (_current == null)
                    _current = new AppConfig();
                return _current;
            }
        }

        private IIoCManager _currentIoCManager;

        public IIoCManager IoCManager
        {
            get
            {
                if (_currentIoCManager == null)
                    throw new NullReferenceException(nameof(_currentIoCManager) + "为null，必使用前请调用" + nameof(AppConfig.Init) + "完成初始化");
                return _currentIoCManager;
            }
        }

        public static void Init(IIoCManager ioCManager)
        {
            Current._currentIoCManager = ioCManager;
        }

        public void RegisterAppModuleFrom<TModule>() where TModule : AppModule, new()
        {
            (new TModule()).Initailize();
        }
    }
}
