using Discord.Rest;
using Discord.WebSocket;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using SevenWinBackend.Application.Base;
using SevenWinBackend.Application.Common;
using SevenWinBackend.Application.Data;
using SevenWinBackend.Application.Interfaces;
using SevenWinBackend.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Games.SevenWin
{
    /// <summary>
    /// 出7制胜游戏引擎
    /// </summary>
    public class SevenWinGameEngine : BaseGameEngine
    {
        private static readonly List<string> _imageTypes = new List<string>()
        {
            "image/jpeg",
            //"image/gif",
            "image/png",
            //"image/bmp"
        };
        private readonly ILogger<SevenWinGameEngine> logger;
        private readonly IOcrService ocrService;
        private readonly IImageService imageService;
        private readonly SevenWinGameEngine sevenWinGameEngine;
        private readonly IUnitOfWorkFactory unitOfWorkFactory;
        private readonly IWebHostEnvironment env;
        private readonly HttpService httpService;

        public SevenWinGameEngine(ILogger<SevenWinGameEngine> logger, IOcrService ocrService, IImageService imageService, SevenWinGameEngine sevenWinGameEngine, IUnitOfWorkFactory unitOfWorkFactory, IWebHostEnvironment environment, HttpService httpService)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.ocrService = ocrService ?? throw new ArgumentNullException(nameof(ocrService));
            this.imageService = imageService ?? throw new ArgumentNullException(nameof(imageService));
            this.sevenWinGameEngine = sevenWinGameEngine ?? throw new ArgumentNullException(nameof(sevenWinGameEngine));
            this.unitOfWorkFactory = unitOfWorkFactory ?? throw new ArgumentNullException(nameof(unitOfWorkFactory));
            this.env = environment ?? throw new ArgumentNullException(nameof(environment));
            this.httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
        }

        /// <summary>
        /// 获取消息中的图片，若不存在则返回null
        /// </summary>
        private static DiscordImageInfo? GetImage(SocketUserMessage message)
        {
            var images = message.Attachments.Where(p => _imageTypes.Contains(p.ContentType)).ToList();
            if (images.Count == 0)
            {
                return null;
            }
            if (images.Count > 1)
            {
                throw new Exception("本次活动参与无效，一次只能上传一张图片");
            }
            var file = message.Attachments.First();
            return new DiscordImageInfo(file.Url, new ImageSize(file.Width.GetValueOrDefault(), file.Height.GetValueOrDefault()));
        }

        public override async Task Handle(SocketUserMessage message, PlayResult playResult)
        {
            DiscordImageInfo? imageInfo = GetImage(message);
            // 如果Discord消息不包含图片，则忽略消息
            if (imageInfo == null)
            {
                if (this.Successor != null)
                {
                    await this.Successor.Handle(message, playResult);
                }
            }
            else
            {
                // 下载图片文件
                var directoryPath = Path.Combine(env.WebRootPath, "images");
                DirectoryInfo directory = new DirectoryInfo(directoryPath);
                FileInfo oldFile = await this.httpService.Download(imageInfo.Url, directory);
                // 压缩图片
                FileInfo newFile = await this.imageService.Resize(oldFile, 2000, 2000);
                // OCR识别
                IOcrResult ocrResult = await this.ocrService.Parse(newFile);

            }
        }
    }
}
