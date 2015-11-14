
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.UI.Contracts;
using OSky.UI.Models.Flow;
using OSky.Core.Data;

namespace OSky.UI.Services
{
    /// <summary>
    /// 业务实现——工作流模块
    /// </summary>
    public partial class FlowService : IFlowContract
    {
        /// <summary>
        /// 获取或设置 流程设计信息仓储操作对象
        /// </summary>
        public IRepository<WorkFlowDesign, Guid> FlowDesignRepository { protected get; set; }

        /// <summary>
        /// 获取或设置 流程步骤信息仓储对象
        /// </summary>
        public IRepository<WorkFlowStep, Guid> FlowStepRepository { protected get; set; }

        /// <summary>
        /// 获取或设置 流程线信息仓储对象
        /// </summary>
        public IRepository<WorkFlowLine, Guid> FlowLineRepository { protected get; set; }
        /// <summary>
        /// 获取或设置 流程项信息仓储操作对象
        /// </summary>
        public IRepository<WorkFlowItem, Guid> FlowItemRepository { protected get; set; }

        /// <summary>
        /// 获取或设置 流程任务信息仓储对象
        /// </summary>
        public IRepository<WorkFlowTask, Guid> FlowTaskRepository { protected get; set; }

        /// <summary>
        /// 获取或设置 流程委托信息仓储对象
        /// </summary>
        public IRepository<WorkFlowDelegation, Guid> FlowDelegationRepository { protected get; set; }

        /// <summary>
        /// 获取或设置 流程归档仓储对象
        /// </summary>
        public IRepository<WorkFlowArchive, Guid> FlowArchiveRepository { protected get; set; }

        /// <summary>
        /// 获取或设置 流程表单信息仓储对象
        /// </summary>
        public IRepository<WorkFlowForm, Guid> FlowFormRepository { protected get; set; }

        /// <summary>
        /// 获取或设置 流程表单关联仓储对象
        /// </summary>
        public IRepository<WorkFlowRelateForm, Guid> FlowRelateFormRepository { protected get; set; }
    }
}
