using SevenWinBackend.Application.Games.SevenWin.Core;
using SevenWinBackend.Application.Services;
using SevenWinBackend.Application.Services.Data;
using SevenWinBackend.Common;
using SevenWinBackend.Domain.Entities;
using SevenWinBackend.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Games.SevenWin.Strategies
{
    /// <summary>
    /// 缓存初始化策略(OCR图片，设置玩家、图片缓存)
    /// </summary>
    internal class CacheInitPolicy : BaseStrategy
    {
        /// <summary>
        /// 检查流是否小于1M
        /// </summary>
        /// <returns></returns>
        private static bool IsLimit(MemoryStream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            var Length = stream.ToArray().Length;
            var unit = 1 * 1024 * 1024;
            var size = Length / unit;
            return size < 1;
        }
        public override async Task Handle(StrategyContext context)
        {
            // 获取服务
            HttpService httpService = context.GetService<HttpService>();
            ImageHandlerService imageHandlerService = context.GetService<ImageHandlerService>();
            ImageService imageService = context.GetService<ImageService>();
            PlayerService playerService = context.GetService<PlayerService>();
            IOcrService ocrService = context.GetService<IOcrService>();
            // 获取玩家
            Player player = await playerService.GetOrAdd(context.User);
            // 检查图片,不能通过URL检查重复图片，因为用户可能下载图片重新上传
            MemoryStream discordImageStream = await httpService.DownloadAsStream(context.DiscordImageInfo.Url);
            string discordImageHash = discordImageStream.GetMd5HashCode();
            Image? image = await imageService.GetWithOriginalFileHash(discordImageHash);
            if (image == null)
            {
                // 压缩图片
                MemoryStream resizeImageStream = IsLimit(discordImageStream) ? discordImageStream : await imageHandlerService.Resize(discordImageStream, new Common.ImageSize(1500, 3000), context.DiscordImageInfo.Size);
                // 识别图片
                IOcrResult ocrResult = await ocrService.Parse(resizeImageStream);
                string json = JsonHelper.Serialize(ocrResult);
                // 向数据库添加图片记录
                image = Image.Create(player.Id, context.DiscordImageInfo.Url, discordImageHash);
                image.SetOcr(OcrEngineType.OcrSpace, OcrStatus.Success, json);
                await imageService.Add(image);
            }
            // 设置上下文
            context.Cache.PlayerId = player.Id;
            context.Cache.ImageId = image.Id;
            context.OcrResult = ocrService.Convert(image.OcrEngine, image.OcrText);
            await (this.Successor?.Handle(context) ?? Task.CompletedTask);
        }
    }
}
