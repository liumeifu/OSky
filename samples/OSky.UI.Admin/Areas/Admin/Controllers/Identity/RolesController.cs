// -----------------------------------------------------------------------
//  <copyright file="RolesController.cs" company="">
//      Copyright (c) 2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>最后修改人</last-editor>
//  <last-date>2015-01-09 20:43</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OSky.UI.Contracts;
using OSky.UI.Dtos.Identity;
using OSky.Utility;
using OSky.Utility.Data;
using OSky.Utility.Filter;
using OSky.Web.Mvc.Binders;
using OSky.Web.Mvc.Extensions;
using OSky.Web.Mvc.Logging;
using OSky.Web.Mvc.Security;
using OSky.Web.Mvc.UI;
using OSky.UI.Admin.ViewModels;
using Newtonsoft.Json;

namespace OSky.UI.Admin.Areas.Admin.Controllers
{
    [Description("管理-角色")]
    public class RolesController : AdminBaseController
    {
        /// <summary>
        /// 获取或设置 身份认证业务对象
        /// </summary>
        public IIdentityContract IdentityContract { get; set; }

        #region Ajax功能

        #region 获取数据

        //id: 组织机构编号
        [AjaxOnly]
        [Description("管理-角色-列表数据")]
        public ActionResult GridData(int? id)
        {
            GridRequest request = new GridRequest(Request);
            var page = GetPageResult(IdentityContract.Roles, m => new
            {
                m.Id,
                m.Name,
                m.Remark,
                m.IsAdmin,
                m.IsSystem,
                m.IsLocked,
                m.CreatedTime
            }, request);

            return Json(page.ToGridData(), JsonRequestBehavior.AllowGet);
        }

        [AjaxOnly]
        [Description("管理-角色-节点数据")]
        public ActionResult NodeData()
        {
            var roots = IdentityContract.Organizations
                .OrderBy(m => m.SortCode).Select(m => new OrganTree
                {
                    id = m.Id,
                    pid = m.ParentId,
                    text = m.Name,
                    Type = 0
                }).ToList();
            var users = IdentityContract.Users.Where(c => c.IsLocked == false).Select(m => new OrganTree
            {
                id = m.Id,
                pid = m.OrganizationId,
                text = m.NickName,
                Type = 1
            }).ToList();
            roots.AddRange(users);
            return Content(JsonConvert.SerializeObject(roots), "application/json");

        }

        [HttpPost]
        [AjaxOnly]
        [Description("管理-角色-用户信息")]
        public ActionResult GetUsersByRoleId(int RoleId)
        {
            var userIds= IdentityContract.UserRoleMaps.Where(m => m.RoleId == RoleId).ToList();
            return Content(JsonConvert.SerializeObject(userIds), "application/json");

        }

        #endregion

        #region 功能方法

        [HttpPost]
        [AjaxOnly]
        [Description("管理-角色-新增")]
        public ActionResult Add(RoleDto[] dtos)
        {
            dtos.CheckNotNull("dtos" );
            OperationResult result = IdentityContract.AddRoles(dtos);
            return Json(result.ToAjaxResult());
        }

        [HttpPost]
        [AjaxOnly]
        [Description("管理-角色-编辑")]
        public ActionResult Edit(RoleDto[] dtos)
        {
            dtos.CheckNotNull("dtos" );
            OperationResult result = IdentityContract.EditRoles(dtos);
            return Json(result.ToAjaxResult());
        }

        [HttpPost]
        [AjaxOnly]
        [Description("管理-角色-删除")]
        public ActionResult Delete(int[] ids)
        {
            ids.CheckNotNull("ids" );
            OperationResult result = IdentityContract.DeleteRoles(ids);
            return Json(result.ToAjaxResult());
        }

        #endregion

        #endregion

        #region 视力功能

        [Description("管理-角色-列表")]
        public ActionResult Index()
        {
            return View();
        }

        #endregion
    }
}