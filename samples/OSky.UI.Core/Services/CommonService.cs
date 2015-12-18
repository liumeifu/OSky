using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.UI.Contracts;
using OSky.UI.Models.Infos;
using OSky.Core.Data;
using System.Linq.Expressions;
using OSky.UI.Dtos.Infos;
using OSky.Utility.Data;
using OSky.Utility;
using OSky.Utility.Extensions;

namespace OSky.UI.Services
{
    /// <summary>
    /// 业务实现——基础模块
    /// </summary>
    public partial class CommonService : ICommonContract
    {
        #region 数据字典
        /// <summary>
        /// 获取或设置 数据字典信息仓储操作对象
        /// </summary>
        public IRepository<Dictionary, int> DictionaryRepository { protected get; set; }
        /// <summary>
        /// 获取 数据字典信息查询数据集
        /// </summary>
        public IQueryable<Dictionary> Dictionarys
        {
            get { return DictionaryRepository.Entities; }
        }

        /// <summary>
        /// 获取 指定字典值 的所有子集的Option
        /// </summary>
        /// <param name="val">字典值</param>
        /// <returns>拼接的optin字符串</returns>
        public string GetDropdownOptionHtml(string val)
        {
            string optstr = "";
            var parent = DictionaryRepository.Entities.SingleOrDefault(c => c.Value == val);
            foreach (var item in parent.Children)
            {
                optstr += "<option value=\"" + item.Value + "\">"+item.Name+"</option>";
            }
            return optstr;
        }
        /// <summary>
        /// 检查数据字典信息信息是否存在
        /// </summary>
        /// <param name="predicate">检查谓语表达式</param>
        /// <param name="id">更新的数据字典信息编号</param>
        /// <returns>数据字典信息是否存在</returns>
        public bool CheckDictionaryExists(Expression<Func<Dictionary, bool>> predicate, int id = 0)
        {
            return DictionaryRepository.CheckExists(predicate, id);
        }

        /// <summary>
        /// 添加数据字典信息信息
        /// </summary>
        /// <param name="dtos">要添加的数据字典信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        public OperationResult AddDictionarys(params DictionaryDto[] dtos)
        {
            dtos.CheckNotNull("dtos");
            OperationResult result = DictionaryRepository.Insert(dtos,
                dto =>
                {
                    if (DictionaryRepository.CheckExists(m => m.Value==dto.Value))
                    {
                        throw new Exception("值为“{0}”的数据字典已存在，不能重复添加。".FormatWith(dto.Value));
                    }
                },
                (dto, entity) => 
                {
                    if (dto.ParentId.HasValue && dto.ParentId.Value > 0)
                    {
                        Dictionary parent = DictionaryRepository.GetByKey(dto.ParentId.Value);
                        if (parent == null)
                        {
                            throw new Exception("指定父数据字典不存在。");
                        }
                        entity.Parent = parent;
                    }
                    return entity;

                });
            return result;
        }

        /// <summary>
        /// 更新数据字典信息信息
        /// </summary>
        /// <param name="dtos">包含更新信息的数据字典信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        public OperationResult EditDictionarys(params DictionaryDto[] dtos)
        {
            dtos.CheckNotNull("dtos");
            OperationResult result = DictionaryRepository.Update(dtos,
                dto =>
                {
                    if (DictionaryRepository.CheckExists(m => m.Value == dto.Value))
                    {
                        throw new Exception("值为“{0}”的数据字典已存在，不能重复添加。".FormatWith(dto.Value));
                    }
                }, 
                (dto, entity) =>
                {
                    if (!dto.ParentId.HasValue || dto.ParentId == 0)
                    {
                        entity.Parent = null;
                    }
                    else if (entity.Parent != null && entity.Parent.Id != dto.ParentId)
                    {
                        Dictionary parent = DictionaryRepository.GetByKey(dto.ParentId.Value);
                        if (parent == null)
                        {
                            throw new Exception("指定父数据字典不存在。");
                        }
                        entity.Parent = parent;
                    }
                    return entity;
                });
            return result;
        }

        /// <summary>
        /// 删除数据字典信息信息
        /// </summary>
        /// <param name="ids">要删除的数据字典信息编号</param>
        /// <returns>业务操作结果</returns>
        public OperationResult DeleteDictionarys(params int[] ids)
        {
            ids.CheckNotNull("ids");
            OperationResult result = DictionaryRepository.Delete(ids,
                entity =>
                {
                    if (entity.Children.Any())
                    {
                        throw new Exception("数据字典“{0}”的子级不为空，不能删除。".FormatWith(entity.Name));
                    }
                });
            return result;
        }

        #endregion

    }
}
