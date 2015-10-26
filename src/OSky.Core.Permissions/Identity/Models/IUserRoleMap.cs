﻿// -----------------------------------------------------------------------
//  <copyright file="IUserRoleMap.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-09-13 17:25</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;

using OSky.Core.Data;


namespace OSky.Core.Identity.Models
{
    /// <summary>
    /// 用户角色映射信息接口
    /// </summary>
    /// <typeparam name="TKey">编号类型</typeparam>
    /// <typeparam name="TUser">用户类型</typeparam>
    /// <typeparam name="TUserKey">用户编号类型</typeparam>
    /// <typeparam name="TRole">角色类型</typeparam>
    /// <typeparam name="TRoleKey">角色编号类型</typeparam>
    public interface IUserRoleMap<TKey, TUser, TUserKey, TRole, TRoleKey> : IEntity<TKey>
        where TUser : IUser<TUserKey>
        where TRole : IRole<TRoleKey>
    {
        /// <summary>
        /// 获取或设置 生效时间
        /// </summary>
        DateTime BeginTime { get; set; }

        /// <summary>
        /// 获取或设置 过期时间
        /// </summary>
        DateTime? EndTime { get; set; }

        /// <summary>
        /// 获取或设置 用户信息
        /// </summary>
        TUser User { get; set; }

        /// <summary>
        /// 获取或设置 角色信息
        /// </summary>
        TRole Role { get; set; }
    }
}