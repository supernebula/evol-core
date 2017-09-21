using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Evol.TMovie.Manage.Tests
{
    public static class TestUtil
    {
        public static void AssertSync(Func<Task> asyncFunc, ITestOutputHelper output = null)
        {
            asyncFunc.Invoke()
            .ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    if (output != null)
                    {
                        output.WriteLine(t.Exception.Message + "\r\n" + t.Exception.StackTrace);
                        output.WriteLine("\r\n\r\n");

                        foreach (var exceptionItem in t.Exception.InnerExceptions)
                        {
                            var exception = exceptionItem;
                            while (exception != null)
                            {
                                output.WriteLine(exception.Message + "\r\n" + exception.StackTrace);
                                output.WriteLine("\r\n\r\n");
                                exception = exception.InnerException;
                            }
                        }
                    }
                   
                }
                Assert.True(t.IsCompletedSuccessfully);
            }).GetAwaiter().GetResult();
        }
    }
}
