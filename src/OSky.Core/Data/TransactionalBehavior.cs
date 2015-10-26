﻿// -----------------------------------------------------------------------
//  <copyright file="TransactionalBehavior.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-03-18 14:13</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OSky.Core.Data
{
    /// <summary>
    /// 在执行数据库命令或查询期间控制事务创建行为。
    /// </summary>
    public enum TransactionalBehavior
    {
        /// <summary>
        /// 如果存在现有事务，则使用它，否则在没有事务的情况下执行命令或查询。
        /// </summary>
        DoNotEnsureTransaction,

        /// <summary>
        /// 如果不存在任何事务，则使用新事务进行操作。
        /// </summary>
        EnsureTransaction
    }
}