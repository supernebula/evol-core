using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackExchange.Redis;
using System.Diagnostics;

namespace Evol.Redis.Test
{
    [TestClass]
    public class BasicTest
    {
        [TestMethod]
        public void ConnectTest()
        {
            var redis = ConnectionMultiplexer.Connect("localhost");
            Assert.IsTrue(redis.IsConnected);
            redis.Close();
        }

        [TestMethod]
        public void DatabaseTest()
        {
            var redis = ConnectionMultiplexer.Connect("localhost");
            Assert.IsTrue(redis.IsConnected);

            var db = redis.GetDatabase();
            var key = "key1";
            var value = "12345678";

            db.KeyDelete(key);
           
            var success = db.StringSet(key, value);
            var value2 = db.StringGet(key);
            Assert.IsTrue(value == value2);

            redis.Close();
        }

        [TestMethod]
        public void DeleteTest()
        {
            var redis = ConnectionMultiplexer.Connect("localhost");
            Assert.IsTrue(redis.IsConnected);

            var db = redis.GetDatabase();

            var success = db.KeyDelete("1");
            var success2 = db.KeyDelete("2");

            redis.Close();
        }

        [TestMethod]
        public void BitSetTest()
        {
            var redis = ConnectionMultiplexer.Connect("localhost");
            Assert.IsTrue(redis.IsConnected);
            var db = redis.GetDatabase();
            db.StringSetBit("bloom", 0, 1 == 1);
            db.StringSetBit("bloom", 1, 1 == 1);
            db.StringSetBit("bloom", 99, 1 == 1);
            var bitSetCount = db.StringBitCount("bloom");

            var b0 = db.StringGetBit("bloom", 0) ? 1 : 0;
            var b1 = db.StringGetBit("bloom", 1) ? 1 : 0;
            var b2 = db.StringGetBit("bloom", 2) ? 1 : 0;
            var b3 = db.StringGetBit("bloom", 3) ? 1 : 0;
            var b99 = db.StringGetBit("bloom", 99) ? 1 : 0;
            
            Trace.WriteLine("bitSetCount=" + bitSetCount);
            Trace.WriteLine(string.Format("{0:d}{1:d}{2:d}{3:d}.........{4:d}", b0, b1, b2, b3, b99));

        }


    }
}
