using SevenWinBackend.Application.Data;
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
    /// 获取所有出7制胜频道配置
    /// </summary>
    /// <param name="guildDiscordId">服务器Discord ID</param>
    /// <returns></returns>
    public Task<List<SevenWinConfigView>> GetSevenWinConfigViews(string guildDiscordId)
    {
        using IUnitOfWork work = unitOfWorkFactory.Create();
        return work.SevenWinConfigView.GetConfigViews(guildDiscordId);
    }
}