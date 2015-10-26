// -----------------------------------------------------------------------
//  <copyright file="IAudited.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-06-21 14:56</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OSky.Core.Data
{
    /// <summary>
    /// 表示审计属性，包含<see cref="ICreatedAudited"/>与<see cref="IUpdateAudited"/>
    /// </summary>
    public interface IAudited : ICreatedAudited, IUpdateAudited
    { }
}