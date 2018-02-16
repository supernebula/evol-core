using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evol.Common.Logging;
using Evol.Fx.Logging.AdapteNLog;
using Xunit;

namespace Evol.Logging.AdapteNLog.FxTests
{
    public class BasicTest
    {
        private NLoggerFactory logFactory;

        private ILogger log;

        public BasicTest()
        {
            logFactory = new NLoggerFactory();
            log = logFactory.CreateLogger<BasicTest>();
        }


        [Fact]
        public void LogDebugTest()
        {
            log.LogDebug("执行了LogInfoTest");
        }

        [Fact]
        public void LogErrorTest()
        {
            log.LogError("LogErrorTest");
        }

        [Fact]
        public void LogInfoTest()
        {
            log.LogInformation("LogInfoTest");
        }

        [Fact]
        public void LogTraceTest()
        {
            log.LogTrace("LogTraceTest");
        }

        [Fact]
        public void LogWarnTest()
        {
            log.LogWarning("LogWarnTest");
        }
    }
}
