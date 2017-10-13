using System;
using Xunit;
using Evol.RabbitMQ.Simple;
using Xunit.Abstractions;
using System.Threading;

namespace Evol.RabbitMQ.Tests
{
    public class SimpleTest
    {
        private ITestOutputHelper output;

        public SimpleTest(ITestOutputHelper outputHelper)
        {
            output = outputHelper;
        }

        [Fact]
        public void SendTest()
        {
            try
            {
                MessageSend.Instance.Send("Hello World! " + DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                output.WriteLine(ex.Message);
                output.WriteLine(ex.InnerException?.Message);
                output.WriteLine(ex.StackTrace);
                Assert.False(true);
            }

        }

        [Fact]
        public void LoopSendTest()
        {
            try
            {
                for (int i = 0; i < 200; i++)
                {
                    MessageSend.Instance.Send(i + "Hello World! " + DateTime.Now.ToString());
                    Thread.Sleep(100);
                }
                
            }
            catch (Exception ex)
            {
                output.WriteLine(ex.Message);
                output.WriteLine(ex.InnerException?.Message);
                output.WriteLine(ex.StackTrace);
                Assert.False(true);
            }

        }
    }
}
