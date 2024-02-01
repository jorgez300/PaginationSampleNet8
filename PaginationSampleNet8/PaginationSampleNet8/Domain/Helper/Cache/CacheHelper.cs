using Microsoft.Extensions.Caching.Memory;

namespace PaginationSampleNet8.Domain.Helper.Cache
{
    public class CacheHelper
    {
        private readonly IMemoryCache _cache;

        public CacheHelper(IMemoryCache cache)
        {
            _cache = cache;
        }

        public T? GetValue<T>(string key)
        {
            return _cache.Get<T>(key);
        }

        public void SetValue<T>(string key, T value, double minutes = 1)
        {
            _cache.Set<T>(key, value, TimeSpan.FromMinutes(minutes));
        }

        public bool Exists<T>(string key) 
        {
            return (_cache.Get<T>(key) != null);
        }
    }
}
