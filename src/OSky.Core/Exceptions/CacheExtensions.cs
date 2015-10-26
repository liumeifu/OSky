using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Caching;
using OSky.Core.Security;
using OSky.Utility;


namespace OSky.Core.Exceptions
{
    /// <summary>
    /// 缓存扩展辅助操作类
    /// </summary>
    public static class CacheExtensions
    {
        /// <summary>
        /// 根据功能配置添加缓存数据
        /// </summary>
        public static void Set(this ICache cache, string key, object value, IFunction function)
        {
            key.CheckNotNull("key");
            value.CheckNotNull("value");
            if (function == null || function.CacheExpirationSeconds <= 0)
            {
                return;
            }
            if (function.IsCacheSliding)
            {
                cache.Set(key, value, TimeSpan.FromSeconds(function.CacheExpirationSeconds));
            }
            else
            {
                cache.Set(key, value, DateTime.Now.AddSeconds(function.CacheExpirationSeconds));
            }
        }
    }
}
