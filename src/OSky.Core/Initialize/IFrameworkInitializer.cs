// -----------------------------------------------------------------------
//  <copyright file="IFrameworkInitializer.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-10-10 14:44</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Dependency;


namespace OSky.Core
{
    /// <summary>
    /// 框架初始化接口
    /// </summary>
    public interface IFrameworkInitializer
    {
        /// <summary>
        /// 开始执行框架初始化
        /// </summary>
        /// <param name="services">服务映射集合</param>
        /// <param name="iocBuilder">依赖注入构建器</param>
        void Initialize(IServiceCollection services, IIocBuilder iocBuilder);
    }
}