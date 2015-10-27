// -----------------------------------------------------------------------
//  <copyright file="ServiceCollectionExtensions.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-10-10 11:49</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Configs;
using OSky.Core.Data;
using OSky.Core.Data.Entity;
using OSky.Core.Data.Entity.Properties;
using OSky.Core.Dependency;
using OSky.Utility.Extensions;


namespace OSky.Core
{
    /// <summary>
    /// 服务映射集合扩展操作
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加数据层服务映射信息
        /// </summary>
        /// <param name="services">服务映射信息集合</param>
        public static void AddDataServices(this IServiceCollection services)
        {
            //添加上下文类型
            if (OSkyConfig.DataConfigReseter == null)
            {
                OSkyConfig.DataConfigReseter = new DataConfigReseter();
            }
            DataConfig config = OSkyConfig.Instance.DataConfig;
            Type[] contextTypes = config.ContextConfigs.Where(m => m.Enabled).Select(m => m.ContextType).ToArray();
            Type baseType = typeof(IUnitOfWork);
            foreach (var contextType in contextTypes)
            {
                if (!baseType.IsAssignableFrom(contextType))
                {
                    throw new InvalidOperationException(Resources.ContextTypeNotIUnitOfWorkType.FormatWith(contextType));
                }
                services.AddScoped(baseType, contextType);
                services.AddScoped(contextType);
            }

            //其他数据层初始化类型
            services.AddSingleton<IEntityMapperAssemblyFinder, EntityMapperAssemblyFinder>();
        }
    }
}