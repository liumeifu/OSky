﻿// -----------------------------------------------------------------------
//  <copyright file="FunctionRoleMapDto.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-08-04 11:45</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Data;


namespace OSky.Core.Security.Dtos
{
    /// <summary>
    /// 功能角色映射基类DTO
    /// </summary>
    public abstract class FunctionRoleMapBaseDto<TKey, TFunctionKey, TRoleKey> : IAddDto, IEditDto<TKey>
    {
        /// <summary>
        /// 获取或设置 主键，唯一标识
        /// </summary>
        public TKey Id { get; set; }

        /// <summary>
        /// 获取或设置 功能编号
        /// </summary>
        public TFunctionKey FunctionId { get; set; }

        /// <summary>
        /// 获取或设置 角色编号
        /// </summary>
        public TRoleKey RoleId { get; set; }

        /// <summary>
        /// 获取或设置 限制类型
        /// </summary>
        public FilterType FilterType { get; set; }
    }
}