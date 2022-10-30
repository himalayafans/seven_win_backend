using SevenWinBackend.Domain.Base;
using SevenWinBackend.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Domain.Entities
{
    /// <summary>
    /// Discord图片
    /// </summary>
    public class DiscordImage: BaseEntity
    {
        /// <summary>
        /// 上传者ID
        /// </summary>
        public Guid PlayerId { get; set; }
        /// <summary>
        /// Discord图片路径
        /// </summary>
        public string DiscordUrl { get; set; } = string.Empty;
        /// <summary>
        /// 原始文件哈希值
        /// </summary>
        public string OriginalFileHash { get; set; } = string.Empty;
        /// <summary>
        /// 本地文件名称
        /// </summary>
        public string LocalFileName { get; set; } = string.Empty;
        /// <summary>
        /// 本地文件哈希值
        /// </summary>
        public string LocalFileHash { get; set; } = string.Empty;
        /// <summary>
        /// Ocr识别出的文字
        /// </summary>
        public string OcrText { get; set; } = string.Empty;
        /// <summary>
        /// Ocr引擎
        /// </summary>
        public OcrEngineType OcrEngine { get; set; } = OcrEngineType.None;
        /// <summary>
        /// Ocr识别状态
        /// </summary>
        public OcrStatus OcrStatus { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; }
        public DiscordImage()
        {
        }

        public DiscordImage(Guid playerId, string discordUrl, string discordFileHash, string localFileName, string localFileHash, string ocrText, OcrEngineType ocrEngine, OcrStatus ocrStatus)
        {
            Id = Guid.NewGuid();
            PlayerId = playerId;
            DiscordUrl = discordUrl;
            OriginalFileHash = discordFileHash;
            LocalFileName = localFileName;
            LocalFileHash = localFileHash;
            OcrText = ocrText;
            OcrEngine = ocrEngine;
            OcrStatus = ocrStatus;
            CreatedAt = DateTime.Now;
        }
    }
}
