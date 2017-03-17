using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Evol.Snippet.Tests
{
    public class AsyncLocalTest
    {
        public readonly ITestOutputHelper output;

        public static AsyncLocal<string> AsyncLocal1 = new AsyncLocal<string>();
        public static List<string> list = new List<string>();


        public AsyncLocalTest(ITestOutputHelper testOutputHelper)
        {
            output = testOutputHelper;
        }

        [Fact]
        public void MultithreadTest()
        {
            var task1 = Task.Run(async () =>
            {
                await Task.Delay(2000);
                AsyncLocal1.Value = "100";

                await Task.Delay(3000);
                list.Add(AsyncLocal1.Value);
            });

            var task2 = Task.Run(async () =>
            {
                await Task.Delay(50);
                AsyncLocal1.Value = "200";


                await Task.Delay(3000);
                list.Add(AsyncLocal1.Value);
            });

            var task3 = Task.Run(async () =>
            {
                
                await Task.Delay(100);
                AsyncLocal1.Value = "300";

                await Task.Delay(3000);
                list.Add(AsyncLocal1.Value);
                //await Task.Delay(3000);
                //list.Add(AsyncLocal1.Value);
            });

            Task.WhenAll(task1, task2, task3).GetAwaiter().GetResult();
            foreach (var item in list)
            {
                output.WriteLine(item);
            }
        }
    }
}
