using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OSky.Web.Mvc.UI;
using OSky.UI.Contracts;
using OSky.Web.Mvc.Security;
using System.ComponentModel;
using OSky.Utility.Extensions;
using OSky.UI.Models.Flow;
using OSky.Core.Data.Extensions;
using OSky.Web.Mvc.Extensions;

namespace OSky.UI.Admin.Areas.Admin.Controllers
{
    [Description("工作流-已办事项")]
    public class FinishController : AdminBaseController
    {
        /// <summary>
        /// 获取或设置 工作流业务对象
        /// </summary>
        public IFlowContract FlowContract { get; set; }

        #region Ajax功能

        #region 获取数据

        [AjaxOnly]
        [Description("工作流-已办事项-列表数据")]
        public ActionResult GridData()
        {
            GridRequest request = new GridRequest(Request);
            var predicate = ExpressionExtensions.True<WorkFlowTask>();
            predicate = predicate.And(c => c.Status >= 10 && c.ReceiverId == Operator.UserId);
            var page = FlowContract.FlowTasks.ToPage(predicate, request.PageCondition, m => new
            {
                m.Id,
                m.FlowItemId,
                m.FlowItem.FlowDesignId,
                m.FlowItem.EntityId,
                m.FlowItem.EntityName,
                m.StepName,
                m.SenderName,
                m.CreatedTime,
                m.Status,
                m.StepDay,
                m.DelayDay,
                m.DelayReason
            });
            return Json(page.ToGridData(), JsonRequestBehavior.AllowGet);

        }

        #endregion

        #endregion

        #region 视图功能

        [Description("工作流-已办事项-列表")]
        public ActionResult Index()
        {
            return View();
        }
        #endregion
    }
}