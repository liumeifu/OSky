// -----------------------------------------------------------------------
//  <copyright file="ICreatedAudited.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-06-21 14:35</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OSky.Core.Data
{
    /// <summary>
    /// 给信息添加 创建时间、创建者 属性，在实体创建时，将自动提取当前用户为创建者
    /// </summary>
    public interface ICreatedAudited : ICreatedTime
    {
        /// <summary>
        /// 获取或设置 创建者编号
        /// </summary>
        string CreatorUserId { get; set; }
    }
}