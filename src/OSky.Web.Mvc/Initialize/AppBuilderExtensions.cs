// -----------------------------------------------------------------------
//  <copyright file="AppBuilderExtensions.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-09-29 23:00</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core;
using OSky.Core.Dependency;
using OSky.Utility;

using Owin;


namespace OSky.Web.Mvc.Initialize
{
    /// <summary>
    /// <see cref="IAppBuilder"/>初始化扩展
    /// </summary>
    public static class AppBuilderExtensions
    {
        /// <summary>
        /// 初始化Mvc框架
        /// </summary>
        public static IAppBuilder UseOSkyMvc(this IAppBuilder app, IServiceCollection services, IIocBuilder iocBuilder)
        {
            services.CheckNotNull("services");
            iocBuilder.CheckNotNull("iocBuilder");
            IFrameworkInitializer initializer = new FrameworkInitializer();
            initializer.Initialize(services, iocBuilder);
            return app;
        }
    }
}