// -----------------------------------------------------------------------
//  <copyright file="AjaxResultType.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-03-05 9:24</last-date>
// -----------------------------------------------------------------------

namespace OSky.Web.Mvc.UI
{
    /// <summary>
    /// 表示 ajax 操作结果类型的枚举
    /// </summary>
    public enum AjaxResultType
    {
        /// <summary>
        /// 消息结果类型
        /// </summary>
        Info,

        /// <summary>
        /// 成功结果类型
        /// </summary>
        Success,

        /// <summary>
        /// 警告结果类型
        /// </summary>
        Warning,

        /// <summary>
        /// 异常结果类型
        /// </summary>
        Error
    }
}