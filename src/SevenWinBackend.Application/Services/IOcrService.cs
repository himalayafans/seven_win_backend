using SevenWinBackend.Domain.Enums;
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
        /// 识别图片文件(解析失败则抛出异常)
        /// </summary>
        public Task<IOcrResult> Parse(MemoryStream imageStream);
        /// <summary>
        /// OCR引擎名称
        /// </summary>
        public string GetName();
        /// <summary>
        /// 字符串转换为IOcrResult对象
        /// </summary>
        public IOcrResult Convert(OcrEngineType engineType, string ocrText);
        /// <summary>
        /// IOcrResult对象转换成字符串
        /// </summary>
        public string Convert(IOcrResult ocrResult);
    }
}