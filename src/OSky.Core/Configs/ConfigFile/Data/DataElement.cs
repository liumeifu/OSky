// -----------------------------------------------------------------------
//  <copyright file="DataElement.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-06-30 15:41</last-date>
// -----------------------------------------------------------------------

using System.Configuration;


namespace OSky.Core.Configs.ConfigFile
{
    /// <summary>
    /// 数据配置节点
    /// </summary>
    internal class DataElement : ConfigurationElement
    {
        private const string ContextKey = "contexts";

        /// <summary>
        /// 数据上下文配置节点集合
        /// </summary>
        [ConfigurationProperty(ContextKey)]
        public virtual ContextCollection Contexts
        {
            get { return (ContextCollection)base[ContextKey]; }
        }
    }
}