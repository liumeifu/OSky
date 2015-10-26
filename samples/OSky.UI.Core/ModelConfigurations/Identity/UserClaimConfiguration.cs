// -----------------------------------------------------------------------
//  <copyright file="UserClaimConfiguration.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-06-25 14:42</last-date>
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
    public class UserClaimConfiguration : EntityConfigurationBase<UserClaim, int>
    {
        public UserClaimConfiguration()
        {
            HasRequired(m => m.User).WithMany();
        }
    }
}