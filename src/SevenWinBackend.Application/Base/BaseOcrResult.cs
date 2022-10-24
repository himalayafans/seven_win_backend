using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Base
{
    /// <summary>
    /// OCR识别结果
    /// </summary>
    public abstract class BaseOcrResult
    {
        /// <summary>
        /// 解析文本
        /// </summary>
        public string Text { get; } = string.Empty;
        /// <summary>
        /// 价格
        /// </summary>
        public string Price { get; } = string.Empty;
        /// <summary>
        /// 时间
        /// </summary>
        public string Time { get; } = string.Empty;
        /// <summary>
        /// 是否包含时间
        /// </summary>
        public bool IsIncludeTime { get; set; } = false;
    }
}
