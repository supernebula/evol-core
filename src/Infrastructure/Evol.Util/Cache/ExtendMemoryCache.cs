using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Evol.Util.Cache
{
    [Obsolete("未完成...")]
    public class ExtendMemoryCache
    {
        /// <summary>
        /// 
        /// </summary>
        //.net core  1.1
        //public static MemoryCache Cache = new MemoryCache(new MemoryCacheOptions() {/* ISystemClock = ?*/ CompactOnMemoryPressure = false, ExpirationScanFrequency = TimeSpan.FromMinutes(20)});

        //.net core 2.0
        //public static MemoryCache Cache = new MemoryCache(IOptions<MemoryCacheOptions> optionsAccessor);

        public static bool Add<T>(string key, T obj)
        {
            throw new NotImplementedException();
        }

        public static bool AddOrGetExisting<T>(string key, T obj)
        {
            throw new NotImplementedException();
        }

        public static T Get<T>(string key)
        {
            throw new NotImplementedException();
        }

        public static bool IsExsit(string key)
        {
            throw new NotImplementedException();
        }


        public static T Remove<T>(string key)
        {
            throw new NotImplementedException();
        }

        public static void Set<T>(string key)
        {
            throw new NotImplementedException();
        }

        //...
    }

}
