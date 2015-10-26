// -----------------------------------------------------------------------
//  <copyright file="AuthenticationResultType.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-08-03 18:16</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OSky.Core.Security
{
    /// <summary>
    /// 表示权限验证结果的枚举
    /// </summary>
    public enum AuthenticationResultType
    {
        /// <summary>
        /// 权限检查通过
        /// </summary>
        [Description("权限检查通过。")] Allowed,

        /// <summary>
        /// 该操作需要登录后才能继续进行
        /// </summary>
        [Description("该操作需要登录后才能继续进行。")] LoggedOut,

        /// <summary>
        /// 权限不足
        /// </summary>
        [Description("当前用户权限不足，不能继续操作。")] PurviewLack,

        /// <summary>
        /// 功能锁定
        /// </summary>
        [Description("当前功能已经被锁定，不能继续操作。")] FunctionLocked,

        /// <summary>
        /// 功能不存在
        /// </summary>
        [Description("指定功能不存在。")] FunctionNotFound,

        /// <summary>
        /// 出现错误
        /// </summary>
        [Description("权限检查出现错误")]
        Error
    }
}