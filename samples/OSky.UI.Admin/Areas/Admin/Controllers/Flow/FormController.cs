using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.ComponentModel;
using OSky.Web.Mvc.Security;
using OSky.Web.Mvc.UI;
using OSky.Utility.Data;
using OSky.UI.Contracts;
using System.Linq.Expressions;
using OSky.Utility.Filter;
using OSky.UI.Models.Flow;
using OSky.Utility.Extensions;
using OSky.Web.Mvc.Extensions;
using OSky.Utility;
using OSky.UI.Dtos.Flow;

namespace OSky.UI.Admin.Areas.Admin.Controllers
{
    [Description("工作流-表单管理")]
    public class FormController : AdminBaseController
    {
        /// <summary>
        /// 获取或设置 工作流业务对象
        /// </summary>
        public IFlowContract FlowContract { get; set; }

        #region Ajax功能

        #region 获取数据

        [AjaxOnly]
        [Description("工作流-表单数据-列表数据")]
        public ActionResult GridData(string formName)
        {
            GridRequest request = new GridRequest(Request);
            if (!formName.IsNullOrEmpty())
            {
                request.FilterGroup.Rules.Add(new FilterRule("WorkFlowForm.FormName", formName));
            }
            var page = GetPageResult(FlowContract.FlowForms, m => new
            {
                m.Id,
                FlowDesignId = m.FlowRelateForm.FlowDesignId,
                m.FormName,
                m.Type,
                m.CreatorUserName,
                m.CreatedTime,
                m.FilePath,
                m.ActionPath,
                m.EnabledFlow,
                m.Status
            }, request);

            return Json(page.ToGridData(), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 功能方法
        [HttpPost]
        [AjaxOnly]
        [Description("工作流-表单-新增")]
        public ActionResult Add(FlowFormDto[] dtos)
        {
            dtos.CheckNotNull("dtos");
            OperationResult result = FlowContract.AddFlowForm(dtos);
            return Json(result.ToAjaxResult());
        }

        [HttpPost]
        [AjaxOnly]
        [Description("工作流-表单-编辑")]
        public ActionResult Edit(FlowFormDto[] dtos)
        {
            dtos.CheckNotNull("dtos");
            OperationResult result = FlowContract.EditFlowForm(dtos);
            return Json(result.ToAjaxResult());
        }

        //[HttpPost]
        //[AjaxOnly]
        //[Description("工作流-表单-删除")]
        //public ActionResult Delete(int[] ids)
        //{
        //    ids.CheckNotNull("ids");
        //    OperationResult result = FlowContract.DeleteRoles(ids);
        //    return Json(result.ToAjaxResult());
        //}

        #endregion

        #endregion

        #region 视图功能

        #region Overrides of AdminBaseController

        [Description("管理-表单-列表")]
        public override ActionResult Index()
        {
            return base.Index();
        }

        #endregion

        #endregion
    }
}