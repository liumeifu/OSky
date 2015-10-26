// -----------------------------------------------------------------------
//  <copyright file="IOperateLogWriter.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-07-06 2:15</last-date>
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
    /// 操作日志输出接口
    /// </summary>
    public interface IOperateLogWriter : IScopeDependency
    {
        /// <summary>
        /// 输出操作日志
        /// </summary>
        /// <param name="operateLog">操作日志信息</param>
        void Write(OperateLog operateLog);
    }
}