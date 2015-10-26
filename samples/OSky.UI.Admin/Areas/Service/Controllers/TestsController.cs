// -----------------------------------------------------------------------
//  <copyright file="TestsController.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-09-24 12:06</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using OSky.Core.Context;
using OSky.Core.Security;
using OSky.Utility.Extensions;
using OSky.Web.Http.Extensions;
using OSky.Web.Http.Logging;


namespace OSky.UI.Admin.Areas.Service.Controllers
{
    [Description("服务-测试")]
    [OperateLogFilter]
    public class TestsApiController : ApiController
    {
        /// <summary>
        /// 获取或设置 服务提供者
        /// </summary>
        public IServiceProvider ServiceProvider { get; set; }

        [Description("服务-测试-测试001")]
        [HttpGet]
        public IHttpActionResult Test01()
        {
            IFunction function = ControllerContext.Request.GetExecuteFunction(ServiceProvider);
            string name = function != null ? function.Name : null;

            return Ok("Hello World.{0}".FormatWith(name));
        }
    }
}