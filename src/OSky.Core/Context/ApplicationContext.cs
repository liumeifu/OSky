using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Remoting.Messaging;

namespace OSky.Core.Context
{
    /// <summary>
    /// 应用程序数据管理 基于[CallContext]上下文 支持多线程之间数据交换
    /// </summary>
    public class ApplicationContext : Dictionary<string, object>, ILogicalThreadAffinative
    {
        public const string ContextKey = "OSky.ApplicationContexts.ApplicationContext";
        public const string OperatorKey = "OSky.ApplicationContexts.ApplicationContext.Operator";

        /// <summary>
        /// 获取或设置 当前会话上下文
        /// </summary>
        public static ApplicationContext Current 
        {
            get
            {
                if (null == CallContext.GetData(ContextKey))
                {
                    CallContext.SetData(ContextKey, new ApplicationContext());
                }
                return CallContext.GetData(ContextKey) as ApplicationContext;
            }
        }

        /// <summary>
        /// 获取 当前操作者信息类
        /// </summary>
        public Operator Operator
        {
            get
            {
                if (!ContainsKey(OperatorKey))
                {
                    this[OperatorKey] = new Operator();
                }
                return this[OperatorKey] as Operator;
            }
        }

    }
}
