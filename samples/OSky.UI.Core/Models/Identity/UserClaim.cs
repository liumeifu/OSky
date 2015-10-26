// -----------------------------------------------------------------------
//  <copyright file="UserClaim.cs" company="">
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
    /// 实体类——用户摘要标识信息
    /// </summary>
    [Description("认证-用户摘要标识信息")]
    public class UserClaim : UserClaimBase<int, User, int>
    { }
}