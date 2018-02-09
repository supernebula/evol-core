using System;
using Evol.Common.Logging;
using NLog;

namespace Evol.Fx.Logging.AdapteNLog
{
    public class NLoggerFactory : ILoggerFactory
    {
        public void AddProvider(ILoggerProvider provider)
        {
            throw new NotImplementedException();
        }

        public Common.Logging.ILogger CreateLogger(string categoryName)
        {
            var nlog = LogManager.GetLogger(categoryName);
            var log = new NLogger(nlog);
            return log;
        }

        public Common.Logging.ILogger CreateLogger<T>()
        {
            var nlog = LogManager.GetLogger(typeof(T).GetType().FullName);
            var log = new NLogger(nlog);
            return log;
        }

        public void Dispose()
        {

        }
    }
}
