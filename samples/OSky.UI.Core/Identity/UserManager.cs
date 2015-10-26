// -----------------------------------------------------------------------
//  <copyright file="UserManager.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-08-03 11:47</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;

using OSky.Core;
using OSky.Core.Dependency;
using OSky.UI.Models.Identity;


namespace OSky.UI.Identity
{
    /// <summary>
    /// 用户管理器
    /// </summary>
    public class UserManager : UserManager<User, int>, IScopeDependency
    {
        /// <summary>
        /// 初始化一个<see cref="UserManager"/>类型的新实例
        /// </summary>
        public UserManager(IUserStore<User, int> store)
            : base(store)
        { }
    }
}