using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Xunit;

namespace Evol.Utilities.Test.Space
{
    public class SpaceSizeTest
    {
        [Fact]
        public void SizeOfTest()
        {
            Trace.WriteLine("byte sizeof:" + sizeof(byte));
            Trace.WriteLine("int sizeof:" + sizeof(int));
            Trace.WriteLine("unint sizeof:" + sizeof(uint));
            Trace.WriteLine("long sizeof:" + sizeof(long));
            Trace.WriteLine("ulong sizeof:" + sizeof(ulong));
            Trace.WriteLine("float sizeof:" + sizeof(float));
            Trace.WriteLine("double sizeof:" + sizeof(double));
            Trace.WriteLine("decimal sizeof:" + sizeof(decimal));
            Trace.WriteLine("Guid.NewGuid sizeof:" + Marshal.SizeOf(Guid.NewGuid()));
            var str = "http://www.cnblogs.com/article/1231212";
            Trace.WriteLine("string str.GetHashCode():‘" + str.GetHashCode() + "’ sizeof:" + sizeof(int));
        }

        [Fact]
        public void TestMethod1()
        {
            var length = 10000L * 10000L; // 一亿
            var counterSize = Marshal.SizeOf(new Counter());
            Trace.WriteLine(length + "个 Counter struct 数组 MB:" + ((length * counterSize) / 1024.00 / 1024.00));

            Trace.WriteLine(length + "个 byte 数组 MB:" + (length / 1024.00 / 1024.00));
        }

    }




    public struct Counter
    {
        public byte Falg;

        public short Count;
    }
}
