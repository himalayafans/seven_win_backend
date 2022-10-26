using SevenWinBackend.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Services
{
    /// <summary>
    /// HTTP服务
    /// </summary>
    public class HttpService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }
        /// <summary>
        /// 下载文件
        /// </summary>
        public async Task<FileInfo> Download(string url, DirectoryInfo directory)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException(nameof(url));
            }
            var httpClient = _httpClientFactory.CreateClient();
            string extensionName = url.GetFileExtensionFromUrl();
            string fileName = $"{Guid.NewGuid()}.{extensionName.ToLower()}";
            string fullName = Path.Combine(directory.FullName, fileName);
            byte[] bytes = await httpClient.GetByteArrayAsync(url);
            await File.WriteAllBytesAsync(fullName, bytes);
            return new FileInfo(fullName);
        }
    }
}
