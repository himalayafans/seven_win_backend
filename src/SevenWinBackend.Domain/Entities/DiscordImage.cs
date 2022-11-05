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
    public class DiscordImage : BaseEntity
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
        public OcrStatus OcrStatus { get; set; } = OcrStatus.None;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        /// <summary>
        /// 创建Discord图片
        /// </summary>
        public static DiscordImage Create(Guid playerId, string discordUrl, string discordFileHash)
        {
            if (playerId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(playerId));
            }
            if (string.IsNullOrWhiteSpace(discordUrl))
            {
                throw new ArgumentNullException(nameof(discordUrl));
            }
            if (string.IsNullOrWhiteSpace(discordFileHash))
            {
                throw new ArgumentNullException(nameof(discordFileHash));
            }
            return new DiscordImage()
            {
                Id = Guid.NewGuid(),
                PlayerId = playerId,
                DiscordUrl = discordUrl,               
                OriginalFileHash = discordFileHash,
                CreatedAt = DateTime.Now
            };
        }
        /// <summary>
        /// 设置本地文件
        /// </summary>
        public void SetLocalFile(string localFileName, string localFileHash)
        {
            if (string.IsNullOrWhiteSpace(localFileName))
            {
                throw new ArgumentNullException(nameof(localFileName));
            }
            if (string.IsNullOrWhiteSpace(localFileHash))
            {
                throw new ArgumentNullException(nameof(localFileHash));
            }
            this.LocalFileName = localFileName;
            this.LocalFileHash = localFileHash;
        }
        /// <summary>
        /// 设置OCR图片识别结果
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetOcr(OcrEngineType engineType, OcrStatus status, string ocrText)
        {
            if (engineType == OcrEngineType.None)
            {
                throw new ArgumentNullException(nameof(engineType));
            }
            if (status == OcrStatus.None)
            {
                throw new ArgumentNullException(nameof(status));
            }
            this.OcrStatus = status;
            this.OcrEngine = engineType;
            this.OcrText = ocrText;
        }
    }
}
