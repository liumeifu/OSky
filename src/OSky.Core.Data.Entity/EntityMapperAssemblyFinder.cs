// -----------------------------------------------------------------------
//  <copyright file="EntityMapperAssemblyFinder.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-09-23 10:00</last-date>
// -----------------------------------------------------------------------

using System;
using System.Linq;
using System.Reflection;

using OSky.Core.Reflection;


namespace OSky.Core.Data.Entity
{
    /// <summary>
    /// 实体映射程序集查找器
    /// </summary>
    public class EntityMapperAssemblyFinder : IEntityMapperAssemblyFinder
    {
        /// <summary>
        /// 初始化一个<see cref="EntityMapperAssemblyFinder"/>类型的新实例
        /// </summary>
        public EntityMapperAssemblyFinder()
        {
            AllAssemblyFinder = new DirectoryAssemblyFinder();
        }

        /// <summary>
        /// 获取或设置 所有程序集查找器
        /// </summary>
        public IAllAssemblyFinder AllAssemblyFinder { get; set; }

        /// <summary>
        /// 查找指定条件的项
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        /// <returns></returns>
        public Assembly[] Find(Func<Assembly, bool> predicate)
        {
            return FindAll().Where(predicate).ToArray();
        }

        /// <summary>
        /// 查找所有项
        /// </summary>
        /// <returns></returns>
        public Assembly[] FindAll()
        {
            Type baseType = typeof(IEntityMapper);
            Assembly[] assemblies = AllAssemblyFinder.Find(assembly =>
                assembly.GetTypes().Any(type => baseType.IsAssignableFrom(type) && !type.IsAbstract));
            return assemblies;
        }
    }
}