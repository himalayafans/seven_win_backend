using SevenWinBackend.Application.Services;
using SevenWinBackend.OcrSpace.Ocr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.OcrSpace
{
    public class OcrResult : IOcrResult
    {
        internal OcrResponse OcrResponse { get; set; }

        internal OcrResult(OcrResponse ocrResponse)
        {
            OcrResponse = ocrResponse ?? throw new ArgumentNullException(nameof(ocrResponse));
        }

        string IOcrResult.GeMinute()
        {
            throw new NotImplementedException();
        }

        string IOcrResult.GetPrice()
        {
            throw new NotImplementedException();
        }

        string IOcrResult.GetText()
        {
            throw new NotImplementedException();
        }

        bool IOcrResult.IsContainText(string text)
        {
            throw new NotImplementedException();
        }
    }
}
