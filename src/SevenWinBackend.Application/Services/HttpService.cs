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
        private readonly IHttpClientFactory httpClientFactory;

        public HttpService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<byte[]> DownloadAsBytes(string url)
        {
            var httpClient = httpClientFactory.CreateClient();
            return await httpClient.GetByteArrayAsync(url);
        }

        public async Task<MemoryStream> DownloadAsStream(string url)
        {
            var bytes = await DownloadAsBytes(url);
            return new MemoryStream(bytes);
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        public async Task<FileInfo> DownloadAsFile(string url, DirectoryInfo directory)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException(nameof(url));
            }

            var httpClient = httpClientFactory.CreateClient("HttpClient");
            string extensionName = url.GetFileExtensionFromUrl();
            string fileName = $"{Guid.NewGuid()}.{extensionName.ToLower()}";
            string fullName = Path.Combine(directory.FullName, fileName);
            byte[] bytes = await httpClient.GetByteArrayAsync(url);
            await File.WriteAllBytesAsync(fullName, bytes);
            return new FileInfo(fullName);
        }
    }
}