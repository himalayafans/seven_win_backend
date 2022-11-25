using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Services
{
    /// <summary>
    /// 文件服务
    /// </summary>
    public class FileService
    {
        public async Task Write(MemoryStream stream, FileInfo file)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }
            byte[] buffer = stream.ToArray();
            await File.WriteAllBytesAsync(file.FullName, buffer);
        }
    }
}

