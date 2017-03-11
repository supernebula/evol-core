using Enyim.Caching;
using Enyim.Caching.Configuration;
using Enyim.Caching.Memcached;

namespace Evol.Cache.Test
{
    public static class MemcachedHelper
    {
        private static MemcachedClient _client;

        static MemcachedHelper()
        {
            _client = new MemcachedClient(new MemcachedClientConfiguration()
            {
                /// init   paramd  
            });
        }


        public static bool Add(string key, object value)
        {
            return _client.Store(StoreMode.Add, key, value);
        }

        public static bool Set(string key, object value)
        {
            return _client.Store(StoreMode.Set, key, value);
        }

        public static bool Replace(string key, object value)
        {
            return _client.Store(StoreMode.Replace, key, value);
        }


        public static T Get<T>(string key)
        {
            return _client.Get<T>(key);
        }

        public static object Get(string key)
        {
            return _client.Get(key);
        }


        public static bool Remove(string key)
        {
            return _client.Remove(key);
        }
    }
}
