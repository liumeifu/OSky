﻿// -----------------------------------------------------------------------
//  <copyright file="LoggingEntryElement.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-07-01 11:50</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Utility.Logging;


namespace OSky.Core.Configs.ConfigFile
{
    /// <summary>
    /// 日志输入配置节点
    /// </summary>
    internal class LoggingEntryElement : ConfigurationElement
    {
        private const string EnabledKey = "enabled";
        private const string EntryLogLevelKey = "level";

        /// <summary>
        /// 获取或设置 是否允许日志输入
        /// </summary>
        [ConfigurationProperty(EnabledKey, DefaultValue = true)]
        public virtual bool Enabled
        {
            get { return (bool)this[EnabledKey]; }
            set { this[EnabledKey] = value; }
        }

        /// <summary>
        /// 获取或设置 日志输入级别
        /// </summary>
        [ConfigurationProperty(EntryLogLevelKey, DefaultValue = LogLevel.All)]
        public virtual LogLevel EntryLogLevel
        {
            get { return (LogLevel)this[EntryLogLevelKey]; }
            set { this[EnabledKey] = value; }
        }
    }
}