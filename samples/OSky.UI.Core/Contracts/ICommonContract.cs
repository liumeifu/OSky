using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Dependency;
using OSky.Utility.Data;
using System.Linq.Expressions;
using OSky.UI.Models.Infos;
using OSky.UI.Dtos.Infos;

namespace OSky.UI.Contracts
{
    /// <summary>
    /// 业务契约——基础模块
    /// </summary>
    public interface ICommonContract : IScopeDependency
    {
        #region 数据字典

        /// <summary>
        /// 获取 数据字典信息查询数据集
        /// </summary>
        IQueryable<Dictionary> Dictionarys { get; }

        /// <summary>
        /// 获取 指定字典值 的所有子集的Option
        /// </summary>
        /// <param name="val">字典值</param>
        /// <returns>拼接的optin字符串</returns>
        string GetDropdownOptionHtml(string val);

        /// <summary>
        /// 检查数据字典信息信息是否存在
        /// </summary>
        /// <param name="predicate">检查谓语表达式</param>
        /// <param name="id">更新的数据字典信息编号</param>
        /// <returns>数据字典信息是否存在</returns>
        bool CheckDictionaryExists(Expression<Func<Dictionary, bool>> predicate, int id = 0);

        /// <summary>
        /// 添加数据字典信息信息
        /// </summary>
        /// <param name="dtos">要添加的数据字典信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        OperationResult AddDictionarys(params DictionaryDto[] dtos);

        /// <summary>
        /// 更新数据字典信息信息
        /// </summary>
        /// <param name="dtos">包含更新信息的数据字典信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        OperationResult EditDictionarys(params DictionaryDto[] dtos);

        /// <summary>
        /// 删除数据字典信息信息
        /// </summary>
        /// <param name="ids">要删除的数据字典信息编号</param>
        /// <returns>业务操作结果</returns>
        OperationResult DeleteDictionarys(params int[] ids);

        #endregion
    }
}
