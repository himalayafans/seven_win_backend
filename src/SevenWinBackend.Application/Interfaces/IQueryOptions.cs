using SevenWinBackend.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Interfaces
{
    /// <summary>
    /// 查询选项
    /// </summary>
    public interface IQueryOptions
    {
        /// <summary>
        /// 当前页
        /// </summary>
        int Page { get; }
        /// <summary>
        /// 每页记录数
        /// </summary>
        int PageSize { get; }
        /// <summary>
        /// 查询类型
        /// </summary>
        string? SearchType { get; }
        /// <summary>
        /// 查询值
        /// </summary>
        string? SearchValue { get; }
        /// <summary>
        /// 是否升序排列
        /// </summary>
        bool? IsSortAscending { get; set; }
        /// <summary>
        /// 排序列
        /// </summary>
        string? SortBy { get; set; }
        /// <summary>
        /// 起始时间（时间戳）
        /// </summary>
        long? StartTime { get; set; }
        /// <summary>
        /// 截至时间（时间戳）
        /// </summary>
        long? EndTime { get; set; }
    }
}
