// -----------------------------------------------------------------------
//  <copyright file="IDataLogCache.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-07-06 1:13</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Dependency;


namespace OSky.Core.Logging
{
    /// <summary>
    /// 数据日志缓存接口
    /// </summary>
    public interface IDataLogCache : IScopeDependency
    {
        /// <summary>
        /// 获取 数据日志集合
        /// </summary>
        IEnumerable<DataLog> DataLogs { get; }

        /// <summary>
        /// 向缓存中添加数据日志信息
        /// </summary>
        /// <param name="dataLog">数据日志信息</param>
        void AddDataLog(DataLog dataLog);
    }
}