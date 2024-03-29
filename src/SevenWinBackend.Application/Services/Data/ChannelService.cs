﻿using SevenWinBackend.Application.Data;
using SevenWinBackend.Domain.Entities;

namespace SevenWinBackend.Application.Services.Data;

public class ChannelService
{
    private readonly IUnitOfWorkFactory unitOfWorkFactory;

    public ChannelService(IUnitOfWorkFactory unitOfWorkFactory)
    {
        this.unitOfWorkFactory = unitOfWorkFactory ?? throw new ArgumentNullException(nameof(unitOfWorkFactory));
    }
    /// <summary>
    /// 通过Discord ID获取频道
    /// </summary>
    public async Task<Channel?> GetByDiscordId(string channelDiscordId)
    {
        using var work = unitOfWorkFactory.Create();
        return await work.Channel.GetByDiscordId(channelDiscordId);
    }
    public async Task<Channel?> GetById(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(id));
        }
        using var work = unitOfWorkFactory.Create();
        return await work.Channel.GetById(id);
    }
}