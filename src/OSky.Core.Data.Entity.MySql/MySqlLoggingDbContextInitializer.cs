// -----------------------------------------------------------------------
//  <copyright file="MySqlLoggingDbContextInitializer.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-07-02 16:18</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Data.Entity.Logging;


namespace OSky.Core.Data.Entity
{
    /// <summary>
    /// MySql的log数据库上下文初始化
    /// </summary>
    public class MySqlLoggingDbContextInitializer : DbContextInitializerBase<LoggingDbContext>
    {
        /// <summary>
        /// 初始化一个<see cref="MySqlLoggingDbContextInitializer"/>新实例
        /// </summary>
        public MySqlLoggingDbContextInitializer()
        {
            CreateDatabaseInitializer = MigrateInitializer
                = new MigrateDatabaseToLatestVersion<LoggingDbContext, MySqlMigrationsConfiguration<LoggingDbContext>>();
        }
    }
}