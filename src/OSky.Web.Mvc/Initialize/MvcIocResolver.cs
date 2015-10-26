// -----------------------------------------------------------------------
//  <copyright file="MvcIocResolver.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-10-06 15:27</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Web.Mvc;

using OSky.Core.Dependency;


namespace OSky.Web.Mvc.Initialize
{
    /// <summary>
    /// MVC依赖注入对象解析器
    /// </summary>
    public class MvcIocResolver : IIocResolver
    {
        /// <summary>
        /// 获取指定类型的实例
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <returns></returns>
        public T Resolve<T>()
        {
            return DependencyResolver.Current.GetService<T>();
        }

        /// <summary>
        /// 获取指定类型的实例
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public object Resolve(Type type)
        {
            return DependencyResolver.Current.GetService(type);
        }

        /// <summary>
        /// 获取指定类型的所有实例
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <returns></returns>
        public IEnumerable<T> Resolves<T>()
        {
            return DependencyResolver.Current.GetServices<T>();
        }

        /// <summary>
        /// 获取指定类型的所有实例
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public IEnumerable<object> Resolves(Type type)
        {
            return DependencyResolver.Current.GetServices(type);
        }
    }
}