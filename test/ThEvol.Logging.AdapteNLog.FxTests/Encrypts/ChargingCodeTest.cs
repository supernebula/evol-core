using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ThEvol.Logging.AdapteNLog.FxTests.Encrypts
{
    public class ChargingCodeTest
    {
        protected readonly ITestOutputHelper Output;


        public ChargingCodeTest(ITestOutputHelper output)
        {
            Output = output;

        }


        [Fact]
        public void IntBiteConvertTest()
        {
            var deviceNumber = "000002";
            var deviceWay = 1;
            var timeLong = 120;
            var Num = 1; //自增值
            var code = ChargingCodeHelp.CodeDecode(deviceNumber, deviceWay, timeLong, Num);
            Output.WriteLine($"code={code}");

        }
    }
}
