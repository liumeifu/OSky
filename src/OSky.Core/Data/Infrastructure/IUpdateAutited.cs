// -----------------------------------------------------------------------
//  <copyright file="IUpdateAutited.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-06-21 14:55</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OSky.Core.Data
{
    /// <summary>
    /// 表示实体将包含更新者，更新时间属性，将在实体更新时自动赋值
    /// </summary>
    public interface IUpdateAudited
    {
        /// <summary>
        /// 获取或设置 最后更新时间
        /// </summary>
        DateTime? LastUpdatedTime { get; set; }

        /// <summary>
        /// 获取或设置 最后更新者编号
        /// </summary>
        string LastUpdatorUserId { get; set; }
    }
}