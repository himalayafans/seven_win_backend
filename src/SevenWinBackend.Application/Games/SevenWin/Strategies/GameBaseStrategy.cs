using System.Globalization;
using SevenWinBackend.Application.Data;
using SevenWinBackend.Application.Games.SevenWin.Core;
using SevenWinBackend.Application.Services.Data;
using SevenWinBackend.Domain.Entities;
using SevenWinBackend.Domain.Game;
using static System.Formats.Asn1.AsnWriter;

namespace SevenWinBackend.Application.Games.SevenWin.Strategies;

/// <summary>
/// 基础游戏价格策略（通过喜币价格计算积分）
/// </summary>
internal class GameBaseStrategy : BaseStrategy
{
    /// <summary>
    /// 获取奖励玉米
    /// </summary>
    private static int GetScore(int count)
    {
        return count switch
        {
            0 => 0,
            1 => 7,
            2 => 77,
            3 => 777,
            4 => 7777,
            5 => 77777,
            6 => 777777,
            7 => 7777777,
            _ => throw new Exception($"规则不支持价格含{count}个7")
        };
    }

    public override async Task Handle(StrategyContext context)
    {
        PlayerGameService recordService = context.GetService<PlayerGameService>();
        IUnitOfWorkFactory workFactory = context.GetService<IUnitOfWorkFactory>();
        if (context.IsBaseGame)
        {
            const int timeScore = 77;
            // ocrResult肯定不为空，因为由CacheInitPolicy策略进行处理
            string price = context.OcrResult!.GetPrice();
            var count = price.ToCharArray().Count(p => p == '7');
            var priceScore = GetScore(count);
            SevenWinScoreDetail detail = SevenWinScoreDetail.Create(price, count, priceScore, true, timeScore, Guid.Empty);
            context.PlayResult.AddMessage($"发帖时间尾数是7，获得{timeScore}个玉米");
            context.PlayResult.AddMessage($"喜币价格{price}包含{count}个7，获得{priceScore}个玉米");
            await recordService.Update(context.Cache.PlayerGameId, detail);
            context.PlayResult.TotalScore = detail.GetSumOfScore();
        }
        else
        {
            await (this.Successor?.Handle(context) ?? Task.CompletedTask);
        }
    }
}