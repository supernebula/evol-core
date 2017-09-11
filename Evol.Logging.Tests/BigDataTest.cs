using System;
using System.Diagnostics;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Evol.Logging.Tests
{
    /// <summary>
    /// 文件写入对别：
    /// log4net- total: 200000条数据, Elapsed:8900
    /// nlog- total: 200000调数据, 	Elapsed:109813
    /// </summary>
    public class BigDataTest : IDisposable
    {
        private readonly ITestOutputHelper output;
        public BigDataTest(ITestOutputHelper outputHelper)
        {
            output = outputHelper;
        }

        public void Dispose()
        {
        }

        [Fact]
        public void Log4netTest()
        {
            log4net.Repository.ILoggerRepository repository = log4net.LogManager.CreateRepository("NETCoreRepository");
            var fileInfo = new FileInfo("config/log4net.config");
            log4net.Config.XmlConfigurator.Configure(repository, fileInfo);
            log4net.Config.BasicConfigurator.Configure(repository);
            log4net.ILog log = log4net.LogManager.GetLogger(repository.Name, "NETCorelog4net");

            var total = 200000;
            var sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < total; i++)
            {
                log.Info("log4 bigdata test: " + i);
            }
            sw.Stop();
            log.Info($"total: {total}, Elapsed:{sw.ElapsedMilliseconds}");
            output.WriteLine($"Log4net测试 total: {total}, Elapsed:{sw.ElapsedMilliseconds}");
        }


        [Fact]
        public void NlogTest()
        {

            NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
            var total = 200000;
            var sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < total; i++)
            {
                log.Info("nlog bigdata test: " + i);
            }
            sw.Stop();
            log.Info($"total: {total}, Elapsed:{sw.ElapsedMilliseconds}");
            output.WriteLine($"NLog测试 total: {total}, Elapsed:{sw.ElapsedMilliseconds}");
        }
    }
}
