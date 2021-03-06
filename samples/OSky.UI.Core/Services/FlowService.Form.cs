﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.UI.Models.Flow;
using OSky.Utility.Data;
using OSky.UI.Dtos.Flow;
using OSky.Utility.Extensions;
using System.Security.Claims;
using System.Threading;
using OSky.Core.Exceptions;
using OSky.Utility;

namespace OSky.UI.Services
{
    public partial class FlowService
    {
        #region Implementation of IFlowContract
        /// <summary>
        /// 获取 流程表单数据集
        /// </summary>
        public IQueryable<WorkFlowForm> FlowForms
        {
            get { return FlowFormRepository.Entities; }
        }

        /// <summary>
        /// 添加工作流表单信息
        /// </summary>
        /// <param name="dtos">要添加的表单信息dto</param>
        /// <returns>业务操作结果</returns>
        public OperationResult AddFlowForm(params FlowFormDto[] dtos) 
        {
            return FlowFormRepository.Insert(dtos, dto =>
            {
                if (FlowFormRepository.CheckExists(m => m.FormName == dto.FormName && m.TypeVal == dto.TypeVal))
                {
                    throw new Exception("名称为“{0}”的表单信息已存在，不能重复添加。".FormatWith(dto.FormName));
                }
            });
        }

        /// <summary>
        /// 更新工作流表单信息
        /// </summary>
        /// <param name="dtos">包含更新的表单信息dto</param>
        /// <returns>业务操作结果</returns>
        public OperationResult EditFlowForm(params FlowFormDto[] dtos)
        {
            dtos.CheckNotNull("dtos");
            return FlowFormRepository.Update(dtos);
        }

        /// <summary>
        /// 删除工作流表单信息
        /// </summary>
        /// <param name="ids">工作流表单信息Id集合</param>
        /// <returns>业务操作结果</returns>
        public OperationResult DeleteFlowForm(params Guid[] ids)
        {
            return FlowFormRepository.Delete(ids,
                (entity)=>
                {
                    if (FlowRelateFormRepository.CheckExists(m => m.FlowFormId == entity.Id))
                    {
                        throw new Exception("名称为“{0}”的表单流程已存在，不能删除。".FormatWith(entity.FormName));
                    }
                });
        }
        #endregion

        #region 私有方法
        /// <summary>
        ///  更新 流程设计表单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private OperationResult UpdateWorkFlowForm(Guid id)
        {
            OperationResult result = new OperationResult(OperationResultType.NoChanged, "更新流程设计表单失败！");
            var entity = FlowFormRepository.GetByKey(id);
            entity.EnabledFlow = true;
            FlowFormRepository.Update(entity);
            result = new OperationResult(OperationResultType.Success, "更新 流程设计表单成功！");
            return result;
        }

        #endregion
    }
}
