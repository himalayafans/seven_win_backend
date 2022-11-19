using Discord.WebSocket;
using SevenWinBackend.Application.Data;
using SevenWinBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Services.Data
{
    public class DataService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public DataService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory ?? throw new ArgumentNullException(nameof(unitOfWorkFactory));
        }

        /// <summary>
        /// 同步服务器
        /// </summary>
        private async Task<Guild> SyncGuild(SocketGuild guild, IUnitOfWork work)
        {
            Guild? obj = await work.Guild.GetByDiscordId(guild.Id.ToString());
            if (obj == null)
            {
                obj = Guild.Create(guild.Id.ToString(), guild.Name);
                await work.Guild.Insert(obj);
            }
            if (obj.Name != guild.Name)
            {
                obj.Name = guild.Name;
                await work.Guild.Update(obj);
            }
            return obj;
        }
        /// <summary>
        /// 同步频道
        /// </summary>
        private async Task<Channel> SyncChannel(Guild guild, SocketGuildChannel channel, IUnitOfWork work)
        {
            Channel? obj = await work.Channel.GetByDiscordId(channel.Id.ToString());
            if (obj == null)
            {
                obj = Channel.Create(guild.Id, channel.Id.ToString(), channel.Name);
                await work.Channel.Insert(obj);
            }
            if (obj.Name != channel.Name)
            {
                obj.Name = channel.Name;
                await work.Channel.Update(obj);
            }
            return obj;
        }

        /// <summary>
        /// 填充数据（Discord服务器、频道）
        /// </summary>
        public async Task Fill(DiscordSocketClient client)
        {
            using IUnitOfWork work = unitOfWorkFactory.Create();
            work.BeginTransaction();
            try
            {
                var w = work;
                // 遍历Discord服务器
                foreach (var discordGuild in client.Guilds)
                {
                    Guild guild = await SyncGuild(discordGuild, work);
                    foreach (var channel in discordGuild.Channels)
                    {
                        await SyncChannel(guild, channel, work);
                    }
                }
                work.Commit();
            }
            catch (Exception)
            {
                work.Rollback();
                throw;
            }
        }
    }
}
