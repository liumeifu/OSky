﻿// -----------------------------------------------------------------------
//  <copyright file="EntityInfoDto.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-07-15 2:03</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Data;


namespace OSky.UI.Dtos.Security
{
    /// <summary>
    /// DTO——实体数据信息
    /// </summary>
    public class EntityInfoDto : IAddDto, IEditDto<Guid>
    {
        /// <summary>
        /// 获取或设置 主键，唯一标识
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 获取 实体数据显示名称
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 获取 实体数据类型名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取 是否启用数据日志
        /// </summary>
        public bool DataLogEnabled { get; set; }
    }
}