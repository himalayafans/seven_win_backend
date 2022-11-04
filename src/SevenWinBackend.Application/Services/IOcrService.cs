using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Services
{
    /// <summary>
    /// OCR服务
    /// </summary>
    public interface IOcrService
    {
        /// <summary>
        /// 识别图片文件
        /// </summary>
        public Task<IOcrResult> Parse(FileInfo imageFile);
        /// <summary>
        /// OCR引擎名称
        /// </summary>
        public string GetName();
    }
}
