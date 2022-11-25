using SevenWinBackend.Application.Services;
using SevenWinBackend.Common;
using SevenWinBackend.OcrSpace.Ocr;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public string GetText()
        {
            var results = OcrResponse.ParsedResults;
            if (results != null && results.Count > 0)
            {
                return results.First().ParsedText;
            }
            else
            {
                return string.Empty;
            }
        }

        public string GetPrice()
        {
            var parsedResult = OcrResponse.ParsedResults.First();
            Word? titleWord = null;
            Word? priceWord = null;
            var titleLine = parsedResult.TextOverlay.Lines.Find(line =>
            {
                return line.Words.Exists(item =>
                {
                    var text = item.WordText;
                    // 识别“HCN/HDO”，共7个符号
                    // 考虑到最后一个O可能被识别为数字0，或无法识别的问题
                    // 考虑/斜线识别问题
                    //var flag = text.StartsWith("HCN/HD") && text.Length is 6 or 7;
                    // 有时候被识别为HCN/HDOO
                    var flag = text.StartsWith("HCN") && text.Contains("HD") && text.Length <= 8;
                    if (flag)
                    {
                        titleWord = item;
                    }
                    return flag;
                });
            });
            if (titleLine == null || titleWord == null)
            {
                throw new Exception("截图没有包含HCN/HDO文字");
            }

            var priceLine = parsedResult.TextOverlay.Lines.Find(line =>
            {
                var item = line.Words.Find(word =>
                {
                    var text = word.WordText;
                    var flag = text.IsDecimal() && Math.Abs(titleWord.Left - word.Left) < 5;
                    if (flag)
                    {
                        priceWord = word;
                    }
                    return flag;
                });
                return item != null;
            });
            if (priceLine == null || priceWord == null)
            {
                throw new Exception("截图没有包含喜币价格");
            }
            var price = Convert.ToDecimal(priceWord.WordText);
            var priceText = price.ToString(CultureInfo.CurrentCulture);
            return priceText;
        }
    }
}
