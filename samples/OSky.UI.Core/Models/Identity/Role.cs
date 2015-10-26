// -----------------------------------------------------------------------
//  <copyright file="Role.cs" company="">
//      Copyright (c) 2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-01-08 0:24</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;

using OSky.Core.Identity.Models;


namespace OSky.UI.Models.Identity
{
    /// <summary>
    /// 实体类——角色信息
    /// </summary>
    [Description("认证-角色信息")]
    public class Role : RoleBase<int>
    {
        /// <summary>
        /// 获取或设置 是否锁定
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        /// 获取或设置 角色所属组织机构
        /// </summary>
        public virtual Organization Organization { get; set; }
    }
}