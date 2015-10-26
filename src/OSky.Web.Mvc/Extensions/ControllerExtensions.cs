// -----------------------------------------------------------------------
//  <copyright file="ControllerExtensions.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-07-16 4:10</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

using OSky.Utility.Extensions;


namespace OSky.Web.Mvc.Extensions
{
    /// <summary>
    /// Controller相关扩展方法
    /// </summary>
    public static class ControllerContextExtensions
    {
        /// <summary>
        /// 获取Area名
        /// </summary>
        /// <param name="context">MVC控制器上下文</param>
        /// <returns></returns>
        public static string GetAreaName(this ControllerContext context)
        {
            string area = null;
            object value;
            if (context.RequestContext.RouteData.DataTokens.TryGetValue("area", out value))
            {
                area = (string)value;
                if (area.IsNullOrWhiteSpace())
                {
                    area = null;
                }
            }
            return area;
        }

        /// <summary>
        /// 获取Controller名
        /// </summary>
        /// <param name="context">MVC控制器上下文</param>
        /// <returns></returns>
        public static string GetControllerName(this ControllerContext context)
        {
            return context.RequestContext.RouteData.Values["controller"].ToString();
        }

        /// <summary>
        /// 获取Action名
        /// </summary>
        /// <param name="context">MVC控制器上下文</param>
        /// <returns></returns>
        public static string GetActionName(this ControllerContext context)
        {
            return context.RequestContext.RouteData.Values["action"].ToString();
        }
    }
}