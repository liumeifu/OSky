﻿// -----------------------------------------------------------------------
//  <copyright file="IUserClaim.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-06-25 14:04</last-date>
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
    /// 用户摘要标识信息接口
    /// </summary>
    /// <typeparam name="TKey">编号类型</typeparam>
    /// <typeparam name="TUser">用户类型</typeparam>
    /// <typeparam name="TUserKey">用户编号类型</typeparam>
    public interface IUserClaim<TKey, TUser, TUserKey> : IEntity<TKey>
        where TUser : IUser<TUserKey>
    {
        /// <summary>
        /// 获取或设置 摘要类型
        /// </summary>
        string ClaimType { get; set; }

        /// <summary>
        /// 获取或设置 摘要值
        /// </summary>
        string ClaimValue { get; set; }

        /// <summary>
        /// 获取或设置 相关用户
        /// </summary>
        TUser User { get; set; }
    }
}