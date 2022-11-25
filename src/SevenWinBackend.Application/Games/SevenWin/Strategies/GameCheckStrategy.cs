using Discord;
using SevenWinBackend.Application.Data;
using SevenWinBackend.Application.Games.SevenWin.Core;
using SevenWinBackend.Application.Services.Data;
using SevenWinBackend.Domain.Entities;
using SevenWinBackend.Domain.Enums;
using SevenWinBackend.Domain.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Games.SevenWin.Strategies
{
    /// <summary>
    /// 游戏检查策略（检查本轮游戏是否完成、图片重复检查、数据库中创建游戏记录）
    /// </summary>
    internal class GameCheckStrategy : BaseStrategy
    {
        private static async Task Save(PlayerGame game, SevenWinRecord record, StrategyContext context)
        {
            IUnitOfWorkFactory unitOfWorkFactory = context.GetService<IUnitOfWorkFactory>();
            using var work = unitOfWorkFactory.Create();
            work.BeginTransaction();
            try
            {
                await work.PlayerGame.Insert(game);
                await work.SevenWinRecord.Insert(record);
                work.Commit();
            }
            catch (Exception)
            {
                work.Rollback();
                throw;
            }
        }
        public override async Task Handle(StrategyContext context)
        {
            SevenWinRecordService recordService = context.GetService<SevenWinRecordService>();
            ChannelService channelService = context.GetService<ChannelService>();
            var baseGame = await recordService.GetBaseGameInOneMinute(context.Cache.PlayerId, context.Cache.GuildId);
            var additionalGames = await recordService.GetAdditionalGamesInOneMinute(context.Cache.PlayerId, context.Cache.GuildId);
            if (additionalGames.Count >= 6)
            {
                context.PlayResult.AddMessage("本轮游戏已完成，请勿重复发图");
                return;
            }
            var channelDiscordId = context.GetChannelDiscordId().ToString();
            var cache = context.Cache;
            var isBaseGame = false;
            var isBaseChannel = context.GuildOption.IsBaseChannel(channelDiscordId);
            if (baseGame == null) // 如果1分钟内没有参加基础游戏
            {
                // 如果本次参与的不是基础频道
                if (!isBaseChannel)
                {
                    throw new Exception("请先在基础房间发图，再参与附加游戏");
                }
                // 如果本次参与的频道是基础频道               
                bool isExist = await recordService.IsExistSameImageInBaseGame(context.Cache.ImageId);  // 检查图片是否重复
                if (isExist)
                {
                    throw new Exception("请勿在基础房间重复上传相同图片");
                }
                // 创建游戏记录              
                string emptyChannelDiscordId = context.GuildOption.GetRandomEmptyRoomDiscordId();
                Channel? emptyChannel = await channelService.GetByDiscordId(emptyChannelDiscordId);
                if (emptyChannel == null)
                {
                    throw new InvalidOperationException();
                }
                SevenWinScoreDetail detail = new SevenWinScoreDetail();
                detail.EmptyChannelId = emptyChannel.Id;
                PlayerGame game = PlayerGame.Create(cache.PlayerId, cache.GuildId, 0, GameTypes.SevenWin, detail);
                SevenWinRecord record = SevenWinRecord.Create(game.Id, cache.ChannelId, cache.ImageId, isBaseGame);
                await Save(game, record, context);
                // 设置缓存
                cache.PlayerGameId = game.Id;
                cache.GameRecordId = record.Id;
                context.IsBaseGame = isBaseGame;
                await (this.Successor?.Handle(context) ?? Task.CompletedTask);
            }
            else // 如果1分钟内已经参加了基础游戏
            {
                // 如果本次参与的频道是基础频道
                if (isBaseChannel)
                {
                    throw new Exception("请勿在规定时间内,在基础房间重复发图");
                }
                if (cache.ImageId != baseGame.DiscordImageId)
                {
                    throw new Exception("附加房间的图片必须与基础房间的图片相同");
                }
                if (additionalGames.Exists(p => p.ChannelId == cache.ChannelId))
                {
                    throw new Exception("请勿在相同的附加频道重复发图");
                }
                isBaseGame = false;
                SevenWinRecord record = await recordService.AddSevenWinGameRecord(baseGame.PlayerGameId, cache.ChannelId, cache.ImageId, isBaseGame);
                cache.PlayerGameId = baseGame.PlayerGameId;
                cache.GameRecordId = record.Id;
                context.IsBaseGame = isBaseGame;
                await (this.Successor?.Handle(context) ?? Task.CompletedTask);
            }
        }
    }
}
