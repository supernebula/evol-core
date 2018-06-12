using System;
using Xunit;
using Evol.Common.Logging;
using Evol.Logging.AdapteNLog;
using System.IO;

namespace Evol.NLog.Tests
{
    public class MongoTest
    {
        private ILoggerFactory loggerFactory;

        public MongoTest()
        {
            loggerFactory = new NLoggerFactory();
            var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "nlog.config");
            loggerFactory.LoadConfiguration(configPath);
        }

        [Fact]
        public void FileLogTest()
        {
            var log = loggerFactory.CreateLogger("visitAudit");
            log.LogInformation("test" + nameof(MongoTest.FileLogTest));
        }


        [Fact]
        public void FileLogInsertTest()
        {

        }
    }
}
