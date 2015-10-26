// -----------------------------------------------------------------------
//  <copyright file="UserConfiguration.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-03-24 17:04</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OSky.UI.ModelConfigurations.Identity
{
    public partial class UserConfiguration
    {
        partial void UserConfigurationAppend()
        {
            //Property(m => m.UserName).HasColumnAnnotation("Index",
            //    new IndexAnnotation(new IndexAttribute() { IsUnique = true }));
        }
    }
}