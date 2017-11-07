using System;
using StackExchange.Redis;

namespace AzureRadisCache
{
    class Program
    {
        static void Main(string[] args)
        {
            IDatabase _cache = RedisStore.Connection.GetDatabase();
            _cache.StringSet("key1", "value1");
            _cache.StringSet("key2", 25);

            string key1 = _cache.StringGet("key1");
            int key2 = (int)_cache.StringGet("key2");

            Console.WriteLine($"Key1 = {key1} \n Key2={key2}");
        }
    }
    public class RedisStore
    {
        public static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            return ConnectionMultiplexer.Connect("my-redis-cahe.redis.cache.windows.net:6380,password=e0jXC3rThi3OgmbXH+NAfUG+rhmNX2+vuNen7KrbK6Y=,ssl=True,abortConnect=False");
        });

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }

    }
}
