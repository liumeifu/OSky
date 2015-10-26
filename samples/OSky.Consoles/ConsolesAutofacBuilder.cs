// -----------------------------------------------------------------------
//  <copyright file="ConsolesAutofacBuilder.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-10-10 15:35</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autofac;

using OSky.App.Local.Initialize;
using OSky.Core.Dependency;


namespace OSky.Consoles
{
    public class ConsolesAutofacBuilder : LocalAutofacIocBuilder
    {
        /// <summary>
        /// 添加自定义服务映射
        /// </summary>
        /// <param name="services">服务信息集合</param>
        protected override void AddCustomTypes(IServiceCollection services)
        {
            base.AddCustomTypes(services);
            services.AddSingleton<Program, Program>();
        }
    }
}