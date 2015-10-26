// -----------------------------------------------------------------------
//  <copyright file="UserRoleMap.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-06-17 22:09</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Identity.Models;


namespace OSky.UI.Models.Identity
{
    /// <summary>
    /// 实体类——用户角色映射
    /// </summary>
    [Description("认证-用户角色映射信息")]
    public class UserRoleMap : UserRoleMapBase<int, User, int, Role, int>
    { }
}