using Discord.Rest;
using SevenWinBackend.Application.Common;
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
        public Task<MemoryStream> Resize(MemoryStream imageStream, ImageSize maxSize, ImageSize fileSize);
    }
}
