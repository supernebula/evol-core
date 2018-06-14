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
        public void MongoLogInsertTest()
        {
            var log1 = loggerFactory.CreateLogger("visit.audit");
            log1.LogInformation("database log test:" + nameof(MongoTest.FileLogTest));

            var log2 = loggerFactory.CreateLogger("ex.normal");
            log2.LogInformation("database log test:" + nameof(MongoTest.FileLogTest));

            var log3 = loggerFactory.CreateLogger("operate.manage");
            log3.LogInformation("database log test:" + nameof(MongoTest.FileLogTest));
        }
    }
}
