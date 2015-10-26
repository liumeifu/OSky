// -----------------------------------------------------------------------
//  <copyright file="FunctionRoleMap.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-08-04 13:59</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Security;
using OSky.Core.Security.Models;
using OSky.UI.Models.Identity;


namespace OSky.UI.Models.Security
{
    /// <summary>
    /// 实体类——功能角色映射信息
    /// </summary>
    [Description("权限-功能角色映射信息")]
    public class FunctionRoleMap : FunctionRoleMapBase<int, Function, Guid, Role, int>
    { }
}