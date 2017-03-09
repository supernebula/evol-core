using System;

namespace Evol.Util.Extension
{
    public static class DateExtension
    {
        /// <summary>
        /// Unix时间戳
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string TimeStamp(this DateTime dateTime)
        {
            return String.Format("{0}{1}{2}{3}{4}{5}", dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second);
        }
    }
}
