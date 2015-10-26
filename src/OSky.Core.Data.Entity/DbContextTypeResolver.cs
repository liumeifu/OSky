// -----------------------------------------------------------------------
//  <copyright file="DbContextTypeResolver.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-08-02 15:53</last-date>
// -----------------------------------------------------------------------

using System;

using OSky.Core.Data.Entity.Properties;
using OSky.Core.Dependency;
using OSky.Utility;
using OSky.Utility.Extensions;


namespace OSky.Core.Data.Entity
{
    /// <summary>
    /// 数据上下文类型获取器
    /// </summary>
    public class DbContextTypeResolver : IDbContextTypeResolver
    {
        private readonly IIocResolver _resolver;

        /// <summary>
        /// 初始化一个<see cref="DbContextTypeResolver"/>类型的新实例
        /// </summary>
        public DbContextTypeResolver(IIocResolver resolver)
        {
            _resolver = resolver;
        }
        
        /// <summary>
        /// 由实体类型获取关联的上下文类型
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">实体主键类型</typeparam>
        /// <returns></returns>
        public IUnitOfWork Resolve<TEntity, TKey>() where TEntity : IEntity<TKey>
        {
            return Resolve(typeof(TEntity));
        }

        /// <summary>
        /// 由实体类型获取关联的上下文类型
        /// </summary>
        /// <param name="entityType">实体类型</param>
        /// <returns></returns>
        public IUnitOfWork Resolve(Type entityType)
        {
            entityType.CheckNotNull("entityType" );
            Type contextType = DbContextManager.Instance.GetDbContexType(entityType);
            IUnitOfWork unitOfWork = (IUnitOfWork)_resolver.Resolve(contextType);
            if (unitOfWork == null)
            {
                throw new InvalidOperationException(Resources.DbContextTypeResolver_DbContextResolveFailed.FormatWith(entityType, contextType));
            }
            return unitOfWork;
        }
    }
}