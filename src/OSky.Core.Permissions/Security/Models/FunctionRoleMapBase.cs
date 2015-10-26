// -----------------------------------------------------------------------
//  <copyright file="FunctionRoleMapBase.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-08-03 19:06</last-date>
// -----------------------------------------------------------------------

using System;

using Microsoft.AspNet.Identity;

using OSky.Core.Data;
using OSky.Core.Identity.Models;


namespace OSky.Core.Security.Models
{
    /// <summary>
    /// 功能角色映射信息基类
    /// </summary>
    /// <typeparam name="TKey">编号类型</typeparam>
    /// <typeparam name="TFunction">功能类型</typeparam>
    /// <typeparam name="TFunctionKey">功能编号类型</typeparam>
    /// <typeparam name="TRole">角色类型</typeparam>
    /// <typeparam name="TRoleKey">角色编号类型</typeparam>
    public abstract class FunctionRoleMapBase<TKey, TFunction, TFunctionKey, TRole, TRoleKey>
        : EntityBase<TKey>, IFunctionRoleMap<TKey, TFunction, TFunctionKey, TRole, TRoleKey>
        where TFunction : FunctionBase<TFunctionKey>
        where TRole : RoleBase<TRoleKey>
    {
        /// <summary>
        /// 获取或设置 功能信息
        /// </summary>
        public virtual TFunction Function { get; set; }

        /// <summary>
        /// 获取或设置 角色信息
        /// </summary>
        public virtual TRole Role { get; set; }

        /// <summary>
        /// 获取或设置 限制类型
        /// </summary>
        public FilterType FilterType { get; set; }
    }
}