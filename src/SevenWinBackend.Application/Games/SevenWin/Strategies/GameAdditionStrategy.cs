using SevenWinBackend.Application.Data;
using SevenWinBackend.Application.Games.SevenWin.Core;
using SevenWinBackend.Application.Services.Data;
using SevenWinBackend.Domain.Entities;
using SevenWinBackend.Domain.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Games.SevenWin.Strategies
{
    /// <summary>
    /// 附加游戏策略
    /// </summary>
    internal class GameAdditionStrategy : BaseStrategy
    {
        public async Task Update(SevenWinScoreDetail scoreDetail, StrategyContext context)
        {
            IUnitOfWorkFactory workFactory = context.GetService<IUnitOfWorkFactory>();
            using var work = workFactory.Create();
            work.BeginTransaction();
            try
            {
                PlayerGame? game = await work.PlayerGame.GetById(context.Cache.PlayerGameId);
                if (game == null)
                {
                    throw new InvalidOperationException();
                }
                game.SetScoreDetail(scoreDetail);
                await work.PlayerGame.Update(game);
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
            PlayerGameService gameService = context.GetService<PlayerGameService>();
            ChannelService channelService = context.GetService<ChannelService>();
            SevenWinRecordService recordService = context.GetService<SevenWinRecordService>();
            SevenWinRecordView? baseRecordView = await recordService.GetBaseGameInOneMinute(context.Cache.PlayerId, context.Cache.GuildId);
            if (baseRecordView == null)
            {
                throw new Exception("请先在基础房间发图");
            }
            if (baseRecordView.DiscordImageId != context.Cache.ImageId)
            {
                throw new Exception("附加房间的截图必须与基础房间的截图一直");
            }
            List<SevenWinRecordView> sevenWinRecords = await recordService.GetAdditionalGamesInOneMinute(context.Cache.PlayerId, context.Cache.GuildId);
            int count = sevenWinRecords.Count;
            if (count < 6)
            {
                context.PlayResult.AddMessage("请继续在其它附加频道上传截图");
            }
            else if (count == 6)
            {
                var game = await gameService.GetPlayerGameById(context.Cache.PlayerId);
                var scoreDetail = game!.GetScoreDetail<SevenWinScoreDetail>();
                var emptyChannelId = scoreDetail.EmptyChannelId;
                // 如果参与的附加频道已存在空房间
                if (sevenWinRecords.Exists(p => p.ChannelId == emptyChannelId))
                {
                    Channel? channel = await channelService.GetById(emptyChannelId);
                    if (channel == null)
                    {
                        // 不可能为空
                        throw new InvalidOperationException();
                    }
                    context.PlayResult.AddMessage($"遇到空频道{channel.Name},祝您下次好运。");
                }
                else
                {
                    int score = scoreDetail.GetSumOfScore();
                    scoreDetail.AdditionalScore = score;
                    await Update(scoreDetail, context);
                    context.PlayResult.TotalScore = scoreDetail.GetSumOfScore();
                    context.PlayResult.AddMessage($"恭喜赢得附加赛，获得{score}个玉米");
                }
            }
            else
            {
                // 大于6无效，由GameCheckStrategy策略检查
                throw new InvalidOperationException();
            }
        }
    }
}
