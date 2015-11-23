using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.ComponentModel;
using OSky.UI.Contracts;
using OSky.Web.Mvc.Security;
using OSky.UI.Dtos.Flow;

namespace OSky.UI.Admin.Areas.Admin.Controllers
{
    public class FlowDesignerController : AdminBaseController
    {
        /// <summary>
        /// 获取或设置 工作流业务对象
        /// </summary>
        public IFlowContract FlowContract { get; set; }

        #region Ajax功能

        #region 获取数据
        [AjaxOnly]
        [HttpPost]
        [Description("工作流-流程设计-视图数据")]
        public ActionResult GridData(Guid Id, Guid FormId)
        {
            if(Id==Guid.Empty)
                return Json(new FlowDesignerDto{FormId = FormId});
            var dto = FlowContract.FlowDesigns.Where(c => c.Id == Id).Select(c => new FlowDesignerDto
            {
                Id = c.Id,
                FormId = FormId,
                FlowType = c.FlowType,
                FlowName = c.FlowName,
                DesignInfo = c.DesignInfo
            }).FirstOrDefault();

            return Json(dto);
        }
        #endregion

        #region 功能方法
        /// <summary>
        /// 流程设计-保存
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("工作流-表单-新增")]
        public ActionResult Save(FlowDesignerDto dto)
        {
            if (dto.Id==Guid.Empty)
            {
                dto.Id = Guid.NewGuid();
            }
            return Json(FlowContract.Save(dto));
        }
        #endregion

        #endregion

        #region 视图功能
        #region Overrides of AdminBaseController

        [Description("管理-流程-列表")]
        public ActionResult Index()
        {
            return View("Index", new FlowDesignerDto());
        }

        #endregion

        #endregion
    }
}