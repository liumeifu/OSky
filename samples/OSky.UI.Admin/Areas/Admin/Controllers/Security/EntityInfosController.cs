// -----------------------------------------------------------------------
//  <copyright file="EntityInfosController.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-07-15 2:06</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

using OSky.Core.Caching;
using OSky.Core.Data;
using OSky.Core.Data.Extensions;
using OSky.Core.Security;
using OSky.UI.Contracts;
using OSky.UI.Dtos.Security;
using OSky.Utility;
using OSky.Utility.Data;
using OSky.Utility.Filter;
using OSky.Web.Mvc.Binders;
using OSky.Web.Mvc.Extensions;
using OSky.Web.Mvc.Logging;
using OSky.Web.Mvc.Security;
using OSky.Web.Mvc.UI;


namespace OSky.UI.Admin.Areas.Admin.Controllers
{
    [Description("管理-实体数据")]
    public class EntityInfosController : AdminBaseController
    {
        /// <summary>
        /// 获取或设置 安全业务对象
        /// </summary>
        public ISecurityContract SecurityContract { get; set; }

        #region Ajax功能

        #region 获取数据

        [AjaxOnly]
        [Description("管理-实体数据-列表数据")]
        public ActionResult GridData()
        {
            GridRequest request = new GridRequest(Request);
            if (request.PageCondition.SortConditions.Length == 0)
            {
                request.PageCondition.SortConditions = new[]
                {
                    new SortCondition("ClassName")
                };
            }
            Expression<Func<EntityInfo, bool>> predicate = FilterHelper.GetExpression<EntityInfo>(request.FilterGroup);
            var page = SecurityContract.EntityInfos.ToPageCache(predicate,
                request.PageCondition,
                m => new
                {
                    m.Id,
                    m.Name,
                    m.ClassName,
                    m.DataLogEnabled
                });
            return Json(page.ToGridData(), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 功能方法

        [HttpPost]
        [AjaxOnly]
        [Description("管理-实体数据-编辑")]
        public ActionResult Edit(EntityInfoDto[] dtos)
        {
            dtos.CheckNotNull("dtos");
            OperationResult result = SecurityContract.EditEntityInfos(dtos);
            return Json(result.ToAjaxResult());
        }

        #endregion

        #endregion

        #region 视图功能

        #region Overrides of AdminBaseController

        [Description("管理-实体数据-列表")]
        public override ActionResult Index()
        {
            return base.Index();
        }

        #endregion

        #endregion

    }
}