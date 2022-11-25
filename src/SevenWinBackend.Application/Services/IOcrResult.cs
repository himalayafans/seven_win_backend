using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Services
{
    /// <summary>
    /// OCR识别结果
    /// </summary>
    public interface IOcrResult
    {
        /// <summary>
        /// 获取解析全文
        /// </summary>
        public string GetText();
        /// <summary>
        /// 获取喜币价格
        /// </summary>
        public string GetPrice();
    }
}
