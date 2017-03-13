using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Evol.Util.Maths
{
    public class RandomUtil
    {
        static RandomNumberGenerator _rng;
        static RandomUtil()
        {
            _rng = RandomNumberGenerator.Create();
        }
        public static int RealRandom(int min, int max)
        {
            //这样产生min ~ max的强随机数（含max）
            int rnd = int.MinValue;
            decimal _base = (decimal)long.MaxValue;
            byte[] rndSeries = new byte[8];
            _rng.GetBytes(rndSeries);
            //不含max需去掉+1 
            rnd = (int)(Math.Abs(BitConverter.ToInt64(rndSeries, 0)) / _base * (max + 1));

            return rnd;

            //这个rnd就是你要的随机数，
            //但是要注意别扔到循环里去，实例化RNG对象可是很消耗资源的
        }

        public static List<int> RealRandom(int min, int max, int count)
        {
            //这样产生min ~ max的强随机数（含max）
            int rnd = int.MinValue;
            decimal _base = (decimal)long.MaxValue;
            byte[] rndSeries = new byte[8];

            var result = new List<int>();
            for (int i = 0; i < count; i++)
            {
                _rng.GetBytes(rndSeries);
                //不含max需去掉+1 
                rnd = (int)(Math.Abs(BitConverter.ToInt64(rndSeries, min)) / _base * (max + 1));
                result.Add(rnd);
            }
            return result;

            //这个rnd就是你要的随机数，
            //但是要注意别扔到循环里去，实例化RNG对象可是很消耗资源的
        }

        public static int Random(int min, int max, int? seed = null)
        {
            Random random = seed == null ? new Random(Guid.NewGuid().GetHashCode()) : new Random(seed.Value);
            return random.Next(min, max);
        }

        public static double RandomDouble(int min, int max, int? seed = null)
        {
            Random random = seed == null ? new Random(Guid.NewGuid().GetHashCode()) : new Random(seed.Value);
            return random.NextDouble() * random.Next(min, max);
        }

        public static string RandomLetter(int minLength, int maxLength, int? seed = null)
        {
            var letters = new[] {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"};
            Random random = seed == null ? new Random(Guid.NewGuid().GetHashCode()) : new Random(seed.Value);
            var length =  random.Next(minLength, maxLength);
            string str = null;
            for (int i = 0; i < length; i++)
            {
                str += letters[random.Next(0, letters.Length - 1)];
            }
            return str;
        }

        public static string RandomLetter(int length, int? seed = null)
        {
            var letters = new[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            Random random = seed == null ? new Random(Guid.NewGuid().GetHashCode()) : new Random(seed.Value);
            string str = null;
            for (int i = 0; i < length; i++)
            {
                str += letters[random.Next(0, letters.Length - 1)];
            }
            return str;
        }
    }
}
