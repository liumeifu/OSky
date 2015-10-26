// -----------------------------------------------------------------------
//  <copyright file="RoleLimitAuthentication.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-08-03 20:23</last-date>
// -----------------------------------------------------------------------

using System;
using System.Security.Claims;

using Microsoft.AspNet.Identity;

using OSky.Core.Data;
using OSky.Core.Security.Models;
using OSky.Utility.Extensions;


namespace OSky.Core.Security
{
    /// <summary>
    /// 特定角色类型的功能权限检查
    /// </summary>
    /// <typeparam name="TFunction">功能类型</typeparam>
    /// <typeparam name="TFunctionKey">功能编号类型</typeparam>
    /// <typeparam name="TFunctionRoleMap">功能角色映射类型</typeparam>
    /// <typeparam name="TFunctionRoleMapKey">功能角色映射编号类型</typeparam>
    /// <typeparam name="TFunctionUserMap">功能用户映射类型</typeparam>
    /// <typeparam name="TFunctionUserMapKey">功能用户编号类型</typeparam>
    /// <typeparam name="TRole">角色类型</typeparam>
    /// <typeparam name="TRoleKey">角色编号类型</typeparam>
    /// <typeparam name="TUser">用户类型</typeparam>
    /// <typeparam name="TUserKey">用户编号类型</typeparam>
    public class RoleLimitAuthentication<TFunction, TFunctionKey, TFunctionRoleMap, TFunctionRoleMapKey, TFunctionUserMap, TFunctionUserMapKey, TRole,
        TRoleKey, TUser, TUserKey> : IRoleLimitAuthentication<TFunction, TFunctionKey>
        where TFunction : FunctionBase<TFunctionKey>
        where TFunctionRoleMap : IFunctionRoleMap<TFunctionRoleMapKey, TFunction, TFunctionKey, TRole, TRoleKey>
        where TFunctionUserMap : IFunctionUserMap<TFunctionUserMapKey, TFunction, TFunctionKey, TUser, TUserKey>
        where TRole : IRole<TRoleKey>, IEntity<TRoleKey>
        where TUser : IUser<TUserKey>, IEntity<TUserKey>
    {
        /// <summary>
        /// 执行功能权限验证
        /// </summary>
        /// <param name="user">在线用户信息</param>
        /// <param name="function">功能信息</param>
        /// <returns>权限验证结果</returns>
        public AuthenticationResult Authenticate(ClaimsPrincipal user, TFunction function)
        {
            if (function.FunctionType != FunctionType.RoleLimit)
            {
                return new AuthenticationResult(AuthenticationResultType.Error, "功能“{0}”不是角色限制类型".FormatWith(function.Name));
            }
            if (!user.Identity.IsAuthenticated)
            {
                return new AuthenticationResult(AuthenticationResultType.LoggedOut, "当前用户未登录或登录已失效");
            }
            throw new NotImplementedException("特定角色的功能权限验证逻辑尚未实现");
        }
    }
}