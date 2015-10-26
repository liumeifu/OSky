// -----------------------------------------------------------------------
//  <copyright file="IBasicLoggingInitializer.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-07-29 13:41</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Configs;


namespace OSky.Core.Initialize
{
    /// <summary>
    /// 定义基础日志初始化器，用于初始化基础日志功能
    /// </summary>
    public interface IBasicLoggingInitializer
    {
        /// <summary>
        /// 开始初始化基础日志
        /// </summary>
        /// <param name="config">日志配置信息</param>
        void Initialize(LoggingConfig config);
    }
}