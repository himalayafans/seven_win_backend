﻿using SevenWinBackend.Application.Base;
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
    public interface IImageRepository : IRepository<Image>
    {
        /// <summary>
        /// 通过Discord文件哈希值获取图片
        /// </summary>
        Task<Image?> GetByOriginalFileHash(string fileHash);
        /// <summary>
        /// 通过Discord URL获取图片
        /// </summary>
        Task<Image?> GetByDiscordUrl(string discordUrl);
    }
}