// -----------------------------------------------------------------------
//  <copyright file="RoleStoreBase.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-06-24 2:13</last-date>
// -----------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;

using OSky.Core.Data;
using OSky.Core.Dependency;
using OSky.Core.Identity.Models;
using OSky.Utility;


namespace OSky.Core.Identity
{
    /// <summary>
    /// 角色存储基类
    /// </summary>
    /// <typeparam name="TRole">角色类型</typeparam>
    /// <typeparam name="TRoleKey">角色编号类型</typeparam>
    public abstract class RoleStoreBase<TRole, TRoleKey> : IRoleStore<TRole, TRoleKey>, ITransientDependency
        where TRole : RoleBase<TRoleKey>
    {
        private bool _disposed;

        /// <summary>
        /// 获取或设置 角色仓储对象
        /// </summary>
        public IRepository<TRole, TRoleKey> RoleRepository { get; set; }

        #region Implementation of IDisposable

        /// <summary>
        /// 执行与释放或重置非托管资源相关的应用程序定义的任务。
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Implementation of IRoleStore<TRole,in TKey>

        /// <summary>
        /// Create a new role
        /// </summary>
        /// <param name="role"/>
        /// <returns/>
        public virtual async Task CreateAsync(TRole role)
        {
            role.CheckNotNull("role");
            await RoleRepository.InsertAsync(role);
        }

        /// <summary>
        /// Update a role
        /// </summary>
        /// <param name="role"/>
        /// <returns/>
        public virtual async Task UpdateAsync(TRole role)
        {
            role.CheckNotNull("role");
            await RoleRepository.UpdateAsync(role);
        }

        /// <summary>
        /// Delete a role
        /// </summary>
        /// <param name="role"/>
        /// <returns/>
        public virtual async Task DeleteAsync(TRole role)
        {
            role.CheckNotNull("role");
            await RoleRepository.DeleteAsync(role);
        }

        /// <summary>
        /// Find a role by id
        /// </summary>
        /// <param name="roleId"/>
        /// <returns/>
        public virtual async Task<TRole> FindByIdAsync(TRoleKey roleId)
        {
            return await RoleRepository.GetByKeyAsync(roleId);
        }

        /// <summary>
        /// Find a role by name
        /// </summary>
        /// <param name="roleName"/>
        /// <returns/>
        public virtual async Task<TRole> FindByNameAsync(string roleName)
        {
            roleName.CheckNotNull("roleName");
            return (await RoleRepository.GetByPredicateAsync(m => m.Name.Equals(roleName))).FirstOrDefault();
        }

        #endregion

        protected virtual void Dispose(bool disposing)
        {
            _disposed = true;
        }
    }
}