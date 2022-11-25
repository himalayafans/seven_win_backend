using SevenWinBackend.Domain.Entities;

namespace SevenWinBackend.Application.Repositories;

public interface ISevenWinRecordViewRepository
{
    /// <summary>
    /// 获取一分钟内的基础游戏记录
    /// </summary>
    /// <returns></returns>
    public Task<SevenWinRecordView?> GetBaseGameInOneMinute(Guid playerId, Guid guildId);

    /// <summary>
    /// 获取1分钟内的附加游戏记录
    /// </summary>
    public Task<List<SevenWinRecordView>> GetAdditionalGamesInOneMinute(Guid playerId, Guid guildId);
    /// <summary>
    /// 基础频道中是否存在相同的图片
    /// </summary>
    public Task<bool> IsExistSameImageInBaseGame(Guid imageId);
}