// -----------------------------------------------------------------------
//  <copyright file="ObjectFactory.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-10-06 20:36</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OSky.Core.Dependency
{
    /// <summary>
    /// 对象创建委托
    /// </summary>
    /// <param name="provider">服务提供者</param>
    /// <param name="args">构造函数的参数</param>
    /// <returns></returns>
    public delegate object ObjectFactory(IServiceProvider provider, object[] args);
}