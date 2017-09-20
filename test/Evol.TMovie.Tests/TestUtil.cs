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
                        if (t.Exception.InnerException != null)
                            output.WriteLine("Message:\r\n" + t.Exception.InnerException.Message + "\r\n\r\nSource:\r\n" + t.Exception.InnerException.Source + "\r\n\r\nStackTrace:\r\n" + t.Exception.InnerException.StackTrace);
                    }
                   
                }
                Assert.True(t.IsCompletedSuccessfully);
            }).GetAwaiter().GetResult();
        }
    }
}
