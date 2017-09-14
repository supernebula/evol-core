using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace Evol.Util.Tests.Performance
{
    public class LoopTests
    {
        private void Excute()
        {
            var temp = Math.Tan(50) * Math.Sin(100);
        }

        [Fact]
        public void WhileLoopTest()
        {
            var num = 1000 * 1000 * 1000;
            while (num > 0)
            {
                Excute();
                num--;
            }
        }


        [Fact]
        public void GotoLoopTest()
        {
            var num = 1000 * 1000 * 1000;
            _START:
                Excute();
                num--;
            if (num > 0)
                goto _START;
        }


        [Fact]
        public void WhileSleepLoopTest()
        {
            var num = 1000;
            while (num > 0)
            {
                Thread.Sleep(100);
                Excute();
                num--;
            }
        }


        [Fact]
        public void GotoSleepLoopTest()
        {
            
            var num = 1000;
            _START:
            Thread.Sleep(100);
            Excute();
            num--;
            if (num > 0)
                goto _START;
        }


    }
}
