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
            var regex = new Regex(@"\d+");
            var m = regex.Match(str);
            return m.ToString();
        }
    }
}
