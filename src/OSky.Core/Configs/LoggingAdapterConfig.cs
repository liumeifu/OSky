﻿// -----------------------------------------------------------------------
//  <copyright file="LoggingAdapterConfig.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-06-30 18:03</last-date>
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
    /// 日志适配器配置信息
    /// </summary>
    public class LoggingAdapterConfig
    {
        /// <summary>
        /// 初始化一个<see cref="LoggingAdapterConfig"/>类型的新实例
        /// </summary>
        public LoggingAdapterConfig()
        {
            Name = Guid.NewGuid().ToString();
            Enabled = true;
        }

        /// <summary>
        /// 初始化一个<see cref="LoggingAdapterConfig"/>类型的新实例
        /// </summary>
        internal LoggingAdapterConfig(LoggingAdapterElement element)
        {
            Name = element.Name;
            Enabled = element.Enabled;
            AdapterType = Type.GetType(element.AdapterTypeName);
        }

        /// <summary>
        /// 获取或设置 适配器名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置 是否启用适配器
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 获取或设置 适配器类型
        /// </summary>
        public Type AdapterType { get; set; }
    }
}