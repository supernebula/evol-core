using System;
using System.Text.RegularExpressions;

namespace Evol.Util.Extension
{
    /// <summary>
    /// 脱敏
    /// </summary>
    public static class StringDesensitization
    {
        /// <summary>
        /// 银行卡号 脱敏
        /// </summary>
        /// <param name="value">银行卡号</param>
        /// <param name="leftDigit">左侧保留位数</param>
        /// <param name="rightDigit">左侧保留位数</param>
        /// <param name="symbol">替换符</param>
        public static string DesensBankCardNumber(this string value, int leftDigit = 6, int rightDigit = 4, string symbol = "*")
        {
            return value.DesensPartial(leftDigit, rightDigit, symbol);
        }

        /// <summary>
        /// 证件号码 脱敏
        /// </summary>
        /// <param name="value">证件号码</param>
        /// <param name="leftDigit">左侧保留位数</param>
        /// <param name="rightDigit">左侧保留位数</param>
        /// <param name="symbol">替换符</param>
        public static string DesensCertNo(this string value, int leftDigit = 6, int rightDigit = 4, string symbol = "*")
        {
            return value.DesensPartial(leftDigit, rightDigit, symbol);
        }

        /// <summary>
        /// 姓名 脱敏, 钝化第一个字
        /// </summary>
        /// <param name="value">姓名</param>
        /// <param name="symbol">替换符</param>
        public static string DesensName(this string value, string symbol = "*")
        {
            if (value == null)
                return null;
            if (value.Length <= 1)
                return value;
            return symbol + value.Substring(1);
        }

        /// <summary>
        /// 手机号 脱敏
        /// </summary>
        /// <param name="value">手机号</param>
        /// <param name="leftDigit">左侧保留位数</param>
        /// <param name="rightDigit">右侧保留位数</param>
        /// <param name="symbol">替换符</param>
        public static string DesensMobile(this string value, int leftDigit = 3, int rightDigit = 4, string symbol = "*")
        {
            return value.DesensPartial(leftDigit, rightDigit, symbol);
        }

        /// <summary>
        /// 固定电话号码 脱敏
        /// </summary>
        /// <param name="value">固定电话号码</param>
        /// <param name="leftDigit">左侧保留位数</param>
        /// <param name="rightDigit">左侧保留位数</param>
        /// <param name="symbol">替换符</param>
        /// <returns></returns>
        public static string DesensPhone(this string value, int leftDigit = 4, int rightDigit = 4, string symbol = "*")
        {

            return value.DesensPartial(leftDigit, rightDigit, symbol);
        }

        /// <summary>
        /// 邮箱 @前面 脱敏， @域名.com 保留
        /// </summary>
        /// <param name="value">邮箱地址</param>
        /// <param name="leftDigit">左侧保留位置</param>
        /// <param name="symbol">替换符</param>
        /// <returns></returns>
        public static string DesensMail(this string value, int leftDigit = 2, string symbol = "*")
        {
            if (value == null)
                return null;
            if (value.IndexOf("@", StringComparison.CurrentCultureIgnoreCase) <= 0)
                return value;

            var perv = value.Substring(0, value.IndexOf("@", StringComparison.CurrentCultureIgnoreCase));
            return perv.DesensPartial(leftDigit, 0) + value.Substring(value.IndexOf("@", StringComparison.CurrentCultureIgnoreCase));
        }



        /// <summary>
        /// 脱敏 替换局部
        /// </summary>
        /// <param name="value">要脱敏的字符串</param>
        /// <param name="leftDigit">左侧保留位数</param>
        /// <param name="rightDigit">右侧保留位数</param>
        /// <param name="symbol">替换符</param>
        /// <returns></returns>
        public static string DesensPartial(this string value, int leftDigit, int rightDigit, string symbol = "*")
        {
            if (value == null)
                return String.Empty;
            if (value.Length == 1)
                return value;
            if (value.Length == 2)
                return symbol + value.Substring(1);
            if (value.Length < leftDigit + rightDigit)
                leftDigit = rightDigit = 1;

            var hide = Regex.Replace(value.Substring(leftDigit, value.Length - rightDigit - leftDigit), @".", symbol);
            return value.Substring(0, leftDigit) + hide + value.Substring(value.Length - rightDigit);
        }
    }
}
