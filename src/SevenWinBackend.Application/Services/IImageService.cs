using Discord.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Services
{
    /// <summary>
    /// 图片服务
    /// </summary>
    public interface IImageService
    {
        /// <summary>
        /// 重设图片的尺寸大小
        /// </summary>
        public Task<FileInfo> Resize(FileInfo imageFile, int maxWidth, int maxHeight);
    }
}
