﻿// -----------------------------------------------------------------------
//  <copyright file="LoggingAdapterElement.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-06-30 15:15</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OSky.Core.Configs.ConfigFile
{
    /// <summary>
    /// 日志输出适配器配置节点
    /// </summary>
    internal class LoggingAdapterElement : ConfigurationElement
    {
        private const string NameKey = "name";
        private const string EnabledKey = "enabled";
        private const string TypeKey = "type";

        /// <summary>
        /// 获取或设置 适配器名称
        /// </summary>
        [ConfigurationProperty(NameKey, IsRequired = true, IsKey = true)]
        public virtual string Name
        {
            get { return (string)this[NameKey]; }
            set { this[NameKey] = value; }
        }

        /// <summary>
        /// 获取或设置 是否启用
        /// </summary>
        [ConfigurationProperty(EnabledKey, DefaultValue = true)]
        public virtual bool Enabled
        {
            get { return (bool)this[EnabledKey]; }
            set { this[EnabledKey] = value; }
        }

        /// <summary>
        /// 获取或设置 适配器类型名称
        /// </summary>
        [ConfigurationProperty(TypeKey, IsRequired = true)]
        public virtual string AdapterTypeName
        {
            get { return (string)this[TypeKey]; }
            set { this[TypeKey] = value; }
        }

    }
}