using SevenWinBackend.Application.Base;
using SevenWinBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Repositories
{
    /// <summary>
    /// discord图片储存库
    /// </summary>
    public interface IDiscordImageRepository : IRepository<Image>
    {
        /// <summary>
        /// 通过Discord文件哈希值获取图片
        /// </summary>
        Task<Image> GetOriginalFileHash(string fileHash);
    }
}