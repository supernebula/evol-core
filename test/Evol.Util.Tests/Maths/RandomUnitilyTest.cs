using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;
using Evol.Util.Maths;

namespace Evol.Utilities.Test.Maths
{
    public class RandomUnitilyTest
    {
        [Fact]
        public void TestMethod1()
        {
            var guid = Guid.NewGuid().ToString();
            Trace.WriteLine("seed:" + guid);

            Trace.WriteLine("第一轮随机:");
            var random = new Random(guid.GetHashCode());
            for (int i = 0; i < 10; i++)
            {
                var num = random.Next(0, 100000);
                Trace.WriteLine(i + ":" + num);
            }


            Trace.WriteLine("第二轮随机:");
            var random2 = new Random(guid.GetHashCode());


            for (int i = 0; i < 10; i++)
            {
                var num = random2.Next(0, 100000);
                Trace.WriteLine(i + ":" + num);
            }
        }


        [Fact]
        public void RandomLetterTest()
        {
            string str = String.Empty;
            for (int i = 0; i < 10; i++)
            {
                 str = RandomUtil.RandomLetter(8, 15);
                Trace.WriteLine(str);
                Trace.WriteLine(":" + str.Length);
            }
            Assert.True(str != null && str.Length >= 8 && str.Length <= 15, "长度不不符合");
        }


        [Fact]
        public void RealRandomest()
        {
            var list = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                var num = RandomUtil.RealRandom(8, 15);
                list.Add(num);
            }

            foreach (var item in list)
            {
                Trace.WriteLine(item);
            }
        }
    }
}
