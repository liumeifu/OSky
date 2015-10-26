// -----------------------------------------------------------------------
//  <copyright file="AccountController.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-06-29 22:32</last-date>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;

using OSky.Web.Mvc;


namespace OSky.UI.Admin.Controllers
{
    [Description("网站-账户")]
    public class AccountController : BaseController
    {
        [Description("账户-首页")]
        public ActionResult Index()
        {
            return new EmptyResult();
        }
    }
}