// -----------------------------------------------------------------------
//  <copyright file="OrganizationsController.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-07-14 1:23</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Web.Mvc;

using Newtonsoft.Json;

using OSky.UI.Contracts;
using OSky.UI.Dtos.Identity;
using OSky.UI.Models.Identity;
using OSky.Utility;
using OSky.Utility.Data;
using OSky.Web.Mvc.Binders;
using OSky.Web.Mvc.Security;
using OSky.Web.Mvc.UI;


namespace OSky.UI.Admin.Areas.Admin.Controllers
{
    [Description("管理-组织机构")]
    public class OrganizationsController : AdminBaseController
    {
        /// <summary>
        /// 获取或设置 身份认证业务对象
        /// </summary>
        public IIdentityContract IdentityContract { get; set; }

        #region 视力功能

        [Description("管理-组织机构-列表视图")]
        public override ActionResult Index()
        {
            return base.Index();
        }

        [Description("管理-组织机构-编辑视图")]
        public ActionResult VisitEdit(int id)
        {
            var dto= IdentityContract.Organizations.Where(c => c.Id == id).Select(m =>
                new OrganizationDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    Remark = m.Remark,
                    SortCode = m.SortCode,
                    ParentId = m.Parent.Id
                }).SingleOrDefault();
            if (dto==null)
                dto = new OrganizationDto();
            return View("Edit", dto);
        }

        #endregion

        private class OrganizationView
        {
            public OrganizationView(Organization org)
            {
                Id = org.Id;
                Name = org.Name;
                Remark = org.Remark;
                SortCode = org.SortCode;
                CreatedTime = org.CreatedTime;
                children = new List<OrganizationView>();
            }

            public int Id { get; set; }

            public string Name { get; set; }

            public string Remark { get; set; }

            public int SortCode { get; set; }

            public DateTime CreatedTime { get; set; }

            public ICollection<OrganizationView> children { get; set; }
        }

        #region Ajax功能

        #region 获取数据

        [AjaxOnly]
        [Description("管理-组织机构-列表数据")]
        public ActionResult GridData()
        {
            Func<Organization, ICollection<Organization>, OrganizationView> getOrganizationView = null;
            getOrganizationView = (org, source) =>
            {
                OrganizationView view = new OrganizationView(org);
                List<Organization> children = source.Where(m => m.TreePathIds.Length == org.TreePathIds.Length + 1
                    && m.TreePath.StartsWith(m.TreePath)).ToList();
                foreach (Organization child in children)
                {
                    OrganizationView childView = getOrganizationView(child, source);
                    view.children.Add(childView);
                }
                return view;
            };
            List<Organization> roots = IdentityContract.Organizations.Where(m => m.Parent == null).OrderBy(m => m.SortCode).ToList();
            List<OrganizationView> datas = (from root in roots
                                            let source = IdentityContract.Organizations.Where(m => m.TreePath.StartsWith(root.TreePath)).ToList()
                                            select getOrganizationView(root, source)).ToList();
            return Json(datas, JsonRequestBehavior.AllowGet);
        }

        [AjaxOnly]
        [Description("管理-组织机构-节点数据")]
        public ActionResult NodeData()
        {
            Func<Organization, object> getNodeData = null;
            getNodeData = org =>
            {
                dynamic node = new ExpandoObject();
                node.id = org.Id;
                node.text = org.Name;
                node.children = new List<dynamic>();
                var children = org.Children.OrderBy(m => m.SortCode).ToList();
                foreach (var child in children)
                {
                    node.children.Add(getNodeData(child));
                }
                return node;
            };
            List<Organization> roots = IdentityContract.Organizations.Where(m => m.Parent == null).OrderBy(m => m.SortCode).ToList();
            List<object> nodes = roots.Select(getNodeData).ToList();
            string json = JsonConvert.SerializeObject(nodes);
            return Content(json, "application/json");
        }

        #endregion

        #region 功能方法

        [HttpPost]
        [Description("管理-组织机构-新增")]
        public ActionResult Add(OrganizationDto dto)
        {
            dto.CheckNotNull("dto");
            OperationResult result = IdentityContract.AddOrganizations(dto);
            return Json(result.ToAjaxResult());
        }

        [HttpPost]
        [AjaxOnly]
        [Description("管理-组织机构-编辑")]
        public ActionResult Edit(OrganizationDto dto)
        {
            dto.CheckNotNull("dto");
            OperationResult result = IdentityContract.EditOrganizations(dto);
            return Json(result.ToAjaxResult());
        }

        [HttpPost]
        [AjaxOnly]
        [Description("管理-组织机构-删除")]
        public ActionResult Delete(int id)
        {
            id.CheckGreaterThan("id", 0);
            OperationResult result = IdentityContract.DeleteOrganizations(id);
            return Json(result.ToAjaxResult());
        }

        #endregion

        #endregion
    }
}