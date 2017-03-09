using System;

namespace Evol.Util.Nature
{
    public class EarthUtility
    {
        private static double Rad(double d)
        {
            return d * Math.PI / 180.0;
        }

        /// <summary>
        /// 根据经纬度，返回两个坐标点之间的距离
        /// </summary>
        /// <param name="lat1">纬度1</param>
        /// <param name="lng1">经度1</param>
        /// <param name="lat2">纬度2</param>
        /// <param name="lng2">经度2</param>
        /// <returns></returns>
        public static double GetDistance(double lat1, double lng1, double lat2, double lng2)
        {

            var earthRadius = 6378.137;//地球半径  
            double radLat1 = Rad(lat1);
            double radLat2 = Rad(lat2);
            double a = radLat1 - radLat2;
            double b = Rad(lng1) - Rad(lng2);

            double s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) +
             Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));
            s = s * earthRadius;
            s = Math.Round(s * 10000) / 10000;
            return s;
        }
    }
}
