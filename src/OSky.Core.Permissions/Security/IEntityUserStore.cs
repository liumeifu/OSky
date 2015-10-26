// -----------------------------------------------------------------------
//  <copyright file="IEntityUserStore.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-08-07 2:50</last-date>
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
    /// 定义数据用户映射存储
    /// </summary>
    public interface IEntityUserStore<in TEntityUserMapDto, in TKey, in TEntityInfoKey, in TUserKey>
        where TEntityUserMapDto : EntityUserMapBaseDto<TKey, TEntityInfoKey, TUserKey>
    {
        /// <summary>
        /// 增加数据用户映射信息
        /// </summary>
        /// <param name="dto">数据用户映射信息DTO</param>
        /// <returns>业务操作结果</returns>
        Task<OperationResult> AddEntityUserMapAsync(TEntityUserMapDto dto);

        /// <summary>
        /// 编辑数据用户映射信息
        /// </summary>
        /// <param name="dto">数据用户映射信息DTO</param>
        /// <returns>业务操作结果</returns>
        Task<OperationResult> EditEntityUserMapAsync(TEntityUserMapDto dto);

        /// <summary>
        /// 删除数据用户映射信息
        /// </summary>
        /// <param name="id">数据用户映射编号</param>
        /// <returns>业务操作结果</returns>
        Task<OperationResult> DeleteEntityUserMapAsync(TKey id);

        /// <summary>
        /// 查找指定数据与用户的查询条件组
        /// </summary>
        /// <param name="entityInfoId">数据实体编号</param>
        /// <param name="roleId">用户编号</param>
        /// <returns>过滤条件组</returns>
        Task<FilterGroup> GetUserFilterGroup(TEntityInfoKey entityInfoId, TUserKey roleId);
    }
}