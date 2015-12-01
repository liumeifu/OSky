// -----------------------------------------------------------------------
//  <copyright file="Function.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-07-14 0:14</last-date>
// -----------------------------------------------------------------------

using System;
using System.ComponentModel;

using OSky.Utility.Data;
using System.ComponentModel.DataAnnotations;


namespace OSky.Core.Security
{
    /// <summary>
    /// 实体类——功能信息
    /// </summary>
    [Description("权限-功能信息")]
    public class Function : FunctionBase<Guid>
    {
        /// <summary>
        /// 初始化一个<see cref="Function"/>类型的新实例
        /// </summary>
        public Function()
        {
            Id = CombHelper.NewComb();
        }

        /// <summary>
        /// 获取 菜单名称
        /// </summary>
        [StringLength(100)]
        public string MenuName { get; set; }

        /// <summary>
        /// 获取 功能类型
        /// </summary>
        public MenuType Type { get; set; }

        /// <summary>
        /// 获取 图片地址
        /// </summary>
        [StringLength(20)]
        public string IconCls { get; set; }
    }
}