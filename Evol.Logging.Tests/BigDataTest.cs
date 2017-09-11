using System;
using System.Diagnostics;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Evol.Logging.Tests
{
    /// <summary>
    /// Log4net、Nlog日志文件写入对比
    /// </summary>
    public class BigDataTest
    {
        private readonly ITestOutputHelper output;
        public BigDataTest(ITestOutputHelper outputHelper)
        {
            output = outputHelper;
        }

        /// <summary>
        /// 使用Log4net连续插入20W行字符串
        /// </summary>
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

        /// <summary>
        /// 使用Nlog连续插入20W行字符串
        /// </summary>
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
