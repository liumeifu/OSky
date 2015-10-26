﻿// -----------------------------------------------------------------------
//  <copyright file="LocalAutofacIocBuilder.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-10-10 15:32</last-date>
// -----------------------------------------------------------------------

using System;
using System.Reflection;

using Autofac;

using OSky.Autofac;
using OSky.Core.Dependency;
using OSky.Core.Security;


namespace OSky.App.Local.Initialize
{
    /// <summary>
    /// 本地程序-Autofac依赖注入初始化
    /// </summary>
    public class LocalAutofacIocBuilder : IocBuilderBase
    {
        /// <summary>
        /// 获取 依赖注入解析器
        /// </summary>
        public IIocResolver Resolver { get; private set; }

        /// <summary>
        /// 添加自定义服务映射
        /// </summary>
        /// <param name="services">服务信息集合</param>
        protected override void AddCustomTypes(IServiceCollection services)
        {
            services.AddInstance(this);
            services.AddSingleton<IIocResolver, LocalIocResolver>();
            services.AddSingleton<IFunctionHandler, NullFunctionHandler>();
        }

        /// <summary>
        /// 构建服务并设置本地程序平台的Resolver
        /// </summary>
        /// <param name="services">服务映射信息集合</param>
        /// <param name="assemblies">要检索的程序集集合</param>
        /// <returns>服务提供者</returns>
        protected override IServiceProvider BuildAndSetResolver(IServiceCollection services, Assembly[] assemblies)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.Populate(services);
            IContainer container = builder.Build();
            LocalIocResolver.Container = container;
            Resolver = container.Resolve<IIocResolver>();
            return Resolver.Resolve<IServiceProvider>();
        }
    }
}