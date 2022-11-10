using SevenWinBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SevenWinBackend.Application.Exceptions;
using SevenWinBackend.Application.Services.Data;
using SevenWinBackend.Application.Games.SevenWin.Core;

namespace SevenWinBackend.Application.Games.SevenWin.Strategies
{
    /// <summary>
    /// 频道检查策略
    /// </summary>
    internal class CheckChannelPolicy : BaseStrategy
    {
        public override async Task Handle(StrategyContext context)
        {
            var services = context.ServiceProvider;
            string userDiscordId = context.SocketUserMessage.Author.Id.ToString();
            string channelDiscordId = context.SocketUserMessage.Channel.Id.ToString();
            string guildId = context.GetGuildDiscordId().ToString();
            // 设置上下文缓存
            ChannelService channelService = services.GetRequiredService<ChannelService>();
            List<SevenWinConfigView> channelViews = await channelService.GetSevenWinConfigViews(guildId);
            context.Cache.Channels = channelViews;
            SevenWinConfigView? channelView = channelViews.FirstOrDefault(p => p.ChanneDiscordId == channelDiscordId);
            //检查是否是参与游戏的频道
            if (channelView != null) // 是
            {
                context.Cache.ChannelId = channelView.Id;
                await (Successor?.Handle(context) ?? Task.CompletedTask);
            }


            // TODO: 待删除
            //检查是否是参与游戏的频道，不是则忽略消息
            if (channelViews.Exists(p => p.ChanneDiscordId == userDiscordId.ToString()))
            {
                // 获取基础游戏记录
                SevenWinGameService sevenWinGameService = services.GetRequiredService<SevenWinGameService>();
                // 用户在一分钟内参与的基础游戏
                var baseGameRecord = await sevenWinGameService.GetBaseGameInOneMinute(userDiscordId);
                // 基础游戏频道
                var baseChannel = channelViews.FirstOrDefault(p => p.IsBase);
                if (baseChannel == null)
                {
                    throw new AppException("系统未设置基础游戏频道，请联系管理员");
                }
                if (baseGameRecord == null)   // 如果用户在一分钟内没有参与基础游戏
                {
                    // 如果用户当前游戏频道是基础频道
                    if (baseChannel.ChanneDiscordId == channelDiscordId.ToString())
                    {
                        // 用户在规定时间内首次参与基础游戏
                        await (Successor?.Handle(context) ?? Task.CompletedTask);
                    }
                    else
                    {
                        // 用户参与的是附加游戏，但没有参与基础游戏
                        context.PlayResult.AddMessage("请先参与基础游戏，才能参与附加游戏");
                    }
                }
                else   // 如果用户在一分钟内参与过基础游戏
                {
                    if (baseChannel.ChanneDiscordId == channelDiscordId) // 如果参与的频道是基础游戏频道
                    {
                        context.PlayResult.AddMessage("请勿在规定时间内重复参与基础游戏");
                    }
                    else // // 如果参与的频道是附加游戏频道
                    {
                        // 用户在1分钟内参与的附加游戏频道
                        var list = await sevenWinGameService.GetAdditionalGamesInOneMinute(userDiscordId);
                        if (list.Count >= 6) //如果用户已参与了6个附加频道
                        {
                            context.PlayResult.AddMessage("您已完成本轮游戏，请勿重复发帖");
                        }
                        else //  //如果用户参与的附加频道未满6个
                        {
                            if (list.Exists(p => p.ChannelDiscordId == channelDiscordId))
                            {
                                context.PlayResult.AddMessage("请勿在在相同的附加频道中多次参与游戏");
                            }
                            else
                            {
                                await (Successor?.Handle(context) ?? Task.CompletedTask);
                            }
                        }
                    }
                }
            }
        }
    }
}