// -----------------------------------------------------------------------
//  <copyright file="Member.cs" company="">
//      Copyright (c) 2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-01-07 23:33</last-date>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using OSky.Core.Identity.Models;


namespace OSky.UI.Models.Identity
{
    /// <summary>
    /// 实体类——用户信息
    /// </summary>
    [Description("认证-用户信息")]
    public class User : UserBase<int>
    {
        /// <summary>
        /// 获取或设置 是否冻结
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        /// 获取或设置 用户扩展信息
        /// </summary>
        public virtual UserExtend Extend { get; set; }
    }
}