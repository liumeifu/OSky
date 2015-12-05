// -----------------------------------------------------------------------
//  <copyright file="AdminBaseController.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-08-28 15:30</last-date>
// -----------------------------------------------------------------------

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

using OSky.Core.Data;
using OSky.Core.Data.Extensions;
using OSky.Utility.Filter;
using OSky.Web.Mvc;
using OSky.Web.Mvc.Logging;
using OSky.Web.Mvc.UI;
using OSky.Core.Context;
using OSky.Web.Mvc.Extensions;


namespace OSky.UI.Admin.Areas.Admin.Controllers
{
    /// <summary>
    /// 后台管理控制器蕨类
    /// </summary>
    [Authorize]
    [OperateLogFilter]
    public abstract class AdminBaseController : BaseController
    {
        protected virtual IQueryable<TEntity> GetQueryData<TEntity, TKey>(IQueryable<TEntity> source, out int total, GridRequest request = null)
            where TEntity : EntityBase<TKey>
        {
            if (request == null)
            {
                request = new GridRequest(Request);
            }
            Expression<Func<TEntity, bool>> predicate = FilterHelper.GetExpression<TEntity>(request.FilterGroup);
            return source.Where(predicate, request.PageCondition, out total);
        }

        protected virtual PageResult<TResult> GetPageResult<TEntity, TResult>(IQueryable<TEntity> source,
            Expression<Func<TEntity, TResult>> selector,
            GridRequest request = null)
        {
            if (request == null)
            {
                request = new GridRequest(Request);
            }
            Expression<Func<TEntity, bool>> predicate = FilterHelper.GetExpression<TEntity>(request.FilterGroup);
            return source.ToPage(predicate, request.PageCondition, selector);
        }

        /// <summary>
        /// 获取 当前操作者信息类
        /// </summary>
        protected Operator Operator
        { 
            get
            {
                if (ApplicationContext.Current[ApplicationContext.OperatorKey] == null)
                {
                    ApplicationContext.Current[ApplicationContext.OperatorKey] = OperatorHelper.GetOperator(HttpContext);
                }
                return ApplicationContext.Current[ApplicationContext.OperatorKey] as Operator;
            }
        }
    }
}