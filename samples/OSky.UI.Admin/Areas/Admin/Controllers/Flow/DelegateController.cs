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
        #endregion

        #region 功能方法
        [HttpPost]
        [Description("工作流-委托-更新")]
        public ActionResult Save(FlowDelegateDto dto)
        {
            return Json(FlowContract.SaveDelegation(dto).ToAjaxResult());
        }
        #endregion

        #endregion


        #region 视图功能

        [Description("管理-委托-编辑")]
        public ActionResult Edit(Guid Id)
        {
            var dto = new FlowDelegateDto();
            var model = FlowContract.FlowDelegations.FirstOrDefault(c => c.Id == Id);
            if (model != null)
                dto = model.MapTo<FlowDelegateDto>();
            return View("Edit", dto);
        }

        #region Overrides of AdminBaseController

        [Description("管理-委托-列表")]
        public override ActionResult Index()
        {
            return base.Index();
        }

        #endregion

        #endregion
    }
}