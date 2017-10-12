using System;
using System.Collections.Generic;
using System.Text;
using Evol.Util;
using Evol.Common;
using Xunit;
using Xunit.Abstractions;
using System.Linq;
using Evol.Util.Extension;
using Evol.Util.Hash;

namespace Evol.Util.Tests.Hash
{
    public class HashUtilTest
    {

        private readonly ITestOutputHelper output;

        public HashUtilTest(ITestOutputHelper testOutputHelper)
        {
            output = testOutputHelper;
        }

        [Fact]
        public void Md5Test()
        {
            var temp = "werwerwerwerererererererererererererererer";
            var sign = HashUtil.Md5(temp);
            output.WriteLine($"sign：{sign}");
        }
    }
}
