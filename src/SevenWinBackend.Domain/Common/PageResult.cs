using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Domain.Common
{
    /// <summary>
    /// 分页结果
    /// </summary>
    public sealed class PageResult<T> where T : class
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPage { get; }
        /// <summary>
        /// 页总数
        /// </summary>
        public int PageCount { get; }
        /// <summary>
        /// 分页尺寸
        /// </summary>
        public int PageSize { get; }
        /// <summary>
        /// 行总数
        /// </summary>
        public long RowCount { get; }
        /// <summary>
        /// 数据集合
        /// </summary>
        public List<T> Data { get; }

        /// <summary>
        /// 分页结果构造函数
        /// </summary>
        /// <param name="currentPage">当前页</param>
        /// <param name="pageSize">分页尺寸</param>
        /// <param name="rowCount">行总数</param>
        /// <param name="data">数据集合</param>
        public PageResult(int currentPage, int pageSize, long rowCount, List<T> data)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            RowCount = rowCount;
            this.Data = data;
            var pageCount = (double)rowCount / pageSize;
            this.PageCount = (int)Math.Ceiling(pageCount);
        }
    }
}
