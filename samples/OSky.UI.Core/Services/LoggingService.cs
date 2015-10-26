// -----------------------------------------------------------------------
//  <copyright file="LoggingService.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-06-30 3:34</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Data;
using OSky.Core.Logging;
using OSky.UI.Contracts;


namespace OSky.UI.Services
{
    /// <summary>
    /// 业务实现——日志模块
    /// </summary>
    public partial class LoggingService : ILoggingContract
    {
        /// <summary>
        /// 获取或设置 操作日志仓储对象
        /// </summary>
        public IRepository<OperateLog, int> OperateLogRepository { protected get; set; }

        /// <summary>
        /// 获取或设置 数据日志仓储对象
        /// </summary>
        public IRepository<DataLog, int> DataLogRepository { protected get; set; }

        /// <summary>
        /// 获取或设置 数据日志项仓储对象
        /// </summary>
        public IRepository<DataLogItem, Guid> DataLogItemRepository { protected get; set; }
    }
}