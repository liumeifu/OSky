﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.UI.Models.Flow;
using OSky.Utility.Data;
using OSky.UI.Dtos.Flow;
using System.Xml;
using com.mxgraph;

namespace OSky.UI.Services
{
    public partial class FlowService
    {
        #region Implementation of IFlowContract
        /// <summary>
        /// 获取 流程设计数据集
        /// </summary>
        public IQueryable<WorkFlowDesign> FlowDesigns
        {
            get { return FlowDesignRepository.Entities; }
        }

        #endregion

        /// <summary>
        /// 保存 流程设计数据
        /// </summary>
        /// <param name="dto">要添加的流程设计Dto</param>
        /// <returns>业务操作结果</returns>
        public OperationResult Save(FlowDesignerDto dto)
        {
            int f = 0;
            OperationResult result = new OperationResult(OperationResultType.NoChanged, "流程修改失败！");
            WorkFlowDesign flow = FlowDesigns.FirstOrDefault(c => c.Id == dto.Id);
            if (flow != null)
                f = 1;
            else
            {
                flow = new WorkFlowDesign();
                flow.Steps = new List<WorkFlowStep>();
                flow.Lines = new List<WorkFlowLine>();
            }
            XmlDocument doc = mxUtils.ParseXml(dto.DesignInfo.Trim());
            flow.Id = dto.Id;
            flow.FlowName = dto.FlowName;
            flow.FlowType = dto.FlowType;
            //添加流程步骤
            AddSteps(doc, dto, flow);
            //添加流程线
            AddLines(doc, dto, flow);

            flow.DesignInfo = doc.InnerXml;

            if (f == 1)
            {
                FlowDesignRepository.Update(flow);
                result = new OperationResult(OperationResultType.Success, "流程修改成功！");
            }
            else
            {
                FlowDesignRepository.UnitOfWork.TransactionEnabled = true;  //事务处理
                FlowDesignRepository.Insert(flow);
                AddFormRelateToFlow(dto);        // 表单流程设置
                UpdateWorkFlowForm(dto.FormId);  // 更新流程设计表单
                
                FlowDesignRepository.UnitOfWork.SaveChanges();
                result = new OperationResult(OperationResultType.Success, "流程添加成功！");
            }
            result.Data = flow.Id;

            return result;
        }

