// -----------------------------------------------------------------------
//  <copyright file="Log4NetLoggingConfigReseter.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-10-10 10:50</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Configs;


namespace OSky.Logging.Log4Net
{
    /// <summary>
    /// Log4Net日志配置信息重置类
    /// </summary>
    public class Log4NetLoggingConfigReseter : ILoggingConfigReseter
    {
        /// <summary>
        /// 日志配置信息重置
        /// </summary>
        /// <param name="config">待重置的日志配置信息</param>
        /// <returns>重置后的日志配置信息</returns>
        public LoggingConfig Reset(LoggingConfig config)
        {
            if (config.BasicLoggingConfig.AdapterConfigs.Count == 0)
            {
                config.BasicLoggingConfig.AdapterConfigs.Add(new LoggingAdapterConfig()
                {
                    AdapterType = typeof(Log4NetLoggerAdapter)
                });
            }
            return config;
        }
    }
}