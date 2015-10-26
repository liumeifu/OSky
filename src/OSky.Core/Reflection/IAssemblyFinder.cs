// -----------------------------------------------------------------------
//  <copyright file="IAssemblyFinder.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-07-28 11:31</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace OSky.Core.Reflection
{
    /// <summary>
    /// 定义程序集查找器
    /// </summary>
    public interface IAssemblyFinder : IFinder<Assembly>
    { }
}