using Microsoft.Extensions.Options;
using ServiceStack.Redis;
using System;

namespace BasketCore.Cashe
{
    public class RedisCasheService : ICasheService
    {
        public readonly IOptions<RedisOption> _option;
        public RedisEndpoint redisEndPoint;
        public readonly DateTime expires;
        public RedisCasheService(IOptions<RedisOption> option)
        {
            _option = option;

            redisEndPoint = new RedisEndpoint { 
                Host = _option.Value.Host, 
                Port = _option.Value.Port, 
                RetryTimeout = _option.Value.Timeout 
            };

            expires = DateTime.Now.AddMinutes(_option.Value.Expires);
        }

        public T Get<T>(string key)
        {
            using (IRedisClient client = new RedisClient(redisEndPoint))
            {
                //I bypassed because of not installing redis
                //return client.Get<T>(key);
                return default;
            }
        }

        public void Set<T>(string key, T item)
        {
            try
            {
                using (IRedisClient client = new RedisClient(redisEndPoint))
                {
                    client.Set(key, item, expires);
                }
            }
            catch (Exception)
            {
                //There can be log process
            }

        }
    }
}
