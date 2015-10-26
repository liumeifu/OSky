// -----------------------------------------------------------------------
//  <copyright file="UserRoleMapConfiguration.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-06-17 23:02</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Data.Entity;
using OSky.UI.Models.Identity;


namespace OSky.UI.ModelConfigurations.Identity
{
    public class UserRoleMapConfiguration : EntityConfigurationBase<UserRoleMap, Int32>
    {
        /// <summary>
        /// 初始化一个<see cref="UserRoleMapConfiguration"/>类型的新实例
        /// </summary>
        public UserRoleMapConfiguration()
        {
            UserExtendConfigurationAppend();
        }

        private void UserExtendConfigurationAppend()
        {
            HasRequired(m => m.User).WithMany();
            HasRequired(m => m.Role).WithMany();
        }
    }
}