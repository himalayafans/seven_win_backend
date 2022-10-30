/**
 * 枚举值必须是2的幂，因为一个频道可能参与多种游戏
 **/

namespace SevenWinBackend.Domain.Enums;

/// <summary>
/// 游戏类型
/// </summary>
public enum GameTypes
{
    /// <summary>
    /// 表示未参加任何游戏
    /// </summary>
    None = 1,
    /// <summary>
    /// 出7制胜
    /// </summary>
    SevenWin = 2
}