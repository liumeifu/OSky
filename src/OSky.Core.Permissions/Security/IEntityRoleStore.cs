// -----------------------------------------------------------------------
//  <copyright file="IEntityRoleStore.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-08-07 2:34</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Security.Dtos;
using OSky.Utility.Data;
using OSky.Utility.Filter;


namespace OSky.Core.Security
{
    /// <summary>
    /// 定义数据角色映射存储
    /// </summary>
    public interface IEntityRoleStore<in TEntityRoleMapDto, in TKey, in TEntityInfoKey, in TRoleKey>
        where TEntityRoleMapDto : EntityRoleMapBaseDto<TKey, TEntityInfoKey, TRoleKey>
    {
        /// <summary>
        /// 增加数据角色映射信息
        /// </summary>
        /// <param name="dto">数据角色映射信息DTO</param>
        /// <returns>业务操作结果</returns>
        Task<OperationResult> AddEntityRoleMapAsync(TEntityRoleMapDto dto);

        /// <summary>
        /// 编辑数据角色映射信息
        /// </summary>
        /// <param name="dto">数据角色映射信息DTO</param>
        /// <returns>业务操作结果</returns>
        Task<OperationResult> EditEntityRoleMapAsync(TEntityRoleMapDto dto);

        /// <summary>
        /// 删除数据角色映射信息
        /// </summary>
        /// <param name="id">数据角色映射编号</param>
        /// <returns>业务操作结果</returns>
        Task<OperationResult> DeleteEntityRoleMapAsync(TKey id);

        /// <summary>
        /// 查找指定数据与角色的查询条件组
        /// </summary>
        /// <param name="entityInfoId">数据实体编号</param>
        /// <param name="roleId">角色编号</param>
        /// <returns>过滤条件组</returns>
        Task<FilterGroup> GetRoleFilterGroup(TEntityInfoKey entityInfoId, TRoleKey roleId);
    }
}