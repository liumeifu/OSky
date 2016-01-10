using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.UI.Contracts;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using OSky.Core.Data;
using OSky.UI.Models.Flow;

namespace OSky.UI.Services
{
    /// <summary>
    /// 业务实现——实时推送任务模块
    /// </summary>
    [HubName("SignalFlow")]
    public class SignalFlowService : Hub, ISignalFlowContract
    {
        /// <summary>
        /// 获取或设置 流程任务信息仓储对象
        /// </summary>
        public IRepository<WorkFlowTask, Guid> FlowTaskRepository { protected get; set; }

        /// <summary>
        /// 向客户端推送 对应接受人的代办任务数量
        /// </summary>
        /// <param name="receiverId">任务接受人Id</param>
        public void SendScheduleTaskCount(string receiverId)
        {
            int taskCount = FlowTaskRepository.Entities.Count(c => c.Status <= 2 && c.ReceiverId == receiverId);
            Clients.All.AddTask(taskCount);
        }
    }
}
