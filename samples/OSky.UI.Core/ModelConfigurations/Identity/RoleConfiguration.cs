﻿// -----------------------------------------------------------------------
//  <copyright file="RoleConfiguration.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-03-24 17:02</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OSky.UI.ModelConfigurations.Identity
{
    public partial class RoleConfiguration
    {
        partial void RoleConfigurationAppend()
        {
            //HasRequired(m => m.Organization).WithMany(n => n.Roles);
        }
    }
}