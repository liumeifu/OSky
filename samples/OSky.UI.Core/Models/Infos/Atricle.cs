﻿// -----------------------------------------------------------------------
//  <copyright file="Atricle.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-06-21 18:09</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Data;
using OSky.Utility.Data;


namespace OSky.UI.Models.Infos
{
    /// <summary>
    /// 实体类——文章信息
    /// </summary>
    [Description("信息-文章信息")]
    public class Atricle : EntityBase<Guid>, IAudited
    {
        public Atricle()
        {
            Id = CombHelper.NewComb();
        }

        /// <summary>
        /// 获取或设置 文章标题
        /// </summary>
        [Required, StringLength(100)]
        public string Title { get; set; }

        /// <summary>
        /// 获取或设置 文章内容
        /// </summary>
        public string Content { get; set; }

        #region Implementation of ICreatedTime

        /// <summary>
        /// 获取设置 信息创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        #endregion

        #region Implementation of ICreatedAudited

        /// <summary>
        /// 获取或设置 创建者编号
        /// </summary>
        [StringLength(50)]
        public string CreatorUserId { get; set; }

        #endregion

        #region Implementation of IUpdateAutited

        /// <summary>
        /// 获取或设置 最后更新时间
        /// </summary>
        public DateTime? LastUpdatedTime { get; set; }

        /// <summary>
        /// 获取或设置 最后更新者编号
        /// </summary>
        [StringLength(50)]
        public string LastUpdatorUserId { get; set; }

        #endregion
    }
}