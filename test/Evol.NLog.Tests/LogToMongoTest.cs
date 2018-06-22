using System;
using Xunit;
using Evol.Common.Logging;
using Evol.Logging.AdapteNLog;
using System.IO;

namespace Evol.NLog.Tests
{
    public class LogToMongoTest
    {
        private ILoggerFactory loggerFactory;

        public LogToMongoTest()
        {
            loggerFactory = new NLoggerFactory();
            var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "nlog.config");
            loggerFactory.LoadConfiguration(configPath);
        }

        /// <summary>
        /// 将日志插入到MongoDB
        /// </summary>
        [Fact]
        public void InsertLogToMongoTest()
        {
            var log1 = loggerFactory.CreateLogger("visit.audit");
            log1.LogInformation("visit log test:" + nameof(LogToMongoTest.InsertLogToMongoTest));

            var log2 = loggerFactory.CreateLogger("ex.normal");
            log2.LogInformation("exception log test:" + nameof(LogToMongoTest.InsertLogToMongoTest));

            var log3 = loggerFactory.CreateLogger("operate.manage");
            log3.LogBasicOperate(BasicOperateLogType.Insert, "0.0.0.0", "original value1", "current value1", "remark1", "0000000000000000", "username1");
        }
    }
}
