using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.ComponentModel;
using OSky.UI.Contracts;

namespace OSky.UI.Admin.Areas.Admin.Controllers
{
    /// <summary>
    /// 业务实现——实时推送任务模块
    /// </summary>
    [HubName("SignalFlow")]
    [Description("工作流-任务-推送")]
    public class SignalFlowService : Hub
    {
        ///// <summary>
        ///// 获取或设置 工作流业务对象
        ///// </summary>
        //public IFlowContract FlowContract { get; set; }

        ///// <summary>
        ///// 向客户端推送 对应接受人的代办任务数量
        ///// </summary>
        ///// <param name="receiverId">任务接受人Id</param>
        //public void SendScheduleTaskCount(string receiverId)
        //{
        //    int taskCount = FlowContract.FlowTasks.Count(c => c.Status <= 2 && c.ReceiverId == receiverId);
        //    Clients.All.AddTask(taskCount);
        //}
    }
}