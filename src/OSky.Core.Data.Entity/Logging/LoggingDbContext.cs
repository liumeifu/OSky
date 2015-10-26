// -----------------------------------------------------------------------
//  <copyright file="LoggingDbContext.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-06-29 22:14</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OSky.Core.Data.Entity.Logging
{
    /// <summary>
    /// 日志数据上下文
    /// </summary>
    public class LoggingDbContext : DbContextBase<LoggingDbContext>
    {
        /// <summary>
        /// 获取 是否允许数据库日志记录
        /// </summary>
        protected override bool DataLoggingEnabled { get { return false; } }

    }
}