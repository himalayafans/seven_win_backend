using SevenWinBackend.Domain.Interfaces;

namespace SevenWinBackend.Domain.Game;

//TODO 待规则成熟后需完善该该类

/// <summary>
/// 7个房间竞猜游戏
/// </summary>
public class SevenRoomGame: IGame
{
    /// <summary>
    /// 无效discord频道号
    /// </summary>
    public string? EmptyRoomId { get; set; }
}