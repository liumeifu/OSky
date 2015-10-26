// -----------------------------------------------------------------------
//  <copyright file="IOSharpResult.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-08-03 18:20</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OSky.Utility.Data
{
    /// <summary>
    /// OSky操作结果
    /// </summary>
    /// <typeparam name="TResultType"></typeparam>
    public interface IOSharpResult<TResultType> : IOSharpResult<TResultType, object>
    { }


    /// <summary>
    /// OSky操作结果
    /// </summary>
    public interface IOSharpResult<TResultType, TData>
    {
        /// <summary>
        /// 获取或设置 结果类型
        /// </summary>
        TResultType ResultType { get; set; }

        /// <summary>
        /// 获取或设置 返回消息
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// 获取或设置 结果数据
        /// </summary>
        TData Data { get; set; }
    }
}