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

        #region Ajax功能

        #region 获取数据

        [AjaxOnly]
        [Description("管理-表单事项-节点数据")]
        public ActionResult NodeData()
        {
            var roots = CommonContract.Dictionarys.SingleOrDefault(c => c.Value == "BDLX").Children
                .OrderBy(m => m.SortCode).Select(m => new
                {
                    id = m.Id,
                    pid = m.ParentId,
                    text = m.Name
                }).ToList();
            var forms = (from l in FormContract.Leaves
                         join d in CommonContract.Dictionarys on l.TypeVal equals d.Value
                         select new
                         {
                             id = d.Id,
                             pid = d.ParentId,
                             text = "请假单"
                         }).ToList();
            roots.AddRange(forms);
            return Json(roots, JsonRequestBehavior.AllowGet);

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
            var dto = new LeaveDto { CreatorUserId = Operator.UserId, CreatorUserName = Operator.Name };
            if (Guid.Empty != Id) { 
                var model = FormContract.Leaves.SingleOrDefault(c => c.Id == Id);
                dto.TypeVal = model.TypeVal;
                dto.Reason = model.Reason;
                dto.StartTime = model.StartTime;
                dto.EndTime = model.EndTime;
                dto.TypeHtml = CommonContract.GetDropdownOptionHtml("QJLX");
            }
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