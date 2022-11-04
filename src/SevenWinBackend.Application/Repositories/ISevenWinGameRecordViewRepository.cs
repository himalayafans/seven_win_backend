using SevenWinBackend.Domain.Entities;

namespace SevenWinBackend.Application.Repositories;

public interface ISevenWinGameRecordViewRepository
{
    /// <summary>
    /// 获取一分钟内的基础游戏记录
    /// </summary>
    /// <returns></returns>
    public Task<SevenWinGameRecordView?> GetBaseGameInOneMinute(ulong discordUserId);

    /// <summary>
    /// 获取1分钟内的附加游戏记录
    /// </summary>
    public Task<List<SevenWinGameRecordView>> GetAdditionalGamesInOneMinute(ulong discordUserId);
}