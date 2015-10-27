// -----------------------------------------------------------------------
//  <copyright file="AbstractBuilder.cs" company="">
//      Copyright (c) 2014 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2014:07:04 18:11</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace OSky.Utility.Exceptions
{
    /// <summary>
    /// OSky框架异常类
    /// </summary>
    [Serializable]
    public class OSkyException : Exception
    {
        /// <summary>
        /// 初始化<see cref="OSkyException"/>类的新实例
        /// </summary>
        public OSkyException()
        { }

        /// <summary>
        /// 使用指定错误消息初始化<see cref="OSkyException"/>类的新实例。
        /// </summary>
        /// <param name="message">描述错误的消息</param>
        public OSkyException(string message)
            : base(message)
        { }

        /// <summary>
        /// 使用异常消息与一个内部异常实例化一个<see cref="OSkyException"/>类的新实例
        /// </summary>
        /// <param name="message">异常消息</param>
        /// <param name="inner">用于封装在<see cref="OSkyException"/>内部的异常实例</param>
        public OSkyException(string message, Exception inner)
            : base(message, inner)
        { }

        /// <summary>
        /// 使用可序列化数据实例化一个<see cref="OSkyException"/>类的新实例
        /// </summary>
        /// <param name="info">保存序列化对象数据的对象。</param>
        /// <param name="context">有关源或目标的上下文信息。</param>
        protected OSkyException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}