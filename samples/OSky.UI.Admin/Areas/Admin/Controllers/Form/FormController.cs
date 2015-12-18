using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.ComponentModel;
using OSky.Web.Mvc.Security;
using OSky.UI.Dtos.Infos;
using OSky.UI.Contracts;
using OSky.Utility.Data;
using OSky.Web.Mvc.UI;

namespace OSky.UI.Admin.Areas.Admin.Controllers
{
    [Description("工作流-表单事项")]
    public class FormController : AdminBaseController
    {
        /// <summary>
        /// 获取或设置 表单业务对象
        /// </summary>
        public IFormContract FormContract { get; set; }

        /// <summary>
        /// 获取或设置基础模块业务对象
        /// </summary>
        public ICommonContract CommonContract { get; set; }

       /// <summary>
        /// 获取或设置 工作流业务对象
        /// </summary>
        public IFlowContract FlowContract { get; set; }

        #region Ajax功能

        #region 获取数据

        [AjaxOnly]
        [Description("管理-表单事项-节点数据")]
        public ActionResult NodeData()
        {
            var roots = CommonContract.Dictionarys.SingleOrDefault(c => c.Value == "BDLX").Children
                .OrderBy(m => m.SortCode).Select(m => new TreeView
                {
                    id=m.Id,
                    text = m.Name,
                    url = "",
                    action ="",
                    FlowId=Guid.Empty
                }).ToList();
  
            var forms = (from l in FlowContract.FlowForms
                         join r in FlowContract.FlowRelateForms on l.Id equals r.FlowFormId
                         join d in CommonContract.Dictionarys on l.TypeVal equals d.Value
                         select new TreeView
                         {
                             id=d.Id,
                             text = "请假单",
                             url = l.FilePath,
                             action=l.ActionPath,
                             FlowId=r.FlowDesignId
                         }).ToList();

            foreach (var item in roots)
	        {
                item.children.AddRange(forms.FindAll(c => c.id == item.id));
                forms.RemoveAll(c => c.id == item.id);
	        }
            return Json(roots, JsonRequestBehavior.AllowGet);

        }

        public class TreeView
        {
            public TreeView()
            {
                children = new List<TreeView>();
            }
            public int? id{ get; set; }
            public Guid? FlowId { get; set; }
            public string text { get; set; }
            public string url { get; set; }
            public string action { get; set; }
            public List<TreeView> children { get; set; }
        }
        #endregion

        #region 功能方法

        [AjaxOnly]
        [HttpPost]
        [Description("工作流-请假单-添加")]
        public ActionResult AddLeave(LeaveDto[] dtos)
        {
            OperationResult result = FormContract.AddLeave(dtos);
            return Json(result.ToAjaxResult());
        }

        [AjaxOnly]
        [HttpPost]
        [Description("工作流-请假单-修改")]
        public ActionResult EditLeave(LeaveDto[] dtos)
        {
            OperationResult result = FormContract.EditLeave(dtos);
            return Json(result.ToAjaxResult());
        }


        #endregion

        #endregion

        #region 视图功能

        [Description("工作流-表单事项-请假单")]
        public ActionResult LeaveForm(Guid Id)
        {
            var dto = new LeaveDto { CreatorUserId = Operator.UserId, CreatorUserName = Operator.UserName };
            if (Guid.Empty != Id) { 
                var model = FormContract.Leaves.SingleOrDefault(c => c.Id == Id);
                dto.TypeVal = model.TypeVal;
                dto.Reason = model.Reason;
                dto.StartTime = model.StartTime;
                dto.EndTime = model.EndTime;
            }
            dto.TypeHtml = CommonContract.GetDropdownOptionHtml("QJLX");
            return View(dto);
        }

        [Description("工作流-表单事项-访问")]
        public ActionResult Index()
        {
            return View();
        }

        #endregion
    }
}