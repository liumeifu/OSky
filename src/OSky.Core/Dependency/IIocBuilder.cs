// -----------------------------------------------------------------------
//  <copyright file="IIocBuilder.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-10-10 15:26</last-date>
// -----------------------------------------------------------------------

using System;


namespace OSky.Core.Dependency
{
    /// <summary>
    /// 定义依赖注入构建器，解析依赖注入服务映射信息进行构建
    /// </summary>
    public interface IIocBuilder
    {
        /// <summary>
        /// 开始构建依赖注入映射
        /// </summary>
        /// <param name="services">服务信息集合</param>
        /// <returns>服务提供者</returns>
        IServiceProvider Build(IServiceCollection services);
    }
}