// -----------------------------------------------------------------------
//  <copyright file="SecurityService.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-07-14 23:07</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Data;
using OSky.Core.Security;
using OSky.UI.Contracts;


namespace OSky.UI.Services
{
    /// <summary>
    /// 业务实现——功能模块
    /// </summary>
    public partial class SecurityService : ISecurityContract
    {
        /// <summary>
        /// 获取或设置 服务提供者
        /// </summary>
        public IServiceProvider ServiceProvider { get; set; }

        /// <summary>
        /// 获取或设置 功能信息仓储对象
        /// </summary>
        public IRepository<Function, Guid> FunctionRepository { protected get; set; }

        /// <summary>
        /// 获取或设置 实体数据信息仓储对象
        /// </summary>
        public IRepository<EntityInfo, Guid> EntityInfoRepository { protected get; set; }
    }
}