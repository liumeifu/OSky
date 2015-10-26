// -----------------------------------------------------------------------
//  <copyright file="DatabaseOperateLogWriter.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-09-23 9:08</last-date>
// -----------------------------------------------------------------------

using OSky.Core.Data;
using OSky.Utility;


namespace OSky.Core.Logging
{
    /// <summary>
    /// 操作日志数据库输出实现
    /// </summary>
    public class DatabaseOperateLogWriter : IOperateLogWriter
    {
        private readonly IRepository<OperateLog, int> _operateLogRepository;

        /// <summary>
        /// 初始化一个<see cref="DatabaseOperateLogWriter"/>类型的新实例
        /// </summary>
        public DatabaseOperateLogWriter(IRepository<OperateLog, int> operateLogRepository)
        {
            _operateLogRepository = operateLogRepository;
        }

        /// <summary>
        /// 输出操作日志
        /// </summary>
        /// <param name="operateLog">操作日志信息</param>
        public void Write(OperateLog operateLog)
        {
            operateLog.CheckNotNull("operateLog");
            _operateLogRepository.Insert(operateLog);
        }
    }
}