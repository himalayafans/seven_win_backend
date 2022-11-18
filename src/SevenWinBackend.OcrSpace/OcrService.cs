using Microsoft.Extensions.Logging;
using SevenWinBackend.Application.Common;
using SevenWinBackend.Application.Services;
using SevenWinBackend.Common;
using SevenWinBackend.Domain.Enums;
using SevenWinBackend.OcrSpace.Ocr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/****************************************
 * OcrSpace是图片识别的服务提供商 https://ocr.space/
 ***************************************/

namespace SevenWinBackend.OcrSpace
{
    public class OcrService : IOcrService
    {
        private readonly OptionSettings _option;
        private const string Api = "https://api.ocr.space/parse/image";
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<OcrService> _logger;

        public OcrService(OptionSettings option, IHttpClientFactory httpClientFactory, ILogger<OcrService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _option = option ?? throw new ArgumentNullException(nameof(option));
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        /// <summary>
        /// 将数据库中的OCR转换成OcrResult对象
        /// </summary>
        /// <exception cref="NotSupportedException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public IOcrResult Convert(OcrEngineType engineType, string ocrText)
        {
            if (engineType != OcrEngineType.OcrSpace)
            {
                throw new NotSupportedException();
            }
            if (string.IsNullOrWhiteSpace(ocrText))
            {
                throw new ArgumentNullException(nameof(ocrText));
            }
            OcrResponse response = JsonHelper.Deserialize<OcrResponse>(ocrText);
            return new OcrResult(response);
        }

        public string GetName()
        {
            return "OcrSpace";
        }

        /// <summary>
        /// 解析JSON，解析失败将抛出异常
        /// </summary>
        private OcrResponse TryParse(string json)
        {
            var responseWithError = JsonHelper.TryParseJson<OcrResponseWithError>(json);
            if (responseWithError != null)
            {
                return responseWithError;
            }
            var response = JsonHelper.TryParseJson<OcrResponse>(json);
            if (response == null)
            {
                _logger.LogError($"JSON解析错误：${json}");
                throw new Exception("JSON解析失败");
            }
            return response;
        }

        private string GetErrorMessage(OcrResponse response)
        {
            var responseWithError = response as OcrResponseWithError;
            if (responseWithError != null && responseWithError.ErrorMessage.Count > 0)
            {
                return responseWithError.ErrorMessage.First();
            }
            else
            {
                return response.ErrorDetails ?? "";
            }
        }

        public async Task<IOcrResult> Parse(MemoryStream imageStream)
        {
            var httpClient = _httpClientFactory.CreateClient();
            //var bytes = await File.ReadAllBytesAsync(imageFile.FullName);
            var bytes = imageStream.ToArray();
            var base64 = "data:image/jpeg;base64," + System.Convert.ToBase64String(bytes);
            var data = new Dictionary<string, string>
                {
                    { "language", "eng" },
                    { "isOverlayRequired", "true" },
                    { "scale", "true" },
                    { "OCREngine", "2" },
                    { "apikey", _option.GetRandomOcrSpaceKey() },
                    { "base64Image", base64 }
                };
            var res = await httpClient.PostAsync(Api, new FormUrlEncodedContent(data));
            var jsonString = await res.Content.ReadAsStringAsync();
            _logger.LogInformation(jsonString);
            var response = TryParse(jsonString);
            if (response.IsErroredOnProcessing)
            {
                throw new Exception(GetErrorMessage(response));
            }
            return new OcrResult(response);
        }
    }
}
