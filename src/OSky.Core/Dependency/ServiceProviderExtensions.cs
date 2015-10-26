﻿// -----------------------------------------------------------------------
//  <copyright file="ServiceProviderExtensions.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-10-06 21:33</last-date>
// -----------------------------------------------------------------------

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Properties;
using OSky.Utility.Extensions;


namespace OSky.Core.Dependency
{
    /// <summary>
    /// 服务提供者扩展辅助操作
    /// </summary>
    public static class ServiceProviderExtensions
    {
        /// <summary>
        /// 获取指定类型服务的实例
        /// </summary>
        /// <typeparam name="T">要获取实例的服务类型</typeparam>
        /// <param name="provider">服务提供者</param>
        /// <returns>指定类型的实例</returns>
        public static T GetService<T>(this IServiceProvider provider)
        {
            return (T)provider.GetService(typeof(T));
        }

        /// <summary>
        /// 获取指定类型服务的非空实例
        /// </summary>
        /// <param name="provider">服务提供者</param>
        /// <param name="serviceType">要获取实例的服务类型</param>
        /// <returns>指定类型的非空实例</returns>
        public static object GetRequiredService(this IServiceProvider provider, Type serviceType)
        {
            object value =  provider.GetService(serviceType);
            if (value == null)
            {
                throw new InvalidOperationException(Resources.Ioc_ImplementationTypeNotFound.FormatWith(serviceType));
            }
            return value;
        }

        /// <summary>
        /// 获取指定类型服务的非空实例
        /// </summary>
        /// <typeparam name="T">要获取实例的服务类型</typeparam>
        /// <param name="provider">服务提供者</param>
        /// <returns>指定类型的非空实例</returns>
        public static T GetRequiredService<T>(this IServiceProvider provider)
        {
            return (T)GetRequiredService(provider, typeof(T));
        }

        /// <summary>
        /// 获取指定类型服务的所有实例
        /// </summary>
        /// <typeparam name="T">要获取实例的服务类型</typeparam>
        /// <param name="provider">服务提供者</param>
        /// <returns>指定类型的所有实例</returns>
        public static IEnumerable<T> GetServices<T>(this IServiceProvider provider)
        {
            return provider.GetRequiredService<IEnumerable<T>>();
        }

        /// <summary>
        /// 获取指定类型服务的所有实例
        /// </summary>
        /// <param name="provider">服务提供者</param>
        /// <param name="serviceType">要获取实例的服务类型</param>
        /// <returns>指定类型的所有实例</returns>
        public static IEnumerable<object> GetServices(this IServiceProvider provider, Type serviceType)
        {
            Type genericEnumerable = typeof(IEnumerable<>).MakeGenericType(serviceType);
            return (IEnumerable<object>)provider.GetRequiredService(genericEnumerable);
        }
    }
}