using SevenWinBackend.Application.Data;
using SevenWinBackend.Domain.Entities;

namespace SevenWinBackend.Application.Services.Data;

/// <summary>
/// 出7制胜游戏数据服务
/// </summary>
public class SevenWinRecordService
{
    private readonly IUnitOfWorkFactory unitOfWorkFactory;

    public SevenWinRecordService(IUnitOfWorkFactory unitOfWorkFactory)
    {
        this.unitOfWorkFactory = unitOfWorkFactory ?? throw new ArgumentNullException(nameof(unitOfWorkFactory));
    }
    public async Task<SevenWinRecord?> GetSevenWinRecordById(Guid id)
    {
        using var work = unitOfWorkFactory.Create();
        return await work.SevenWinRecord.GetById(id);
    }
    /// <summary>
    /// 获取一分钟内的基础游戏记录
    /// </summary>
    public async Task<SevenWinRecordView?> GetBaseGameInOneMinute(Guid playerId, Guid guildId)
    {
        if (playerId == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(playerId));
        }
        if (guildId == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(guildId));
        }
        using var work = unitOfWorkFactory.Create();
        return await work.SevenWinRecordView.GetBaseGameInOneMinute(playerId, guildId);
    }

    /// <summary>
    /// 获取1分钟内的附加游戏记录
    /// </summary>
    public async Task<List<SevenWinRecordView>> GetAdditionalGamesInOneMinute(Guid playerId, Guid guildId)
    {
        if (playerId == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(playerId));
        }
        if (guildId == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(guildId));
        }
        using var work = unitOfWorkFactory.Create();
        return await work.SevenWinRecordView.GetAdditionalGamesInOneMinute(playerId, guildId);
    }
    /// <summary>
    /// 检查基础房间是否存在相同的图片,存在则返回true
    /// </summary>
    public async Task<bool> IsExistSameImageInBaseGame(Guid imageId)
    {
        using var work = unitOfWorkFactory.Create();
        return await work.SevenWinRecordView.IsExistSameImageInBaseGame(imageId);
    }
    /// <summary>
    /// 创建游戏记录
    /// </summary>
    public async Task<SevenWinRecord> AddSevenWinGameRecord(Guid playerGameId, Guid channelId, Guid discordImageId, bool isBase)
    {
        if (playerGameId == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(playerGameId));
        }
        if (channelId == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(channelId));
        }
        if (discordImageId == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(discordImageId));
        }
        using var work = unitOfWorkFactory.Create();
        var record = SevenWinRecord.Create(playerGameId, channelId, discordImageId, isBase);
        await work.SevenWinRecord.Insert(record);
        return record;
    }
}