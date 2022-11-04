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
    }
}
