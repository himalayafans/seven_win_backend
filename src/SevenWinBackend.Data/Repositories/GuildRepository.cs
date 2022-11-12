using PetaPoco;
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
    internal class GuildRepository : BaseRepository<Guild>, IGuildRepository
    {
        public GuildRepository(IDatabase db) : base(db)
        {
        }

        public override async Task Insert(Guild entity)
        {
            Guild? guild = await this.GetByDiscordId(entity.DiscordId);
            if (guild != null)
            {
                throw new Exception("该服务器已存在");
            }
            await base.Insert(entity);
        }

        public async Task<Guild?> GetByDiscordId(string discordId)
        {
            if (string.IsNullOrWhiteSpace(discordId))
            {
                throw new ArgumentNullException(nameof(discordId));
            }
            string sql = "select * from guild where discord_id=@DiscordId;";
            return await this.Db.SingleOrDefaultAsync<Guild?>(sql, new { DiscordId = discordId });
        }
    }
}
