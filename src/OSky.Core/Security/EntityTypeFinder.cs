﻿// -----------------------------------------------------------------------
//  <copyright file="EntityTypeFinder.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-07-29 14:59</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Data;
using OSky.Core.Reflection;
using OSky.Utility.Extensions;


namespace OSky.SiteBase.Security
{
    /// <summary>
    /// 实体类型查找器
    /// </summary>
    public class EntityTypeFinder : ITypeFinder
    {
        /// <summary>
        /// 初始化一个<see cref="EntityTypeFinder"/>类型的新实例
        /// </summary>
        public EntityTypeFinder()
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
            return assemblies.SelectMany(assembly =>
                assembly.GetTypes().Where(type =>
                    typeof(IEntity<>).IsGenericAssignableFrom(type) && !type.IsAbstract))
                .Distinct().ToArray();
        }
    }
}