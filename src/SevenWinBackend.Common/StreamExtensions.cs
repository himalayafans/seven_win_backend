using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Common
{
    public static class StreamExtensions
    {
        /// <summary>
        /// 获取MD5哈希值
        /// </summary>
        public static string GetMd5HashCode(this Stream stream)
        {
            // 代码来源： https://makolyte.com/csharp-get-a-files-checksum-using-any-hashing-algorithm-md5-sha256/
            using var md5 = System.Security.Cryptography.MD5.Create();
            var hash = md5.ComputeHash(stream);
            return BitConverter.ToString(hash).Replace("-", "");
        }
    }
}
