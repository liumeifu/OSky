﻿// -----------------------------------------------------------------------
//  <copyright file="Extensions.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-09-23 17:37</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections;
using System.Web.Mvc;

using OSky.Core;
using OSky.Core.Context;
using OSky.Core.Data;
using OSky.Core.Dependency;
using OSky.Core.Security;
using OSky.Web.Mvc.UI;


namespace OSky.Web.Mvc.Extensions
{
    /// <summary>
    /// 扩展辅助操作方法
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// 获取MVC操作的相关功能信息
        /// </summary>
        public static IFunction GetExecuteFunction(this ControllerContext context, IServiceProvider provider)
        {
            const string key = Constants.CurrentMvcFunctionKey;
            IDictionary items = context.HttpContext.Items;
            if (items.Contains(key))
            {
                return (IFunction)items[key];
            }
            string area = context.GetAreaName();
            string controller = context.GetControllerName();
            string action = context.GetActionName();
            IFunctionHandler functionHandler = provider.GetService<IFunctionHandler>();
            if (functionHandler == null)
            {
                return null;
            }
            IFunction function = functionHandler.GetFunction(area, controller, action);
            if (function != null)
            {
                items.Add(key, function);
            }
            return function;
        }

        /// <summary>
        /// 获取MVC操作的相关功能信息
        /// </summary>
        public static IFunction GetExecuteFunction(this ControllerBase controller, IServiceProvider provider)
        {
            return controller.ControllerContext.GetExecuteFunction(provider);
        }

        /// <summary>
        /// 将分页数据转换为表格数据格式
        /// </summary>
        public static GridData<TData> ToGridData<TData>(this PageResult<TData> pageResult)
        {
            return new GridData<TData>(pageResult.Data, pageResult.Total);
        }
    }
}