using System;
using System.Globalization;

namespace Evol.Util.Extension
{
    public static class StringExtension
    {
        /// <summary>
        /// 格式化字符串转日期，当前文化区域
        /// </summary>
        /// <param name="dateStr"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static DateTime? ParseDate(this string dateStr, string format)
        {
            if (String.IsNullOrWhiteSpace(dateStr))
                return default(DateTime?);
            DateTime date;
            return DateTime.TryParseExact(dateStr, format, CultureInfo.CurrentCulture, DateTimeStyles.None, out date)
                ? date
                : default(DateTime?);
        }
    }
}
