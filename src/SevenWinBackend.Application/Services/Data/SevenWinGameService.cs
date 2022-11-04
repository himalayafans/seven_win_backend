using SevenWinBackend.Application.Data;
using SevenWinBackend.Domain.Entities;

namespace SevenWinBackend.Application.Services.Data;

/// <summary>
/// 出7制胜游戏数据服务
/// </summary>
public class SevenWinGameService
{
    private readonly IUnitOfWorkFactory unitOfWorkFactory;

    public SevenWinGameService(IUnitOfWorkFactory unitOfWorkFactory)
    {
        this.unitOfWorkFactory = unitOfWorkFactory ?? throw new ArgumentNullException(nameof(unitOfWorkFactory));
    }
    /// <summary>
    /// 获取一分钟内的基础游戏记录
    /// </summary>
    public async Task<SevenWinGameRecordView?> GetBaseGameInOneMinute(ulong discordUserId)
    {
        using var work = unitOfWorkFactory.Create();
        return await work.SevenWinGameRecordView.GetBaseGameInOneMinute(discordUserId);
    }

    /// <summary>
    /// 获取1分钟内的附加游戏记录
    /// </summary>
    public async Task<List<SevenWinGameRecordView>> GetAdditionalGamesInOneMinute(ulong discordUserId)
    {
        using var work = unitOfWorkFactory.Create();
        return await work.SevenWinGameRecordView.GetAdditionalGamesInOneMinute(discordUserId);
    }
    public async Task<SevenWinGameRecord> AddSevenWinGameRecord(Guid playerGameId, Guid channelId, Guid discordImageId)
    {
        using var work = unitOfWorkFactory.Create();
        var record = new SevenWinGameRecord(playerGameId, channelId, discordImageId);
        await work.SevenWinGameRecord.Add(record);
        return record;
    }
}