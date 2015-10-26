// -----------------------------------------------------------------------
//  <copyright file="OrganizationConfiguration.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-03-24 17:01</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Data.Entity;


namespace OSky.UI.ModelConfigurations.Identity
{
    public partial class OrganizationConfiguration
    {
        /// <summary>
        /// 获取 相关上下文类型
        /// </summary>
        public override Type DbContextType
        {
            get { return typeof(DefaultDbContext); }
        }

        partial void OrganizationConfigurationAppend()
        {
            HasOptional(m => m.Parent).WithMany(n => n.Children);
        }
    }
}