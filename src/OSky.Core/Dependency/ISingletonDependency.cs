﻿// -----------------------------------------------------------------------
//  <copyright file="ISingletonDependency.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-07-29 18:21</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OSky.Core.Dependency
{
    /// <summary>
    /// 实现此接口的类型将被注册为<see cref="LifetimeStyle.Singleton"/>模式
    /// </summary>
    public interface ISingletonDependency : IDependency
    { }
}