// -----------------------------------------------------------------------
//  <copyright file="DatabaseLoggerAdapter.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-09-23 9:08</last-date>
// -----------------------------------------------------------------------

using OSky.Core.Dependency;
using OSky.Utility.Logging;


namespace OSky.Core.Logging
{
    /// <summary>
    /// 数据库日志适配器
    /// </summary>
    public class DatabaseLoggerAdapter : LoggerAdapterBase, IScopeDependency
    {
        /// <summary>
        /// 获取或设置 依赖注入解析器
        /// </summary>
        public IIocResolver IocResolver { get; set; }

        /// <summary>
        /// 获取指定名称的Logger实例
        /// </summary>
        /// <param name="name">指定名称</param>
        /// <returns>日志实例</returns>
        /// <exception cref="System.NotSupportedException">指定名称的日志缓存实例不存在则返回异常<see cref="System.NotSupportedException"/></exception>
        protected override ILog GetLoggerInternal(string name)
        {
            ILog log = CreateLogger(name);
            //System.Diagnostics.Debug.WriteLine(log.GetHashCode());
            return log;
        }

        /// <summary>
        /// 创建指定名称的缓存实例
        /// </summary>
        /// <param name="name">指定名称</param>
        /// <returns></returns>
        protected override ILog CreateLogger(string name)
        {
            return IocResolver.Resolve<DatabaseLog>();
        }
    }
}