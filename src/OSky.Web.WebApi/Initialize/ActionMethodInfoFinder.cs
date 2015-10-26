// -----------------------------------------------------------------------
//  <copyright file="ActionMethodInfoFinder.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-09-25 0:09</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

using OSky.Core.Reflection;
using OSky.Utility.Extensions;
using OSky.Web.Http.Properties;


namespace OSky.Web.Http.Initialize
{
    /// <summary>
    /// WebApi功能方法查找器
    /// </summary>
    public class ActionMethodInfoFinder : IMethodInfoFinder
    {
        /// <summary>
        /// 查找指定条件的方法信息
        /// </summary>
        /// <param name="type">控制器类型</param>
        /// <param name="predicate">筛选条件</param>
        /// <returns></returns>
        public MethodInfo[] Find(Type type, Func<MethodInfo, bool> predicate)
        {
            return FindAll(type).Where(predicate).ToArray();
        }

        /// <summary>
        /// 从指定类型查找方法信息
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public MethodInfo[] FindAll(Type type)
        {
            if (!typeof(ApiController).IsAssignableFrom(type))
            {
                throw new InvalidOperationException(Resources.ActionMethodInfoFinder_TypeNotApiControllerType.FormatWith(type.FullName));
            }
            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .Where(m => typeof(IHttpActionResult).IsAssignableFrom(m.ReturnType) || m.ReturnType == typeof(Task<IHttpActionResult>))
                .ToArray();
            return methods;
        }
    }
}