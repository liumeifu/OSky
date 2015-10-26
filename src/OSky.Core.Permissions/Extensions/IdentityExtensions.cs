// -----------------------------------------------------------------------
//  <copyright file="IdentityExtensions.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-08-08 0:33</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;

using OSky.Utility.Data;
using OSky.Utility.Extensions;


namespace OSky.Core.Identity
{
    /// <summary>
    /// 认证扩展辅助操作
    /// </summary>
    public static class IdentityExtensions
    {
        /// <summary>
        /// 将<see cref="IdentityResult"/>转化为<see cref="OperationResult"/>
        /// </summary>
        public static OperationResult ToOperationResult(this IdentityResult identityResult)
        {
            return identityResult.Succeeded
                ? new OperationResult(OperationResultType.Success)
                : new OperationResult(OperationResultType.Error, identityResult.Errors.ExpandAndToString());
        }
    }
}