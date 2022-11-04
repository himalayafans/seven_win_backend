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
    /// 获取所有出7制胜频道
    /// </summary>
    public Task<List<SevenWinGameChannelView>> GetSevenWinGameChannels()
    {
        using IUnitOfWork work = unitOfWorkFactory.Create();
        return work.SevenWinGameChannelView.GetAllChannels();
    }
}