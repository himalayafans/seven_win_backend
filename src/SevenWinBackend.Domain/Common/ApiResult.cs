using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Domain.Common
{
    /// <summary>
    /// AJAX响应结果
    /// </summary>
    public class ApiResult<T>
    {
        /// <summary>
        /// 请求是否成功
        /// </summary>
        public bool Success { get; set; } = true;
        /// <summary>
        /// 消息提示，通常是错误的提示信息
        /// </summary>
        public string Message { get; set; } = "";
        /// <summary>
        /// 响应内容
        /// </summary>
        public T? Content { get; set; }
    }
}
