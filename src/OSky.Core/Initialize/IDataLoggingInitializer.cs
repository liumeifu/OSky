// -----------------------------------------------------------------------
//  <copyright file="IDataLoggingInitializer.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-07-29 12:36</last-date>
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
    /// 定义数据日志初始化器，用于初始化数据日志功能
    /// </summary>
    public interface IDataLoggingInitializer
    {
        /// <summary>
        /// 开始初始化数据日志
        /// </summary>
        /// <param name="config">数据日志配置信息</param>
        void Initialize(DataLoggingConfig config);
    }
}