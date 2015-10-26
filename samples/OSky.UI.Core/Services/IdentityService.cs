// -----------------------------------------------------------------------
//  <copyright file="IdentityService.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-06-30 3:35</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core;
using OSky.Core.Data;
using OSky.UI.Contracts;
using OSky.UI.Models.Identity;


namespace OSky.UI.Services
{
    /// <summary>
    /// 业务实现——身份认证模块
    /// </summary>
    public partial class IdentityService : IIdentityContract
    {
        /// <summary>
        /// 获取或设置 组织机构信息仓储操作对象
        /// </summary>
        public IRepository<Organization, int> OrganizationRepository { protected get; set; }

        /// <summary>
        /// 获取或设置 角色信息仓储对象
        /// </summary>
        public IRepository<Role, int> RoleRepository { protected get; set; }

        /// <summary>
        /// 获取或设置 用户信息仓储对象
        /// </summary>
        public IRepository<User, int> UserRepository { protected get; set; }

        /// <summary>
        /// 获取或设置 用户扩展信息仓储对象
        /// </summary>
        public IRepository<UserExtend, int> UserExtendRepository { protected get; set; }

        /// <summary>
        /// 获取或设置 用户角色映射信息仓储对象
        /// </summary>
        public IRepository<UserRoleMap, int> UserRoleMapRepository { get; set; }
    }
}