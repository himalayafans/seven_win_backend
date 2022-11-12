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
        /// 填充数据（Discord服务器、频道）
        /// </summary>
        public async Task Fill(DiscordSocketClient client)
        {
            using IUnitOfWork work = unitOfWorkFactory.Create();
            work.BeginTransaction();
            try
            {
                var w = work;
                foreach (var discordGuild in client.Guilds)
                {
                    Guild? guild = await work.Guild.GetByDiscordId(discordGuild.Id.ToString());
                    if (guild == null)
                    {
                        // 如果服务器不存在，则插入到数据库
                        guild = Guild.Create(discordGuild.Id.ToString(), discordGuild.Name);
                    }
                    else
                    {
                        // 同步服务器名称
                        if (guild.Name != discordGuild.Name)
                        {
                            guild.Name = discordGuild.Name;
                            await work.Guild.Update(guild);
                        }
                    }
                    List<Channel> channels = await work.Channel.GetAll();
                    foreach (var discordChannel in discordGuild.Channels)
                    {
                        var channel = await work.Channel.GetByDiscordId(discordChannel.Id.ToString());
                        if (channel == null)
                        {
                            // 如果频道不存在，则插入数据库
                            await work.Channel.Insert(Channel.Create(guild.Id, discordGuild.Id.ToString(), discordChannel.Name));
                        }
                        else
                        {
                            //同步频道名称
                            if (channel.Name != discordChannel.Name)
                            {
                                channel.Name = discordChannel.Name;
                                await work.Channel.Update(channel);
                            }
                        }
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
