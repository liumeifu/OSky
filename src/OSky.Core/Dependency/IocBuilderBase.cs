﻿// -----------------------------------------------------------------------
//  <copyright file="IocBuilderBase.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-10-10 15:28</last-date>
// -----------------------------------------------------------------------

using System;
using System.Reflection;

using OSky.Core.Reflection;


namespace OSky.Core.Dependency
{
    /// <summary>
    /// 依赖注入构建器基类，从程序集中反射进行依赖注入接口与实现的注册
    /// </summary>
    public abstract class IocBuilderBase : IIocBuilder
    {
        /// <summary>
        /// 初始化一个<see cref="IocBuilderBase"/>类型的新实例
        /// </summary>
        protected IocBuilderBase()
        {
            AssemblyFinder = new DirectoryAssemblyFinder();
        }

        /// <summary>
        /// 获取或设置 程序集查找器
        /// </summary>
        public IAssemblyFinder AssemblyFinder { get; set; }

        /// <summary>
        /// 开始构建依赖注入映射
        /// </summary>
        /// <param name="services">服务信息集合</param>
        /// <returns>服务提供者</returns>
        public IServiceProvider Build(IServiceCollection services)
        {
            //设置各个框架的DependencyResolver
            Assembly[] assemblies = AssemblyFinder.FindAll();

            AddCustomTypes(services);

            return BuildAndSetResolver(services, assemblies);
        }

        /// <summary>
        /// 添加自定义服务映射
        /// </summary>
        /// <param name="services">服务信息集合</param>
        protected virtual void AddCustomTypes(IServiceCollection services)
        { }

        /// <summary>
        /// 重写以实现构建服务并设置各个平台的Resolver
        /// </summary>
        /// <param name="services">服务映射信息集合</param>
        /// <param name="assemblies">要检索的程序集集合</param>
        /// <returns>服务提供者</returns>
        protected abstract IServiceProvider BuildAndSetResolver(IServiceCollection services, Assembly[] assemblies);
    }
}