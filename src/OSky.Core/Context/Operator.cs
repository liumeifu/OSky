// -----------------------------------------------------------------------
//  <copyright file="Operator.cs" company="">
//      Copyright (c) 2014 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2014-08-12 19:24</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OSky.Core.Context
{
    /// <summary>
    /// 当前操作者信息类
    /// </summary>
    public class Operator
    {
        /// <summary>
        /// 获取或设置 当前用户标识
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 获取或设置 当前用户名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 获取或设置 当前用户昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 获取或设置 当前访问IP
        /// </summary>
        public string Ip { get; set; }
    }
}