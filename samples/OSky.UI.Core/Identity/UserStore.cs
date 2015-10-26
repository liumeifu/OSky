// -----------------------------------------------------------------------
//  <copyright file="UserStore.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-08-03 20:54</last-date>
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
    /// 用户存储实现
    /// </summary>
    public class UserStore : UserStoreBase<User, int, Role, int, UserRoleMap, int, UserLogin, int, UserClaim, int>
    { }
}