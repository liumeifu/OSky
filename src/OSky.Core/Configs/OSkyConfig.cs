// -----------------------------------------------------------------------
//  <copyright file="OSkyConfig.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-10-10 11:05</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Configs.ConfigFile;


namespace OSky.Core.Configs
{
    /// <summary>
    /// OSky配置类
    /// </summary>
    public sealed class OSkyConfig
    {
        private const string OSkySectionName = "OSky";
        private static readonly Lazy<OSkyConfig> InstanceLazy
            = new Lazy<OSkyConfig>(() => new OSkyConfig());

        /// <summary>
        /// 初始化一个心得<see cref="OSkyConfig"/>实例
        /// </summary>
        private OSkyConfig()
        {
            OSkyFrameworkSection section = (OSkyFrameworkSection)ConfigurationManager.GetSection(OSkySectionName);
            if (section == null)
            {
                DataConfig = new DataConfig();
                LoggingConfig = new LoggingConfig();
                return;
            }
            DataConfig = new DataConfig(section.Data);
            LoggingConfig = new LoggingConfig(section.Logging);
        }

        /// <summary>
        /// 获取 配置类的单一实例
        /// </summary>
        public static OSkyConfig Instance
        {
            get
            {
                OSkyConfig config = InstanceLazy.Value;
                if (DataConfigReseter != null)
                {
                    config.DataConfig = DataConfigReseter.Reset(config.DataConfig);
                }
                if (LoggingConfigReseter != null)
                {
                    config.LoggingConfig = LoggingConfigReseter.Reset(config.LoggingConfig);
                }
                return config;
            }
        }

        /// <summary>
        /// 获取或设置 数据配置重置信息
        /// </summary>
        public static IDataConfigReseter DataConfigReseter { get; set; }

        /// <summary>
        /// 获取或设置 日志配置重置信息
        /// </summary>
        public static ILoggingConfigReseter LoggingConfigReseter { get; set; }

        /// <summary>
        /// 获取或设置 数据配置信息
        /// </summary>
        public DataConfig DataConfig { get; set; }

        /// <summary>
        /// 获取或设置 日志配置信息
        /// </summary>
        public LoggingConfig LoggingConfig { get; set; }
    }
}