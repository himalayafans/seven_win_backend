using SevenWinBackend.Domain.Entities;

namespace SevenWinBackend.Application.Repositories;

public interface ISevenWinRecordViewRepository
{
    /// <summary>
    /// 获取一分钟内的基础游戏记录
    /// </summary>
    /// <returns></returns>
    public Task<SevenWinRecordView?> GetBaseGameInOneMinute(string discordUserId);

    /// <summary>
    /// 获取1分钟内的附加游戏记录
    /// </summary>
    public Task<List<SevenWinRecordView>> GetAdditionalGamesInOneMinute(string discordUserId);
}