// -----------------------------------------------------------------------
//  <copyright file="FunctionUserMapBase.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-08-03 19:33</last-date>
// -----------------------------------------------------------------------

using System;

using Microsoft.AspNet.Identity;

using OSky.Core.Data;


namespace OSky.Core.Security.Models
{
    /// <summary>
    /// 功能用户映射信息基类
    /// </summary>
    /// <typeparam name="TKey">编号类型</typeparam>
    /// <typeparam name="TFunction">功能类型</typeparam>
    /// <typeparam name="TFunctionKey">功能编号类型</typeparam>
    /// <typeparam name="TUser">用户类型</typeparam>
    /// <typeparam name="TUserKey">用户编号类型</typeparam>
    public abstract class FunctionUserMapBase<TKey, TFunction, TFunctionKey, TUser, TUserKey>
        : EntityBase<TKey>, IFunctionUserMap<TKey, TFunction, TFunctionKey, TUser, TUserKey>
        where TFunction : IFunction, IEntity<TFunctionKey>
        where TUser : IUser<TUserKey>, IEntity<TUserKey>
    {
        /// <summary>
        /// 获取或设置 用户信息Id
        /// </summary>
        public TUserKey UserId { get; set; }
        /// <summary>
        /// 获取或设置 功能信息Id
        /// </summary>
        public TFunctionKey FunctionId { get; set; }
        /// <summary>
        /// 获取或设置 功能信息
        /// </summary>
        public virtual TFunction Function { get; set; }

        /// <summary>
        /// 获取或设置 用户信息
        /// </summary>
        public virtual TUser User { get; set; }

        /// <summary>
        /// 获取或设置 验证类型
        /// </summary>
        public FilterType FilterType { get; set; }
    }
}