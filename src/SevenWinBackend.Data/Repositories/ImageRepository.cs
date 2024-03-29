﻿using PetaPoco;
using SevenWinBackend.Application.Repositories;
using SevenWinBackend.Data.Base;
using SevenWinBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Data.Repositories
{
    internal class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        public ImageRepository(IDatabase db) : base(db)
        {
        }

        public async Task<Image?> GetByDiscordUrl(string discordUrl)
        {
            if (string.IsNullOrWhiteSpace(discordUrl))
            {
                throw new ArgumentNullException(nameof(discordUrl));
            }
            string sql = "select * from image where discord_url=@DiscordUrl;";
            return await this.Db.SingleOrDefaultAsync<Image>(sql);
        }

        public async Task<Image?> GetByOriginalFileHash(string fileHash)
        {
            if (string.IsNullOrWhiteSpace(fileHash))
            {
                throw new ArgumentNullException(nameof(fileHash));
            }
            string sql = "SELECT * FROM image WHERE discord_file_hash=@Hash;";
            return await this.Db.SingleOrDefaultAsync<Image?>(sql, new { Hash = fileHash });
        }

    }
}
