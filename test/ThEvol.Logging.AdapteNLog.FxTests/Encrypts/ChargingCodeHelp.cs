using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThEvol.Logging.AdapteNLog.FxTests.Encrypts
{
    public class ChargingCodeHelp
    {
        private static UInt32[] KEY = new UInt32[]{
                0x5A48,
                0x4A4B5843, 0x090C0608
            };
        /// <summary>
        /// 加密电码充电参数
        /// </summary>
        /// <param name="deviceNumber">设备号</param>
        /// <param name="deviceWay">端口号</param>
        /// <param name="timeLong">充电时长</param>
        /// <param name="Num">自增值</param>
        /// <returns></returns>
        public static string CodeDecode(string deviceNumber, int deviceWay, int timeLong, int Num)
        {
            var str = string.Empty;
            byte[] ba = ASCIIEncoding.Default.GetBytes(deviceNumber);
            var key11 = string.Empty;
            var key2 = string.Empty;
            for (var i = ba.Length - 1; i >= 0; i--)
            {
                if (i < 4)
                {
                    key2 += ba[i].ToString("x");
                }
                else
                {
                    key11 += ba[i].ToString("x");
                }
            }
            var KEY1list = KEY.ToList();
            var zzr = KEY1list[0].ToString("x");
            KEY1list[0] = Convert.ToUInt32("0x" + zzr + key11, 16);
            var item0 = Convert.ToUInt32("0x" + key2, 16);
            KEY1list.Insert(0, item0);
            var result = KEY1list.ToArray();


            var laws = new List<byte>();
            var deviceWaybyte = BitConverter.GetBytes(deviceWay);
            laws.Add(deviceWaybyte[0]);

            var timeLongbyte = BitConverter.GetBytes(timeLong);
            laws.Add(timeLongbyte[1]);
            laws.Add(timeLongbyte[0]);

            var Numbyte = BitConverter.GetBytes(Num);
            laws.Add(Numbyte[3]);
            laws.Add(Numbyte[2]);
            laws.Add(Numbyte[1]);
            laws.Add(Numbyte[0]);

            laws.Add(0x00);

            byte[] tempEncrpt = encrypt(laws.ToArray(), 0, result, 32);
            var str1 = string.Empty;
            for (var i = 0; i < 4; i++)
            {
                str1 += tempEncrpt[i].ToString("x2");
            }
            var z = Convert.ToUInt32("0x" + str1, 16);
            //ar z1 = Convert.ToString(z);
            var zz = Convert.ToString(z, 10);
            var code = zz.Substring(zz.Length - 5, 5);
            var timestr = timeLong.ToString();
            if (timestr.Length == 2)
            {
                timestr = "0" + timestr;
            }
            else if (timestr.Length == 1)
            {
                timestr = "00" + timestr;
            }
            //if(timestr.Length)
            code = code.Insert(3, timestr.Substring(timestr.Length - 1, 1)).Insert(2, timestr.Substring(timestr.Length - 2, 1)).Insert(1, timestr.Substring(0, 1));
            return code;
        }
        private static uint[] byteToInt(byte[] content, uint offset)
        {

            uint[] result = new uint[2]; //除以2的n次方 == 右移n位 即 content.length / 4 == content.length >> 2
            for (uint i = 0, j = offset; (j < (offset + 8)) && (j < content.Length); i++, j += 4)
            {
                result[i] = transform(content[j + 3]) << 24 | transform(content[j + 2]) << 16 | transform(content[j + 1]) << 8 | transform(content[j]);
            }
            return result;

        }

        //int[]型数据转成byte[]型数据
        private static byte[] intToByte(uint[] content, uint offset)
        {
            byte[] result = new byte[content.Length << 2];//乘以2的n次方 == 左移n位 即 content.length * 4 == content.length << 2
            for (uint i = 0, j = offset; j < result.Length; i++, j += 4)
            {
                result[j + 3] = (byte)((content[i] >> 24) & 0xff);
                result[j + 2] = (byte)((content[i] >> 16) & 0xff);
                result[j + 1] = (byte)((content[i] >> 8) & 0xff);
                result[j] = (byte)(content[i] & 0xff);
            }
            return result;
        }

        //TEA加密
        private static byte[] encrypt(byte[] content, uint offset, uint[] key, uint times)
        {
            //times为加密轮数
            uint[] tempInt = byteToInt(content, offset);  //将加密数据分为两部分
            uint left = tempInt[0], right = tempInt[1], sum = 0;

            uint delta = 0x9e3779b9; //这是算法标准给的值
            uint a = key[0], b = key[1], c = key[2], d = key[3];

            while (times-- > 0)
            {
                sum += delta;
                left += ((right << 4) + a) ^ (right + sum) ^ ((right >> 5) + b);
                right += ((left << 4) + c) ^ (left + sum) ^ ((left >> 5) + d);
            }

            tempInt[0] = left;
            tempInt[1] = right;
            return intToByte(tempInt, 0);
        }
        private static uint transform(byte temp)
        {
            uint tempInt = (uint)temp;
            if (tempInt < 0)
            {
                tempInt += 256;
            }
            return tempInt;
        }
    }
}
