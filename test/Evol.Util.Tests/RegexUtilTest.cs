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

        [Fact]
        public void IntBiteConvertTest()
        {
            short num = 345;
            var bytes = BitConverter.GetBytes(num);
            var hexStr = num.ToString("X2");
            output.WriteLine(num + "=" + hexStr);
            foreach (var _byte in bytes)
            {
                var str = _byte.ToString("0x");
            }
        }
    }
}
