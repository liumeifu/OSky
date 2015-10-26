// -----------------------------------------------------------------------
//  <copyright file="EntityUserMapBaseDto.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-08-07 2:22</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Data;
using OSky.Utility.Filter;


namespace OSky.Core.Security.Dtos
{
    /// <summary>
    /// 实体用户映射基类DTO
    /// </summary>
    public abstract class EntityUserMapBaseDto<TKey, TEntityInfoKey, TUserKey> : IAddDto, IEditDto<TKey>
    {
        /// <summary>
        /// 获取或设置 主键，唯一标识
        /// </summary>
        public TKey Id { get; set; }

        /// <summary>
        /// 获取或设置 实体编号
        /// </summary>
        public TEntityInfoKey EntityInfoId { get; set; }

        /// <summary>
        /// 获取或设置 用户编号
        /// </summary>
        public TUserKey UserId { get; set; }

        /// <summary>
        /// 获取或设置 过滤条件组
        /// </summary>
        public FilterGroup FilterGroup { get; set; }
    }
}