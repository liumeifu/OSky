// -----------------------------------------------------------------------
//  <copyright file="ServiceCollectionExtensions.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-10-10 13:00</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Configs;
using OSky.Core.Dependency;
using OSky.Core.Initialize;
using OSky.SiteBase.Initialize;


namespace OSky.Logging.Log4Net
{
    /// <summary>
    /// 服务映射信息集合扩展操作
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加Log4Net日志功能相关映射信息
        /// </summary>
        public static void AddLog4NetServices(this IServiceCollection services)
        {
            if (OSkyConfig.LoggingConfigReseter == null)
            {
                OSkyConfig.LoggingConfigReseter = new Log4NetLoggingConfigReseter();
            }
            services.AddSingleton<IBasicLoggingInitializer, Log4NetLoggingInitializer>();
            services.AddSingleton<Log4NetLoggerAdapter>();
        }
    }
}