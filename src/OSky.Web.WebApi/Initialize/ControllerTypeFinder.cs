﻿// -----------------------------------------------------------------------
//  <copyright file="ControllerTypeFinder.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-09-23 22:18</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

using OSky.Core.Reflection;


namespace OSky.Web.Http.Initialize
{
    /// <summary>
    /// WebApi控制器类型查找器
    /// </summary>
    public class ControllerTypeFinder : ITypeFinder
    {
        /// <summary>
        /// 初始化一个<see cref="ControllerTypeFinder"/>类型的新实例
        /// </summary>
        public ControllerTypeFinder()
        {
            AssemblyFinder = new DirectoryAssemblyFinder();
        }

        /// <summary>
        /// 获取或设置 程序集查找器
        /// </summary>
        public IAssemblyFinder AssemblyFinder { get; set; }

        /// <summary>
        /// 查找指定条件的项
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        /// <returns></returns>
        public Type[] Find(Func<Type, bool> predicate)
        {
            return FindAll().Where(predicate).ToArray();
        }

        /// <summary>
        /// 查找所有项
        /// </summary>
        /// <returns></returns>
        public Type[] FindAll()
        {
            Assembly[] assemblies = AssemblyFinder.FindAll();
            return assemblies.SelectMany(assembly => assembly.GetTypes()
                .Where(type => typeof(ApiController).IsAssignableFrom(type) && !type.IsAbstract))
                .Distinct().ToArray();
        }
    }
}