// -----------------------------------------------------------------------
//  <copyright file="ClaimsIdentityExtensions.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-06-21 15:18</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace OSky.Core.Exceptions
{
    /// <summary>
    /// <see cref="ClaimsIdentity"/>扩展操作类
    /// </summary>
    public static class ClaimsIdentityExtensions
    {
        /// <summary>
        /// 获取指定类型的Claim值
        /// </summary>
        public static string GetClaimValue(this ClaimsIdentity identity, string type)
        {
            Claim claim = identity.Claims.FirstOrDefault(m => m.Type == type);
            return claim == null ? null : claim.Value;
        }

        /// <summary>
        /// 获取指定类型的Claim值的集合
        /// </summary>
        public static IEnumerable<string> GetClaimValues(this ClaimsIdentity identity, string type)
        {
            IEnumerable<string> claim = identity.Claims.Where(m => m.Type == type).Select(m => m.Value).ToList();
            return claim;
        }

        /// <summary>
        /// 基于Claims-based的认证 
        /// </summary>
        /// <param name="identity">identity</param>
        /// <param name="id">登录Id</param>
        /// <param name="name">登录名</param>
        /// <param name="roles">角色集合</param>
        /// <returns></returns>
        public static ClaimsIdentity SetClaimsIdentity(this ClaimsIdentity identity,string id, string name, string[] roles)
        {
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, id));
            identity.AddClaim(new Claim(ClaimTypes.Name, name));
            if (roles != null)
                foreach (var item in roles)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Role, item));
                    }
                }
            identity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2015/11/claims/identityprovider", "ASP.NET Identity"));
           
            return identity;
        }

    }
}