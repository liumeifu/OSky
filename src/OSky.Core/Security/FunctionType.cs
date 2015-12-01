// -----------------------------------------------------------------------
//  <copyright file="FunctionType.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-06-17 9:11</last-date>
// -----------------------------------------------------------------------

namespace OSky.Core.Security
{
    /// <summary>
    /// 表示功能访问类型的枚举
    /// </summary>
    public enum FunctionType
    {
        /// <summary>
        /// 匿名用户可访问
        /// </summary>
        Anonymouse = 0,

        /// <summary>
        /// 登录用户可访问
        /// </summary>
        Logined = 1,

        /// <summary>
        /// 指定角色可访问
        /// </summary>
        RoleLimit = 2
    }

    /// <summary>
    /// 表示功能类型的枚举(1 菜单、2 按钮、0 其它)
    /// </summary>
    public enum MenuType
    {
        /// <summary>
        /// 其它类型
        /// </summary>
        Other = 0,

        /// <summary>
        /// 菜单类型
        /// </summary>
        Menu = 1,

        /// <summary>
        /// 按钮类型
        /// </summary>
        Button = 2
    }
}