// -----------------------------------------------------------------------
//  <copyright file="ITypeFinder.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-07-28 11:30</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OSky.Core.Reflection
{
    /// <summary>
    /// 定义类型查找行为
    /// </summary>
    public interface ITypeFinder : IFinder<Type>
    { }
}