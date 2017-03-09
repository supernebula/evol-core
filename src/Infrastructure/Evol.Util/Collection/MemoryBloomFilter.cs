using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Evol.Util.Collection
{
    /// <summary>
    /// 内存布隆过滤器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MemoryBloomFilter<T>
    {
        #region Fields

        /// <summary>
        /// 位数组
        /// </summary>
        private readonly BitArray _bitArray;

        /// <summary>
        /// 数据量
        /// </summary>
        private readonly int _dataSize;
        /// <summary>
        /// 空间大小
        /// </summary>
        private readonly int _spaceSize;

        /// <summary>
        /// Hash函数最佳个数
        /// </summary>
        private readonly int _numberOfHashes;

        #endregion


        #region Properties

        /// <summary>
        /// 假阳性概率
        /// </summary>
        public double FalsePositiveRate { get; private set; }


        public int DataSize => _dataSize;

        public int SpaceSize => _spaceSize;

        public int NumberOfHashes => _numberOfHashes;

        #endregion


        #region Constructors

        /// <summary>
        /// 构造方法， 自动计算最佳空间和Hash函数最佳个数
        /// </summary>
        /// <param name="dataSize">数据量</param>
        /// <param name="falsePositiveRate">假阳性概率</param>
        [Obsolete("未实现...")]
        public MemoryBloomFilter(int dataSize, float falsePositiveRate)
        {
            _dataSize = dataSize;
            FalsePositiveRate = falsePositiveRate;
            throw  new NotImplementedException();
        }

        /// <summary>
        /// 构造方法， 自动计算Hash函数最佳个数
        /// </summary>
        /// <param name="dateSize">数据量</param>
        /// <param name="spaceSize">空间量</param>
        public MemoryBloomFilter(int dateSize, int spaceSize)
        {
            _dataSize = dateSize;
            _spaceSize = spaceSize;
            _numberOfHashes = OptimalNumberOfHashes();
            FalsePositiveRate = FalsePositiveProbability();
            _bitArray = new BitArray(_spaceSize);

        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="dateSize">数据量</param>
        /// <param name="spaceSize">空间量</param>
        /// <param name="numberOfHashes">Hash函数最佳个数</param>
        public MemoryBloomFilter(int dateSize, int spaceSize, int numberOfHashes)
        {
            _dataSize = dateSize;
            _spaceSize = spaceSize;
            _numberOfHashes = numberOfHashes;
            FalsePositiveRate = FalsePositiveProbability();
            _bitArray = new BitArray(_spaceSize);
        }

        #endregion


        #region Method

        public void Add(T item)
        {
            var random = new Random(Hash(item));
            for (int i = 0; i < _numberOfHashes; i++)
            {
                _bitArray[random.Next(_spaceSize)] = true;
            }
        }

        public bool Contains(T item)
        {
            var random = new Random(Hash(item));
            for (int i = 0; i < _numberOfHashes; i++)
            {
                if(!_bitArray[random.Next(_spaceSize)])
                    return false;

            }
            return true;
        }

        public bool ContainsAny(IEnumerable<T> items)
        {
            return items.Any(Contains);
        }

        public bool ContainsAll(IEnumerable<T> items)
        {
            return items.All(Contains);
        }

        /// <summary>
        /// 假阳性概率
        /// </summary>
        /// <returns></returns>
        private double FalsePositiveProbability()
        {
            return Math.Pow((1 - Math.Exp(-_numberOfHashes * _dataSize / (double)_spaceSize)), _numberOfHashes);
        }

        private int Hash(T item)
        {
            return item.GetHashCode();
        }

        private int OptimalNumberOfHashes()
        {
            return (int)Math.Ceiling((_spaceSize * 1.00 / _dataSize) * Math.Log(2.0));
        }

        #endregion
    }
}
