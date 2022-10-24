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
        int Page { get; set; }
        /// <summary>
        /// 每页记录数
        /// </summary>
        int PageSize { get; set; }
        /// <summary>
        /// 查询类型
        /// </summary>
        string? SearchType { get; set; }
        /// <summary>
        /// 查询值
        /// </summary>
        string? SearchValue { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        SortDescriptor? Sort { get; }
    }
}
