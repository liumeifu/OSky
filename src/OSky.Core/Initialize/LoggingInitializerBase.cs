// -----------------------------------------------------------------------
//  <copyright file="LoggingInitializerBase.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-10-10 12:41</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Configs;
using OSky.Utility;
using OSky.Utility.Logging;


namespace OSky.Core.Initialize
{
    /// <summary>
    /// 日志初始化器基类
    /// </summary>
    public abstract class LoggingInitializerBase
    {
        /// <summary>
        /// 获取或设置 服务提供者
        /// </summary>
        public IServiceProvider ServiceProvider { get; set; }

        /// <summary>
        /// 从日志适配器配置节点初始化日志适配器
        /// </summary>
        /// <param name="config">日志适配器配置节点</param>
        protected virtual void SetLoggingFromAdapterConfig(LoggingAdapterConfig config)
        {
            config.CheckNotNull("config");
            if (!config.Enabled)
            {
                return;
            }
            ILoggerAdapter adapter = ServiceProvider.GetService(config.AdapterType) as ILoggerAdapter;
            //Activator.CreateInstance(config.AdapterType) as ILoggerAdapter;

            if (adapter == null)
            {
                return;
            }
            LogManager.AddLoggerAdapter(adapter);
        }
    }
}