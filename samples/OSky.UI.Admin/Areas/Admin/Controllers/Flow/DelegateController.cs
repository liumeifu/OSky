using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OSky.UI.Contracts;
using OSky.Web.Mvc.Security;
using OSky.Web.Mvc.Extensions;
using System.ComponentModel;
using OSky.Web.Mvc.UI;
using OSky.Utility.Data;
using OSky.UI.Dtos.Flow;
using OSky.Core.Data.Entity;

namespace OSky.UI.Admin.Areas.Admin.Controllers
{
    [Description("工作流-委托管理")]
    public class DelegateController : AdminBaseController
    {
        /// <summary>
        /// 获取或设置 工作流业务对象
        /// </summary>
        public IFlowContract FlowContract { get; set; }

        #region Ajax功能

        #region 获取数据
        [AjaxOnly]
        [HttpPost]
        [Description("工作流-委托管理-视图数据")]
        public ActionResult GridData()
        {
            GridRequest request = new GridRequest(Request);
            request.AddDefaultSortCondition(new SortCondition("CreatedTime", ListSortDirection.Descending));
            var page = GetPageResult(FlowContract.FlowDelegations,
                m => new
                {
                    m.Id,
                    m.FlowDesignId,
                    m.TrusteeId,
                    FlowName=m.FlowDesign.FlowName,
                    m.CreatorUserName,
                    m.CreatedTime,
                    m.TrusteeName,
                    m.StartTime,
                    m.EndTime,
                    m.Status
                },
                request);
            return Json(page.ToGridData(), JsonRequestBehavior.AllowGet);
        }

        [AjaxOnly]
        [HttpPost]
        [Description("工作流-委托管理-流程数据")]
        public ActionResult ComboData()
        {
            var list = FlowContract.FlowDesigns.Where(c=>c.Status==0).Select(m => new { m.Id, m.FlowName }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 功能方法
        [HttpPost]
        [Description("工作流-委托-添加")]
        public ActionResult Add(FlowDelegateDto[] dtos)
        {
            foreach (var dto in dtos)
            {
                if (dto.Id == Guid.Empty)
                    dto.Id = CombHelper.NewComb();
                dto.CreatorUserName = Operator.Name;
            }
            OperationResult result = FlowContract.AddDelegation(dtos);
            return Json(result.ToAjaxResult());
        }

        [HttpPost]
        [Description("工作流-委托-修改")]
        public ActionResult Edit(FlowDelegateDto[] dtos)
        {
            foreach (var dto in dtos)
            {
                dto.CreatorUserId = Operator.UserId;
                dto.CreatorUserName = Operator.Name;
            }
            OperationResult result = FlowContract.EditDelegation(dtos);
            return Json(result.ToAjaxResult());
        }

        #endregion

        #endregion


        #region 视图功能

        #region Overrides of AdminBaseController

        [Description("管理-委托-列表")]
        public ActionResult Index()
        {
            return View();
        }

        #endregion

        #endregion
    }
}