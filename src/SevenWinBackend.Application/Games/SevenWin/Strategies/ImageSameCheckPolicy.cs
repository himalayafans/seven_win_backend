using Microsoft.Extensions.DependencyInjection;
using SevenWinBackend.Application.Games.SevenWin.Core;
using SevenWinBackend.Application.Services.Data;
using SevenWinBackend.Domain.Entities;

namespace SevenWinBackend.Application.Games.SevenWin.Strategies;

/// <summary>
/// 图片是否重复检查策略(检查)
/// </summary>
internal class ImageSameCheckPolicy : BaseStrategy
{
    public override async Task Handle(StrategyContext context)
    {
        ImageService imageService = context.ServiceProvider.GetRequiredService<ImageService>();
        Image? discordImage = await imageService.GetWithOriginalFileHash(context.DiscordImageInfo.Hash);
        if(discordImage == null)  // 如果是新图，则继续下一步
        {           
            await (this.Successor?.Handle(context) ?? Task.CompletedTask);
        }
        else
        {
            throw new NotImplementedException();
        }
    }
}