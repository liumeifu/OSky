// -----------------------------------------------------------------------
//  <copyright file="BasicLoggingConfig.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-07-01 14:49</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Configs.ConfigFile;


namespace OSky.Core.Configs
{
    /// <summary>
    /// 基础日志配置信息
    /// </summary>
    public class BasicLoggingConfig
    {
        /// <summary>
        /// 初始化一个<see cref="BasicLoggingConfig"/>类型的新实例
        /// </summary>
        public BasicLoggingConfig()
        {
            AdapterConfigs = new List<LoggingAdapterConfig>();
        }

        /// <summary>
        /// 初始化一个<see cref="BasicLoggingConfig"/>类型的新实例
        /// </summary>
        internal BasicLoggingConfig(BasicLoggingElement element)
        {
            AdapterConfigs = element.Adapters.OfType<LoggingAdapterElement>()
                .Select(adapter => new LoggingAdapterConfig(adapter)).ToList();
        }

        /// <summary>
        /// 获取或设置 日志适配器配置信息集合
        /// </summary>
        public ICollection<LoggingAdapterConfig> AdapterConfigs { get; set; }
    }
}