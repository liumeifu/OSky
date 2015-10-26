// -----------------------------------------------------------------------
//  <copyright file="IFunctionRoleMap.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-08-04 13:38</last-date>
// -----------------------------------------------------------------------

using System;

using Microsoft.AspNet.Identity;

using OSky.Core.Data;


namespace OSky.Core.Security.Models
{
    /// <summary>
    /// 定义功能角色映射信息
    /// </summary>
    /// <typeparam name="TKey">映射编号类型</typeparam>
    /// <typeparam name="TFunction">功能类型</typeparam>
    /// <typeparam name="TFunctionKey">功能编号类型</typeparam>
    /// <typeparam name="TRole">角色类型</typeparam>
    /// <typeparam name="TRoleKey">角色编号类型</typeparam>
    public interface IFunctionRoleMap<TKey, TFunction, TFunctionKey, TRole, TRoleKey> : IEntity<TKey>
        where TFunction : IFunction, IEntity<TFunctionKey>
        where TRole : IRole<TRoleKey>, IEntity<TRoleKey>
    {
        /// <summary>
        /// 获取或设置 功能信息
        /// </summary>
        TFunction Function { get; set; }

        /// <summary>
        /// 获取或设置 角色信息
        /// </summary>
        TRole Role { get; set; }

        /// <summary>
        /// 获取或设置 验证类型
        /// </summary>
        FilterType FilterType { get; set; }
    }
}