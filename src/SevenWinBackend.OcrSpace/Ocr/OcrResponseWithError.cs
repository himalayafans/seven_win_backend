/****************************************
 * ocr.space的API并不规范，有时候ErrorMessage是string类型
 ***************************************/

namespace SevenWinBackend.OcrSpace.Ocr
{
    internal class OcrResponseWithError : OcrResponse
    {
        /// <summary>
        /// 错误信息(即便IsErroredOnProcessing=true时，有时也为空)
        /// </summary>
        public List<string> ErrorMessage { get; set; } = new List<string>();
    }
}
