namespace SevenWinBackend.Domain.Enums;

/// <summary>
/// 游戏类型
/// </summary>
public enum GameTypes
{
    /// <summary>
    /// 表示未参加任何游戏
    /// </summary>
    None = 0,
    /// <summary>
    /// 出7制胜（规定时间按规则发帖将获得基础分）
    /// </summary>
    SevenWin = 1,
    /// <summary>
    /// 7个房间发帖，遇到无效房间则失效
    /// </summary>
    SevenRoom = 2
}