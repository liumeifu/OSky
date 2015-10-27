// -----------------------------------------------------------------------
//  <copyright file="OSkyResult.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-08-03 18:29</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OSky.Utility.Data
{
    /// <summary>
    /// OSky结果基类
    /// </summary>
    /// <typeparam name="TResultType"></typeparam>
    public abstract class OSkyResult<TResultType> : OSkyResult<TResultType, object>, IOSkyResult<TResultType>
    {
        /// <summary>
        /// 初始化一个<see cref="OSkyResult{TResultType}"/>类型的新实例
        /// </summary>
        protected OSkyResult()
            : this(default(TResultType))
        { }

        /// <summary>
        /// 初始化一个<see cref="OSkyResult{TResultType}"/>类型的新实例
        /// </summary>
        protected OSkyResult(TResultType type)
            : this(type, null, null)
        { }

        /// <summary>
        /// 初始化一个<see cref="OSkyResult{TResultType}"/>类型的新实例
        /// </summary>
        protected OSkyResult(TResultType type, string message)
            : this(type, message, null)
        { }

        /// <summary>
        /// 初始化一个<see cref="OSkyResult{TResultType}"/>类型的新实例
        /// </summary>
        protected OSkyResult(TResultType type, string message, object data)
            : base(type, message, data)
        { }
    }


    /// <summary>
    /// OSky结果基类
    /// </summary>
    /// <typeparam name="TResultType">结果类型</typeparam>
    /// <typeparam name="TData">结果数据类型</typeparam>
    public abstract class OSkyResult<TResultType, TData> : IOSkyResult<TResultType, TData>
    {
        /// <summary>
        /// 初始化一个<see cref="OSkyResult{TResultType,TData}"/>类型的新实例
        /// </summary>
        protected OSkyResult()
            : this(default(TResultType))
        { }

        /// <summary>
        /// 初始化一个<see cref="OSkyResult{TResultType,TData}"/>类型的新实例
        /// </summary>
        protected OSkyResult(TResultType type)
            : this(type, null, default(TData))
        { }

        /// <summary>
        /// 初始化一个<see cref="OSkyResult{TResultType,TData}"/>类型的新实例
        /// </summary>
        protected OSkyResult(TResultType type, string message)
            : this(type, message, default(TData))
        { }

        /// <summary>
        /// 初始化一个<see cref="OSkyResult{TResultType,TData}"/>类型的新实例
        /// </summary>
        protected OSkyResult(TResultType type, string message, TData data)
        {
            ResultType = type;
            Message = message;
            Data = data;
        }

        /// <summary>
        /// 获取或设置 结果类型
        /// </summary>
        public TResultType ResultType { get; set; }

        /// <summary>
        /// 获取或设置 返回消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 获取或设置 结果数据
        /// </summary>
        public TData Data { get; set; }
    }
}