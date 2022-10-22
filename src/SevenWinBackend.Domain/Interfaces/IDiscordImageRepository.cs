using SevenWinBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Domain.Interfaces
{
    /// <summary>
    /// discord图片储存库
    /// </summary>
    public interface IDiscordImageRepository: IRepository<DiscordImage>
    {
        /// <summary>
        /// 通过Discord文件哈希值获取图片
        /// </summary>
        Task<DiscordImage> GetDiscordFileHash(string fileHash);
    }
}
