// -----------------------------------------------------------------------
//  <copyright file="EntityUserMapBase.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-08-07 2:17</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Data;
using OSky.Core.Identity.Models;
using OSky.Utility.Extensions;
using OSky.Utility.Filter;


namespace OSky.Core.Security.Models
{
    /// <summary>
    /// 实体用户映射信息基类
    /// </summary>
    public abstract class EntityUserMapBase<TKey, TEntityInfo, TEntityInfoKey, TUser, TUserKey>
        : EntityBase<TKey>, IEntityUserMap<TKey, TEntityInfo, TEntityInfoKey, TUser, TUserKey>
        where TEntityInfo : EntityInfoBase<TEntityInfoKey>
        where TUser : UserBase<TUserKey>
    {
        /// <summary>
        /// 获取或设置 实体信息
        /// </summary>
        public virtual TEntityInfo EntityInfo { get; set; }

        /// <summary>
        /// 获取或设置 用户信息
        /// </summary>
        public virtual TUser User { get; set; }

        /// <summary>
        /// 获取或设置 过滤条件组Json字符串
        /// </summary>
        public string FilterGroupJson { get; set; }

        /// <summary>
        /// 获取 过滤条件组信息
        /// </summary>
        [NotMapped]
        public FilterGroup FilterGroup
        {
            get
            {
                if (FilterGroupJson.IsNullOrEmpty())
                {
                    return null;
                }
                return FilterGroupJson.FromJsonString<FilterGroup>();
            }
        }
    }
}