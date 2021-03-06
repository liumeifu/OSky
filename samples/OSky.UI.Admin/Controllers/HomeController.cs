﻿// -----------------------------------------------------------------------
//  <copyright file="HomeController.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-07-14 1:02</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OSky.Utility.Logging;
using OSky.Web.Mvc.Logging;


namespace OSky.UI.Admin.Controllers
{
    [OperateLogFilter]
    [Description("网站")]
    public class HomeController : Controller
    {
        private static readonly ILogger Logger = LogManager.GetLogger(typeof(HomeController));

        [Description("网站-首页")]
        public ActionResult Index()
        {
            Logger.Debug("访问首页，将转向到后台管理首页");
            //return RedirectToAction("Index", "Home", new { area = "Admin" });
            //var data = new
            //{
            //    OrganizationCount = _identityContract.Organizations.Count(),
            //    UserCount = _identityContract.Users.Count(),
            //    RoleCount = _identityContract.Roles.Count()
            //};
            //ViewBag.Data = data.ToDynamic();
            return View();
        }
    }
}