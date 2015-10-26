﻿// -----------------------------------------------------------------------
//  <copyright file="DataLoggingConfig.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-07-01 15:06</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Configs.ConfigFile;
using OSky.Utility.Logging;


namespace OSky.Core.Configs
{
    /// <summary>
    /// 数据日志配置信息
    /// </summary>
    public class DataLoggingConfig
    {
        private const string DefaultAdapterTypeName = "OSky.Core.Data.Entity.Logging.DatabaseLoggerAdapter, OSky.Core.Data.Entity";

        /// <summary>
        /// 初始化一个<see cref="DataLoggingConfig"/>类型的新实例
        /// </summary>
        public DataLoggingConfig()
        {
            Enabled = true;
            OutLevel = LogLevel.All;
            AdapterType = Type.GetType(DefaultAdapterTypeName);
        }

        /// <summary>
        /// 初始化一个<see cref="DataLoggingConfig"/>类型的新实例
        /// </summary>
        internal DataLoggingConfig(DataLoggingElement element)
        {
            Enabled = element.Enabled;
            OutLevel = element.OutLogLevel;
            AdapterType = Type.GetType(element.AdapterTypeName);
        }

        /// <summary>
        /// 获取或设置 是否启用数据日志
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 获取或设置 日志输出级别
        /// </summary>
        public LogLevel OutLevel { get; set; }

        /// <summary>
        /// 获取或设置 适配器类型
        /// </summary>
        public Type AdapterType { get; set; }
    }
}