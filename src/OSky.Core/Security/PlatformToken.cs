// -----------------------------------------------------------------------
//  <copyright file="PlatformToken.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-09-25 11:54</last-date>
// -----------------------------------------------------------------------

namespace OSky.Core.Security
{
    /// <summary>
    /// 技术平台标识
    /// </summary>
    public enum PlatformToken
    {
        /// <summary>
        /// 标识当前平台为ASP.NET MVC
        /// </summary>
        Mvc,

        /// <summary>
        /// 标识当前平台为ASP.NET WebAPI
        /// </summary>
        WebApi,

        /// <summary>
        /// 标识当前平台为ASP.NET SignalR
        /// </summary>
        SignalR,

        /// <summary>
        /// 标识当前平台为本地程序
        /// </summary>
        Local
    }
}