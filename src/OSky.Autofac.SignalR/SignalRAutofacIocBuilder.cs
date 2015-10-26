// -----------------------------------------------------------------------
//  <copyright file="SignalRAutofacIocBuilder.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-10-10 15:31</last-date>
// -----------------------------------------------------------------------

using System;
using System.Reflection;

using Autofac;
using Autofac.Integration.SignalR;

using Microsoft.AspNet.SignalR;

using OSky.Core.Dependency;
using OSky.Core.Security;
using OSky.Web.SignalR.Initialize;


namespace OSky.Autofac.SignalR
{
    /// <summary>
    /// SignalR-Autofac依赖注入初始化类
    /// </summary>
    public class SignalRAutofacIocBuilder : IocBuilderBase
    {
        /// <summary>
        /// 添加自定义服务映射
        /// </summary>
        /// <param name="services">服务信息集合</param>
        protected override void AddCustomTypes(IServiceCollection services)
        {
            services.AddInstance(this);
            services.AddSingleton<IIocResolver, SignalRIocResolver>();
            services.AddSingleton<IFunctionHandler, SignalRFunctionHandler>();
        }

        /// <summary>
        /// 构建服务并设置SignalR平台的Resolver
        /// </summary>
        /// <param name="services">服务映射信息集合</param>
        /// <param name="assemblies">要检索的程序集集合</param>
        protected override IServiceProvider BuildAndSetResolver(IServiceCollection services, Assembly[] assemblies)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterHubs().AsSelf().PropertiesAutowired();
            builder.Populate(services);
            IContainer container = builder.Build();
            IDependencyResolver resolver = new AutofacDependencyResolver(container);
            GlobalHost.DependencyResolver = resolver;
            return resolver.Resolve<IServiceProvider>();
        }
    }
}