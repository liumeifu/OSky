// -----------------------------------------------------------------------
//  <copyright file="RoleStore.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-08-03 11:48</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Data;
using OSky.Core.Identity;
using OSky.UI.Models.Identity;


namespace OSky.UI.Identity
{
    /// <summary>
    /// 角色存储实现
    /// </summary>
    public class RoleStore : RoleStoreBase<Role, int>
    { }
}