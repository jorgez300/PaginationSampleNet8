using Microsoft.Extensions.Caching.Memory;

namespace PaginationSampleNet8.Domain.Adapter.Cache
{
    public class CacheAdapter
    {
        private readonly IMemoryCache _cache;

        public CacheAdapter(IMemoryCache cache)
        {
            _cache = cache;
        }

        public T? GetValue<T>(string key)
        {
            return _cache.Get<T>(key);
        }

        public void SetValue<T>(string key, T value)
        {
            _cache.Set<T>(key, value);
        }
    }
}
