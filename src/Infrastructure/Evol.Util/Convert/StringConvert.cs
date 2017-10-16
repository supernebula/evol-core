using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evol.Util.Convert
{
    [Obsolete("未完成...")]
    public static class StringConvert
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">基本数据类型</typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T To<T>(string str)
        {
            var a = System.Convert.ToInt32("2");
            throw new NotImplementedException();
        }

        public static bool TryToByte(string str, ref byte value)
        {
            byte temp;
            return byte.TryParse(str, out temp) && (value = temp) == temp;
        }

        public static short ToShort(string str)
        {
            throw new NotImplementedException();
        }

        public static ushort ToUShort(string str)
        {
            throw new NotImplementedException();
        }

        public static int ToInt(string str)
        {
            throw new NotImplementedException();
        }

        public static uint ToUInt(string str)
        {
            throw new NotImplementedException();
        }

        public static long ToLong(string str)
        {
            throw new NotImplementedException();
        }

        public static ulong ToULong(string str)
        {
            throw new NotImplementedException();
        }

        public static float ToFloat(string str)
        {
            throw new NotImplementedException();
        }

        public static double ToDouble(string str)
        {
            throw new NotImplementedException();
        }

        public static decimal ToDecimal(string str)
        {
            throw new NotImplementedException();
        }


    }
}
