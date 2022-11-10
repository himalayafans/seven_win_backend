﻿using SevenWinBackend.Application.Data;
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
    public async Task<SevenWinRecordView?> GetBaseGameInOneMinute(string discordUserId)
    {
        if (string.IsNullOrWhiteSpace(discordUserId))
        {
            throw new ArgumentNullException(nameof(discordUserId));
        }
        using var work = unitOfWorkFactory.Create();
        return await work.SevenWinGameRecordView.GetBaseGameInOneMinute(discordUserId);
    }

    /// <summary>
    /// 获取1分钟内的附加游戏记录
    /// </summary>
    public async Task<List<SevenWinRecordView>> GetAdditionalGamesInOneMinute(string discordUserId)
    {
        if (string.IsNullOrWhiteSpace(discordUserId))
        {
            throw new ArgumentNullException(nameof(discordUserId));
        }
        using var work = unitOfWorkFactory.Create();
        return await work.SevenWinGameRecordView.GetAdditionalGamesInOneMinute(discordUserId);
    }
    /// <summary>
    /// 创建未完成的游戏记录
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
        await work.SevenWinGameRecord.Add(record);
        return record;
    }
}