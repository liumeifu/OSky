// -----------------------------------------------------------------------
//  <copyright file="ILoggingContract.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-06-30 3:32</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using OSky.Core;
using OSky.Core.Dependency;
using OSky.Core.Logging;
using OSky.Utility.Data;


namespace OSky.UI.Contracts
{
    /// <summary>
    /// 业务契约——日志模块
    /// </summary>
    public interface ILoggingContract : IScopeDependency
    {
        #region 数据日志信息业务

        /// <summary>
        /// 获取 操作日志信息查询数据集
        /// </summary>
        IQueryable<OperateLog> OperateLogs { get; }

        /// <summary>
        /// 获取 数据日志信息查询数据集
        /// </summary>
        IQueryable<DataLog> DataLogs { get; }

        /// <summary>
        /// 获取 数据日志项信息查询数据集
        /// </summary>
        IQueryable<DataLogItem> DataLogItems { get; }

        /// <summary>
        /// 删除操作日志信息信息
        /// </summary>
        /// <param name="ids">要删除的操作日志信息编号</param>
        /// <returns>业务操作结果</returns>
        OperationResult DeleteOperateLogs(params int[] ids);

        #endregion

    }
}