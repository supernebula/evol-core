using System;
using Evol.Common.Logging;
using NLog;

namespace Evol.Logging.AdapteNLog
{
    public class NLoggerFactory : ILoggerFactory
    {
        public void AddProvider(ILoggerProvider provider)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configFile">"nlog.config"</param>
        public void LoadConfiguration(string configFile)
        {
            var temp = LogManager.LoadConfiguration(configFile);
        }

        public Common.Logging.ILogger CreateLogger(string categoryName)
        {
            var nlog = LogManager.LogFactory.GetLogger(categoryName);
            var log = new NLogger(nlog);
            return log;
        }

        public Common.Logging.ILogger CreateLogger<T>()
        {
            var nlog = LogManager.LogFactory.GetLogger(typeof(T).GetType().FullName);
            var log = new NLogger(nlog);
            return log;
        }

        public void Dispose()
        {

        }
    }
}
