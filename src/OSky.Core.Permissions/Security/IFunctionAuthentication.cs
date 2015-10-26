// -----------------------------------------------------------------------
//  <copyright file="IFunctionAuthentication.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-08-03 13:55</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Dependency;
using OSky.Utility.Data;


namespace OSky.Core.Security
{
    /// <summary>
    /// 定义功能权限验证器
    /// </summary>
    /// <typeparam name="TFunction">功能类型</typeparam>
    public interface IFunctionAuthentication<in TFunction> : ISingletonDependency
    {
        /// <summary>
        /// 验证当前用户是否有执行指定功能的权限
        /// </summary>
        /// <param name="function"></param>
        /// <returns></returns>
        AuthenticationResult Authenticate(TFunction function);
    }
}