// -----------------------------------------------------------------------
//  <copyright file="IocServiceProvider.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-10-09 15:57</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OSky.Core.Dependency
{
    /// <summary>
    /// 默认IoC服务提供者实现
    /// </summary>
    public class IocServiceProvider : IServiceProvider
    {
        private readonly IIocResolver _resolver;

        /// <summary>
        /// 初始化一个<see cref="IocServiceProvider"/>类型的新实例
        /// </summary>
        public IocServiceProvider(IIocResolver resolver)
        {
            _resolver = resolver;
        }

        /// <summary>
        /// 获取指定类型的服务对象。
        /// </summary>
        /// <returns>
        /// <paramref name="serviceType"/> 类型的服务对象。 - 或 - 如果没有 <paramref name="serviceType"/> 类型的服务对象，则为 null。
        /// </returns>
        /// <param name="serviceType">一个对象，它指定要获取的服务对象的类型。</param><filterpriority>2</filterpriority>
        public object GetService(Type serviceType)
        {
            return _resolver.Resolve(serviceType);
        }
    }
}