        #region 私有方法
        /// <summary>
        ///  添加 流程步骤
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="dto"></param>
        /// <param name="flow"></param>
        private void AddSteps(XmlDocument doc, FlowDesignerDto dto, WorkFlowDesign flow)
        {
            XmlNodeList steps = doc.DocumentElement.GetElementsByTagName("WorkFlowStep");
            flow.Steps.Clear();
            FlowDesignRepository.Delete(c => c.Id == dto.Id);
            for (int i = 0; i < steps.Count; i++)
            {
                XmlElement step = (XmlElement)steps.Item(i);
                WorkFlowStep flowStep;
                var f = flow.Steps.Any(c => c.Id ==Guid.Parse(step.GetAttribute("Id")));
                if (!f)
                {
                    flowStep = new WorkFlowStep();
                    step.SetAttribute("Id", Guid.NewGuid().ToString());
                }
                else
                    flowStep = flow.Steps.Single(c => c.Id == Guid.Parse(step.GetAttribute("Id")));

                flowStep.Id = Guid.Parse(step.GetAttribute("Id"));
                flowStep.FlowDesignId = dto.Id;
                flowStep.StepId = Int16.Parse(step.GetAttribute("id"));
                flowStep.StepName = step.GetAttribute("StepName");
                flowStep.StepType = Int16.Parse(step.GetAttribute("StepType"));
                flowStep.CountersignType = step.GetAttribute("CountersignType") != "" ? Int16.Parse(step.GetAttribute("CountersignType")) : Int16.Parse("0");
                flowStep.CountersignStrategy = step.GetAttribute("CountersignStrategy") != "" ? Int16.Parse(step.GetAttribute("CountersignStrategy")) : Int16.Parse("0");
                flowStep.CountersignPer = step.GetAttribute("CountersignPer") != "" ? Int16.Parse(step.GetAttribute("CountersignPer")) : Int16.Parse("100");
                flowStep.BackType = step.GetAttribute("BackType") != "" ? Int16.Parse(step.GetAttribute("BackType")) : Int16.Parse("0");
                flowStep.SpecifiedBackStep = step.GetAttribute("SpecifiedBackStep");
                flowStep.SpecifiedDay = step.GetAttribute("SpecifiedDay") != "" ? Int16.Parse(step.GetAttribute("SpecifiedDay")) : Int16.Parse("0");
                flowStep.IsArchives = step.GetAttribute("IsArchives") != "" ? int.Parse(step.GetAttribute("IsArchives")) == 1 : false;
                flowStep.StepDescription = step.GetAttribute("StepDescription");

                if (!f)
                {
                    flow.Steps.Add(flowStep);
                }
            }
        }
        /// <summary>
        /// 添加 流程线
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="dto"></param>
        /// <param name="flow"></param>
        private void AddLines(XmlDocument doc, FlowDesignerDto dto, WorkFlowDesign flow)
        {
            XmlNodeList lines = doc.DocumentElement.GetElementsByTagName("WorkFlowLine");
            flow.Lines.Clear();
            FlowDesignRepository.Delete(c => c.Id == dto.Id);
            for (int i = 0; i < lines.Count; i++)
            {
                XmlElement line = (XmlElement)lines.Item(i);
                WorkFlowLine flowLine;
                var f = flow.Lines.Any(c => c.Id == Guid.Parse(line.GetAttribute("Id")));
                if (!f)
                {
                    flowLine = new WorkFlowLine();
                    line.SetAttribute("Id", Guid.NewGuid().ToString());
                }
                else
                    flowLine = flow.Lines.Single(c => c.Id == Guid.Parse(line.GetAttribute("Id")));

                flowLine.Id = Guid.Parse(line.GetAttribute("Id"));
                flowLine.FlowDesignId = dto.Id;
                XmlNodeList listCell = line.GetElementsByTagName("mxCell");
                if (listCell.Count == 1)
                {
                    flowLine.FromStepId = Int16.Parse(((XmlElement)listCell.Item(0)).GetAttribute("source"));
                    flowLine.FromStepName = flow.Steps.Single(c => c.FlowDesignId == flow.Id && c.StepId == flowLine.FromStepId).StepName;

                    flowLine.ToStepId = Int16.Parse(((XmlElement)listCell.Item(0)).GetAttribute("target"));
                    flowLine.ToStepName = flow.Steps.Single(c => c.FlowDesignId == flow.Id && c.StepId == flowLine.ToStepId).StepName;
                }

                flowLine.CustomMethod = line.GetAttribute("CustomMethod");
                flowLine.Sql = line.GetAttribute("Sql");
                flowLine.HandlerIds = line.GetAttribute("HandlerIds");
                flowLine.HandlerNames = line.GetAttribute("HandlerNames");

                if (!f)
                {
                    flow.Lines.Add(flowLine);
                }

            }
        }

        /// <summary>
        /// 设置表单流程
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        private OperationResult AddFormRelateToFlow(FlowDesignerDto dto)
        {
            OperationResult result = new OperationResult(OperationResultType.NoChanged, "表单流程设置失败！");
            WorkFlowRelateForm model = new WorkFlowRelateForm
            {
                Id = Guid.NewGuid(),
                FlowDesignId = dto.Id,
                FlowFormId = dto.FormId
            };
            FlowRelateFormRepository.Insert(model);
            result = new OperationResult(OperationResultType.Success, "表单流程添加成功！");
            return result;
        }

        #endregion
    }
}
