// -----------------------------------------------------------------------
//  <copyright file="OSharpContext.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-07-28 0:41</last-date>
// -----------------------------------------------------------------------

using System;

using OSky.Core.Dependency;
using OSky.Core.Properties;


namespace OSky.Core.Context
{
    /// <summary>
    /// OSky上下文，存储OSky全局配置信息
    /// </summary>
    public static class OSharpContext
    {
        private static IServiceCollection _iocRegisterServices;

        /// <summary>
        /// 获取 依赖注入注册映射信息集合
        /// </summary>
        public static IServiceCollection IocRegisterServices
        {
            get
            {
                if (_iocRegisterServices == null)
                {
                    throw new InvalidOperationException(Resources.Context_BuildServicesFirst);
                }
                return _iocRegisterServices;
            }
            internal set { _iocRegisterServices = value; }
        }
    }
}