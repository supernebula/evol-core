using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Evol.Utilities.Collection;

namespace Evol.Utilities.Test.Collection
{
    [TestClass]
    public class BloomFilterTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var dateSize = 1000 * 1000;
            var bloom = new MemoryBloomFilter<string>(dateSize, 1000 * 1000 * 1000);

            var list1 = new List<string>();
            for (int i = 0; i < dateSize; i++)
            {
                list1.Add(Guid.NewGuid().ToString());
            }

            var list2 = new List<string>();
            for (int i = 0; i < dateSize; i++)
            {
                list2.Add(Guid.NewGuid().ToString());
            }

            list1.ForEach(e => bloom.Add(e));

            list1.ForEach(l =>
            {
                Assert.IsTrue(bloom.Contains(l), l + " 必须包含在集合中");
            });

            var falseNumber = 0;

            list2.ForEach(l =>
            {
                if(bloom.Contains(l))
                    falseNumber++;
                //Assert.IsFalse(bloom.Contains(l), l + " 并不包含在集合中");
            });


            Trace.WriteLine(String.Format("SpaceSize:{0}, DataSize:{1}, HashNumber:{2}", bloom.SpaceSize, bloom.DataSize, bloom.NumberOfHashes));

            Trace.WriteLine(String.Format("FalsePositive Number:{0}, FalsePositiveProbability:{1}, Real FalsePositiveProbability:{2}", falseNumber, bloom.FalsePositiveRate, falseNumber * 1.00 / dateSize));



        }
    }
}
