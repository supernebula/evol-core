using System;
using System.Reflection;
using System.Diagnostics;
using Xunit;
using Evol.Util;
using Xunit.Abstractions;

namespace Evol.Util.Tests
{
   
    public class RegexUtilTest
    {

        private readonly ITestOutputHelper output;

        public RegexUtilTest(ITestOutputHelper testOutputHelper)
        {
            output = testOutputHelper;
        }

        [Fact]
        public void KeepNumberTest()
        {
            var str = RegexUtil.KeepNumber("1qe2vd3k");
            output.WriteLine(str);
            Assert.Equal("123", str);
        }
    }
}
