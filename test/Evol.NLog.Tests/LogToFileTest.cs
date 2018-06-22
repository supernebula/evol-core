using Evol.Common.Logging;
using Evol.Logging.AdapteNLog;
using System;
using System.IO;
using Xunit;

namespace Evol.NLog.Tests
{
    public class LogToFileTest
    {
        private ILoggerFactory loggerFactory;

        public LogToFileTest()
        {
            loggerFactory = new NLoggerFactory();
            var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "nlog.config");
            loggerFactory.LoadConfiguration(configPath);
        }

        [Fact]
        public void LogTextToFileTest()
        {
            var log = loggerFactory.CreateLogger("visitAudit");
            log.LogInformation("test" + nameof(LogToFileTest.LogTextToFileTest));
        }
    }
}
