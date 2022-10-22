using SevenWinBackend.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Domain.Common
{
    /// <summary>
    /// 排序描述
    /// </summary>
    public sealed class SortDescriptor
    {
        /// <summary>
        /// 排序字段
        /// </summary>
        public string Field { get; set; } = string.Empty;
        /// <summary>
        /// 排序方向
        /// </summary>
        public SortingDirection Direction { get; set; } = SortingDirection.Desc;
    }
}
