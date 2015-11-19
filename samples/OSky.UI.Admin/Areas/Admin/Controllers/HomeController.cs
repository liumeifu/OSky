// -----------------------------------------------------------------------
//  <copyright file="HomeController.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-02-19 17:43</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OSky.UI.Admin.ViewModels;
using OSky.Utility.Logging;
using OSky.Web.Mvc.Security;


namespace OSky.UI.Admin.Areas.Admin.Controllers
{
    [Description("管理-后台")]
    public class HomeController : Controller
    {
        private static readonly ILogger Logger = LogManager.GetLogger(typeof(HomeController));

        #region Ajax功能

        #region 获取数据

        [AjaxOnly]
        [Description("管理-菜单数据")]
        public ActionResult GetMenuData()
        {
            List<TreeNode> nodes = new List<TreeNode>()
            {
                new TreeNode()
                {
                    Text = "权限设置",
                    IconCls = "pic_71",
                    Children = new List<TreeNode>()
                    {
                        new TreeNode() { Text = "用户管理", IconCls = "pic_5", Url = Url.Action("Index", "Users") },
                        new TreeNode() { Text = "角色管理", IconCls = "pic_198", Url = Url.Action("Index", "Roles") },
                        new TreeNode() { Text = "组织机构管理", IconCls = "pic_76", Url = Url.Action("Index", "Organizations") },
                        new TreeNode() { Text = "功能管理", IconCls = "pic_94", Url = Url.Action("Index", "Functions") },
                        new TreeNode() { Text = "实体数据管理", IconCls = "pic_95", Url = Url.Action("Index", "EntityInfos") },
                    }
                },
                new TreeNode()
                {
                    Text = "系统管理",
                    IconCls = "pic_100",
                    Children = new List<TreeNode>()
                    {
                        new TreeNode() { Text = "操作日志", IconCls = "pic_125", Url = Url.Action("OperateLogs", "Logging") },
                        new TreeNode() { Text = "系统日志", IconCls = "pic_100", Url = Url.Action("SystemLogs", "Logging") }
                    }
                },
                new TreeNode()
                {
                    Text = "工作流管理",
                    IconCls = "pic_2",
                    Children = new List<TreeNode>()
                    {
                        new TreeNode() { Text = "表单管理", IconCls = "pic_461", Url = Url.Action("Index", "Form") },
                        new TreeNode() { Text = "流程管理", IconCls = "pic_346", Url = Url.Action("Index", "Flow") },
                        new TreeNode() { Text = "事项管理", IconCls = "pic_17", Url = Url.Action("Index", "Matter") },
                        new TreeNode() { Text = "委托管理", IconCls = "pic_199", Url = Url.Action("Index", "Delegation") },
                        new TreeNode() { Text = "待办事宜", IconCls = "pic_123", Url = Url.Action("Index", "Schedule") },
                        new TreeNode() { Text = "已办事宜", IconCls = "pic_117", Url = Url.Action("Index", "Finish") },
                        new TreeNode() { Text = "档案管理", IconCls = "pic_33", Url = Url.Action("Index", "Archives") }
                    }
                }
            };

            Action<ICollection<TreeNode>> action = list =>
            {
                foreach (TreeNode node in list)
                {
                    node.Id = "node" + node.Text;
                }
            };

            foreach (TreeNode node in nodes)
            {
                node.Id = "node" + node.Text;
                if (node.Children != null && node.Children.Count > 0)
                {
                    action(node.Children);
                }
            }

            return Json(nodes, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #endregion

        [Description("管理-首页")]
        public ActionResult Index()
        {
            Logger.Debug("访问后台管理首页");
            return View();
        }

        [Description("管理-欢迎页")]
        public ActionResult Welcome()
        {
            return View();
        }
    }
}