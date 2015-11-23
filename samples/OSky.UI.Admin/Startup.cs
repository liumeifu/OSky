// -----------------------------------------------------------------------
//  <copyright file="Startup.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-09-29 23:12</last-date>
// -----------------------------------------------------------------------

using System;
using System.Threading.Tasks;

using Microsoft.Owin;

using OSky.Autofac.Http;
using OSky.Autofac.Mvc;
using OSky.Autofac.SignalR;
using OSky.Core;
using OSky.Core.Caching;
using OSky.Core.Dependency;
using OSky.UI.Admin;
using OSky.Logging.Log4Net;
using OSky.Web.Http.Initialize;
using OSky.Web.Mvc.Initialize;
using OSky.Web.SignalR.Initialize;

using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(Startup))]


namespace OSky.UI.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888

            ICacheProvider provider = new RuntimeMemoryCacheProvider();
            CacheManager.SetProvider(provider, CacheLevel.First);

            IServicesBuilder builder = new ServicesBuilder(new ServiceBuildOptions());
            IServiceCollection services = builder.Build();
            services.AddLog4NetServices();
            services.AddDataServices();

            app.UseOSkyMvc(services, new MvcAutofacIocBuilder());
            app.UseOSkyWebApi(services, new WebApiAutofacIocBuilder());
            app.UseOSkySignalR(services, new SignalRAutofacIocBuilder());
            
            ConfigurationWebApi(app);
            ConfigureSignalR(app);

            // 使应用程序可以使用 Cookie 来存储已登录用户的信息
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Admin/Login/Index"),
                ExpireTimeSpan = TimeSpan.FromMinutes(20),    //20分钟过期
                SlidingExpiration=true
            });

            //// Use a cookie to temporarily store information about a user logging in with a third party login provider
            //app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            //// 取消注释以下行可允许使用第三方登录提供程序登录
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            // 支持使用 google 账户登录
            //app.UseGoogleAuthentication();

        }
    }
}