﻿// -----------------------------------------------------------------------
//  <copyright file="UserLogin.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-06-25 14:39</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Identity.Models;


namespace OSky.UI.Models.Identity
{
    /// <summary>
    /// 实体类——用户第三方登录（OAuth，如facebook,google）信息
    /// </summary>
    [Description("认证-第三方登录信息")]
    public class UserLogin : UserLoginBase<int, User, int>
    { }
}