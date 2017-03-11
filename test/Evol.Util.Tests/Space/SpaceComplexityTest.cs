using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Evol.Utilities.Test.Space
{
    [TestClass]
    public class SpaceComplexityTest
    {
        [TestMethod]
        public void GuidAddListTest()
        {
            var count = 1000 * 10000;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            //var list = new List<string>();
            //for (int i = 0; i < count; i++)
            //{
            //    list.Add(Guid.NewGuid().ToString().ToLower());
            //}

            //Trace.WriteLine(String.Format("执行{0}次List.Add(Guid.NewGuid().ToString().ToLower()), 耗时{1}秒", count, stopwatch.ElapsedMilliseconds / 1000));
            stopwatch.Reset();

            var list2 = new List<string>();
            for (int i = 0; i < count; i++)
            {
                list2.Add(Guid.NewGuid().ToString());
            }

            Trace.WriteLine(String.Format("执行{0}次List.Add(Guid.NewGuid().ToString()), 耗时{1}秒", count, stopwatch.ElapsedMilliseconds / 1000));
           

            //int size = Marshal.SizeOf(list);

            //Trace.WriteLine("包含" + count + "Guid字符串的List，size M：" + size/(1024 * 1024));
            stopwatch.Stop();
        }


        [TestMethod]
        public void StringIntAddListTest()
        {
            long gcTotalMemory1 = GC.GetTotalMemory(false);
            var count = 1000 * 10000;
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var list2 = new List<int>();
            for (int i = 0; i < count; i++)
            {
                list2.Add(i);
            }
            long gcTotalMemory2 = GC.GetTotalMemory(false);

            Trace.WriteLine(String.Format("执行{0}次List.Add(int), 耗时{1}毫秒, 字节MB：{2}", count, stopwatch.ElapsedMilliseconds, (gcTotalMemory2 - gcTotalMemory1) / (1024.00 * 1024.00)));
            stopwatch.Restart();

            var list3 = new List<string>();
            for (int i = 0; i < count; i++)
            {
                list3.Add(i.ToString());
            }

            long gcTotalMemory3 = GC.GetTotalMemory(false);

            Trace.WriteLine(String.Format("执行{0}次List.Add(int.ToString()), 耗时{1}毫秒, 字节MB：{2}", count, stopwatch.ElapsedMilliseconds, (gcTotalMemory3 - gcTotalMemory2) / (1024.00 * 1024.00)));
            stopwatch.Restart();

            var list4 = new List<int>();
            for (int i = 0; i < count; i++)
            {
                list4.Add(i.ToString().GetHashCode());
            }

            long gcTotalMemory4 = GC.GetTotalMemory(false);
            Trace.WriteLine(String.Format("执行{0}次List.Add(int.ToString().GetHashCode()), 耗时{1}毫秒, 字节MB：{2}", count, stopwatch.ElapsedMilliseconds, (gcTotalMemory4 - gcTotalMemory3) / (1024.00 * 1024.00)));

            //int size = Marshal.SizeOf(list);

            //Trace.WriteLine("包含" + count + "Guid字符串的List，size M：" + size/(1024 * 1024));
            stopwatch.Stop();
        }


    }


}
