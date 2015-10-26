// -----------------------------------------------------------------------
//  <copyright file="Global.asax.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-09-29 20:35</last-date>
// -----------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using OSky.Autofac.Http;
using OSky.Autofac.Mvc;
using OSky.Autofac.SignalR;
using OSky.Core;
using OSky.Core.Caching;
using OSky.Core.Configs;
using OSky.Core.Dependency;
using OSky.Core.Initialize;
using OSky.UI.Dtos;
using OSky.Logging.Log4Net;
using OSky.SiteBase.Initialize;
using OSky.Web.Http.Initialize;
using OSky.Web.Mvc.Initialize;
using OSky.Web.Mvc.Routing;
using OSky.Web.SignalR.Initialize;


namespace OSky.UI.Admin
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            RoutesRegister();
            DtoMappers.MapperRegister();

            //Initialize();
        }

        private static void RoutesRegister()
        {
            RouteCollection routes = RouteTable.Routes;
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapLowerCaseUrlRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "OSky.UI.Admin.Controllers" });
        }

        private static void Initialize()
        {
            ICacheProvider provider = new RuntimeMemoryCacheProvider();
            CacheManager.SetProvider(provider, CacheLevel.First);
            
            IServicesBuilder builder = new ServicesBuilder(new ServiceBuildOptions());
            IServiceCollection services = builder.Build();
            services.AddLog4NetServices();
            services.AddDataServices();

            IFrameworkInitializer initializer = new FrameworkInitializer();
            
            initializer.Initialize(services, new MvcAutofacIocBuilder());
            initializer.Initialize(services, new WebApiAutofacIocBuilder());
            initializer.Initialize(services, new SignalRAutofacIocBuilder());
        }
    }
}