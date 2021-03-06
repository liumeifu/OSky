﻿// -----------------------------------------------------------------------
//  <copyright file="BasicLoggingElement.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-07-01 14:50</last-date>
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
    /// 基础日志配置节点
    /// </summary>
    internal class BasicLoggingElement : ConfigurationElement
    {
        private const string AdapterKey = "adapters";

        /// <summary>
        /// 获取或设置 日志适配器配置节点集合
        /// </summary>
        [ConfigurationProperty(AdapterKey)]
        public virtual LoggingAdapterCollection Adapters
        {
            get { return (LoggingAdapterCollection)base[AdapterKey]; }
        }
    }
}