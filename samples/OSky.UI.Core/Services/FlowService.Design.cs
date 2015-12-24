using System;
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
                flow.CreatorUserName = dto.CreatorUserName;
            }
            XmlDocument doc = mxUtils.ParseXml(dto.DesignInfo.Trim());
            flow.Id = dto.Id;
            flow.FlowName = dto.FlowName;
            flow.FlowType = dto.FlowType;
            //添加流程步骤
            AddSteps(doc, dto,ref flow);
            //添加流程线
            AddLines(doc, dto,ref flow);

            flow.DesignInfo = doc.InnerXml;

            FlowDesignRepository.UnitOfWork.TransactionEnabled = true;  //事务处理
            if (f == 1)
            {
                FlowStepRepository.Delete(c => c.FlowDesignId == dto.Id);
                FlowLineRepository.Delete(c => c.FlowDesignId == dto.Id);
                foreach (var item in flow.Steps)
                {
                    FlowStepRepository.Insert(item);
                }
                foreach (var item in flow.Lines)
                {
                    FlowLineRepository.Insert(item);
                }
                FlowDesignRepository.Update(flow);
                result = new OperationResult(OperationResultType.Success, "流程修改成功！");
            }
            else
            {
                FlowDesignRepository.Insert(flow);
                AddFormRelateToFlow(dto);        // 表单流程设置
                UpdateWorkFlowForm(dto.FormId);  // 更新流程设计表单
                
                result = new OperationResult(OperationResultType.Success, "流程添加成功！");
            }
            FlowDesignRepository.UnitOfWork.SaveChanges();
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
        private void AddSteps(XmlDocument doc, FlowDesignerDto dto,ref WorkFlowDesign flow)
        {
            XmlNodeList steps = doc.DocumentElement.GetElementsByTagName("WorkFlowStep");
            flow.Steps.Clear();
            for (int i = 0; i < steps.Count; i++)
            {
                XmlElement step = (XmlElement)steps.Item(i);
                WorkFlowStep flowStep = new WorkFlowStep();
                var id = step.GetAttribute("Id");
                if (string.IsNullOrWhiteSpace(id))
                    step.SetAttribute("Id", CombHelper.NewComb().ToString());

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
                
                flow.Steps.Add(flowStep);
                
            }
        }
        /// <summary>
        /// 添加 流程线
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="dto"></param>
        /// <param name="flow"></param>
        private void AddLines(XmlDocument doc, FlowDesignerDto dto, ref WorkFlowDesign flow)
        {
            XmlNodeList lines = doc.DocumentElement.GetElementsByTagName("WorkFlowLine");
            flow.Lines.Clear();
            for (int i = 0; i < lines.Count; i++)
            {
                XmlElement line = (XmlElement)lines.Item(i);
                WorkFlowLine flowLine = new WorkFlowLine();
                var id= line.GetAttribute("Id");
                if (string.IsNullOrWhiteSpace(id))
                    line.SetAttribute("Id", Guid.NewGuid().ToString());

                flowLine.Id = Guid.Parse(line.GetAttribute("Id"));
                flowLine.FlowDesignId = dto.Id;
                XmlNodeList listCell = line.GetElementsByTagName("mxCell");
                if (listCell.Count == 1)
                {
                    flowLine.FromStepId = Int16.Parse(((XmlElement)listCell.Item(0)).GetAttribute("source"));
                    var fid = flow.Id;
                    flowLine.FromStepName = flow.Steps.ToList().Find(c => c.FlowDesignId == fid && c.StepId == flowLine.FromStepId).StepName;

                    flowLine.ToStepId = Int16.Parse(((XmlElement)listCell.Item(0)).GetAttribute("target"));
                    flowLine.ToStepName = flow.Steps.ToList().Find(c => c.FlowDesignId == fid && c.StepId == flowLine.ToStepId).StepName;
                }

                flowLine.CustomMethod = line.GetAttribute("CustomMethod");
                flowLine.Sql = line.GetAttribute("Sql");
                flowLine.HandlerIds = line.GetAttribute("HandlerIds");
                flowLine.HandlerNames = line.GetAttribute("HandlerNames");
                
                flow.Lines.Add(flowLine);

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
