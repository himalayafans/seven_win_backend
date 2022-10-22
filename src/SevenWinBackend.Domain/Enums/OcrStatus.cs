using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Domain.Enums
{
    /// <summary>
    /// 图片Ocr状态
    /// </summary>
    public enum OcrStatus
    {
        /// <summary>
        /// 未做识别
        /// </summary>
        None,
        /// <summary>
        /// 识别成功(只表示图片已识别为文字，并不表示完全准确)
        /// </summary>
        Success,
        /// <summary>
        /// 识别错误
        /// </summary>
        Error
    }
}