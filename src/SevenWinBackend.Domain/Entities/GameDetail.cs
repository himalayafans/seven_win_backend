using SevenWinBackend.Domain.Base;

namespace SevenWinBackend.Domain.Entities;

/// <summary>
/// 游戏详情
/// </summary>
public class GameDetail : BaseEntity
{
    /// <summary>
    /// 玩家ID
    /// </summary>
    public Guid PlayerId { get; set; }

    /// <summary>
    /// discord频道ID
    /// </summary>
    public Guid ChannelId { get; set; }

    /// <summary>
    /// 用户游戏ID，与PlayerGame表一对一
    /// </summary>
    public Guid PlayerGameId { get; set; }

    /// <summary>
    /// Discord文本消息
    /// </summary>
    public string DiscordMessage { get; set; }

    /// <summary>
    /// 消息包含的图片文件名称（不是图片的URL）
    /// </summary>
    public string Image { get; set; }

    /// <summary>
    /// OCR图片识别内容
    /// </summary>
    public string Ocr { get; set; }

    /// <summary>
    /// 游戏日志(禁止代码中调用)
    /// </summary>
    public GameDetail()
    {
        DiscordMessage = String.Empty;
        Image = String.Empty;
        Ocr = String.Empty;
    }

    /// <summary>
    /// 游戏日志
    /// </summary>
    /// <param name="playerId">玩家ID</param>
    /// <param name="channelId">Discord频道ID</param>
    /// <param name="playerGameId">玩家游戏ID</param>
    /// <param name="discordMessage"> Discord文本消息</param>
    /// <param name="image">消息包含的图片文件名称</param>
    /// <param name="ocr">OCR图片识别内容</param>
    public GameDetail(Guid playerId, Guid channelId, Guid playerGameId, string discordMessage, string image, string ocr)
    {
        Id = Guid.NewGuid();
        PlayerId = playerId;
        ChannelId = channelId;
        PlayerGameId = playerGameId;
        DiscordMessage = discordMessage;
        Image = image;
        Ocr = ocr;
    }
}