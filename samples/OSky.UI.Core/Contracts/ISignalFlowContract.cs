using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Dependency;

namespace OSky.UI.Contracts
{
    /// <summary>
    /// 业务契约——实时推送任务模块
    /// </summary>
    public interface ISignalFlowContract : IScopeDependency
    {
        /// <summary>
        /// 向客户端推送 对应接受人的代办任务数量
        /// </summary>
        /// <param name="receiverId">任务接受人Id</param>
        void SendScheduleTaskCount(string receiverId);
    }
}
