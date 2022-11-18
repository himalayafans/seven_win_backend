using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Common
{
    public static class FileInfoExtensions
    {
        /// <summary>
        /// 获取文件MD5哈希值
        /// </summary>
        public static string GetMD5HashCode(FileInfo file)
        {
            using (var stream = File.OpenRead(file.FullName))
            {
                return stream.GetMd5HashCode();
            }
        }
        /// <summary>
        /// 读取文件流
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<MemoryStream> ReadMemoryStreamAsync(this FileInfo file)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }
            byte[] bytes = await File.ReadAllBytesAsync(file.FullName);
            return new MemoryStream(bytes);
        }
        /// <summary>
        /// 读取文件的bytes
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<byte[]> ReadAllBytesAsync(this FileInfo file)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }
            return await File.ReadAllBytesAsync(file.FullName);
        }
    }
}
