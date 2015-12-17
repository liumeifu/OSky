// -----------------------------------------------------------------------
//  <copyright file="TreeNode.cs" company="">
//      Copyright (c) 2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>最后修改人</last-editor>
//  <last-date>2015-01-09 17:55</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace OSky.UI.Admin.ViewModels
{
    /// <summary>
    /// 树节点
    /// </summary>
    public class TreeNode
    {
        public TreeNode()
        {
            Checked = false;
        }

        public string Id { get; set; }

        public string Text { get; set; }

        public bool Checked { get; set; }

        public int Order { get; set; }

        public string IconCls { get; set; }

        public string Url { get; set; }

        public ICollection<TreeNode> Children { get; set; }
    }
    /// <summary>
    /// 组织结构树
    /// </summary>
    public class OTree
    {
        public int id { get; set; }
        /// <summary>
        /// 父节点Id
        /// </summary>
        public int? pid { get; set; }

        public string text { get; set; }

        public bool Checked { get; set; }

        /// <summary>
        /// 节点状态, 'open' 或者 'closed'
        /// </summary>
        public string state { get; set; }
        /// <summary>
        /// 0 机构 1 人员
        /// </summary>
        public int Type { get; set; }

    }
}