﻿// -----------------------------------------------------------------------
//  <copyright file="IEntityDto.cs" company="">
//      Copyright (c) 2014 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2014-12-14 2:46</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OSky.Core.Data
{
    /// <summary>
    /// 添加DTO
    /// </summary>
    public interface IAddDto
    { }


    /// <summary>
    /// 编辑DTO
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IEditDto<TKey>
    {
        /// <summary>
        /// 获取或设置 主键，唯一标识
        /// </summary>
        TKey Id { get; set; }
    }
}