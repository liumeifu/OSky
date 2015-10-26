// -----------------------------------------------------------------------
//  <copyright file="AuthenticationResult.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-08-03 18:39</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using OSky.Utility.Data;


namespace OSky.Core.Security
{
    /// <summary>
    /// 权限检查结果
    /// </summary>
    public class AuthenticationResult : OSharpResult<AuthenticationResultType>
    {
        static AuthenticationResult()
        {
            Allowed = new AuthenticationResult();
        }

        /// <summary>
        /// 初始化一个<see cref="AuthenticationResult"/>类型的新实例
        /// </summary>
        public AuthenticationResult()
            : this(AuthenticationResultType.Allowed)
        { }

        /// <summary>
        /// 初始化一个<see cref="AuthenticationResult"/>类型的新实例
        /// </summary>
        public AuthenticationResult(AuthenticationResultType type)
            : this(type, null)
        { }

        /// <summary>
        /// 初始化一个<see cref="AuthenticationResult"/>类型的新实例
        /// </summary>
        public AuthenticationResult(AuthenticationResultType type, string message)
            : base(type, message, null)
        { }

        /// <summary>
        /// 获取或设置 允许的检查结果
        /// </summary>
        public static AuthenticationResult Allowed { get; set; }
    }
}