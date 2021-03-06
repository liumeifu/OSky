﻿// -----------------------------------------------------------------------
//  <copyright file="EntityMapStore.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-08-07 3:53</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Security;
using OSky.UI.Dtos.Security;
using OSky.UI.Models.Identity;
using OSky.UI.Models.Security;


namespace OSky.UI.Security
{
    /// <summary>
    /// 数据（角色、用户）映射存储
    /// </summary>
    public class EntityMapStore
        : EntityMapStoreBase<EntityRoleMap, int, EntityUserMap, int, EntityRoleMapDto, EntityUserMapDto, EntityInfo, Guid, Role, int, User, int>
    { }
}