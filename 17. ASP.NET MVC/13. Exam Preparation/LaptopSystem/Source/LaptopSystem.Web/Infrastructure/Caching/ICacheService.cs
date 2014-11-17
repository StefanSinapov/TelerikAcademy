namespace LaptopSystem.Web.Infrastructure.Caching
{
    using System;

    public interface ICacheService
    {
        T Get<T>(string cacheId, Func<T> getItemCallback) where T : class;

        void Clear(string cacheId);
    }
}