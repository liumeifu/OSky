// -----------------------------------------------------------------------
//  <copyright file="RoleLimitAttribute.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-07-13 9:48</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OSky.Core.Security
{
    /// <summary>
    /// 指定功能只允许特定角色可以访问
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class RoleLimitAttribute : Attribute
    { }
}