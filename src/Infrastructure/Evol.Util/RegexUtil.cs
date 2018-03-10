using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Evol.Util
{
    public static class RegexUtil
    {
        /// <summary>
        /// 仅保留数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string KeepNumber(string str)
        {
            var regex = new Regex(@"\D");
            var str2 = regex.Replace(str, string.Empty);
            return str2;
        }

        /// <summary>
        /// 仅保留非数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string KeepNonNumer(string str)
        {
            var regex = new Regex(@"\d");
            var str2 = regex.Replace(str, string.Empty);
            return str2;
        }
    }
}
