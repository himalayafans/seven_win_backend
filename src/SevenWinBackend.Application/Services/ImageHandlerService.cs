using Discord.Rest;
using SevenWinBackend.Application.Common;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Services
{
    public class ImageHandlerService : IImageHandlerService
    {
        public async Task<MemoryStream> Resize(MemoryStream imageStream, ImageSize maxSize, ImageSize fileSize)
        {
            if (imageStream == null)
            {
                throw new ArgumentNullException(nameof(imageStream));
            }
            if (maxSize == null)
            {
                throw new ArgumentNullException(nameof(maxSize));
            }
            if (fileSize == null)
            {
                throw new ArgumentNullException(nameof(fileSize));
            }
            byte[] bytes = imageStream.ToArray();
            using var image = Image.Load(bytes);
            // 调整文件尺寸
            if (fileSize.Height > maxSize.Height || fileSize.Width > maxSize.Width)
            {
                var newSize = ImageSize.GetSameRateSize(fileSize, maxSize);
                image.Mutate(x => x.Resize(newSize.Width, newSize.Height, KnownResamplers.Lanczos3));
            }
            MemoryStream newStream = new MemoryStream();
            await image.SaveAsJpegAsync(newStream);
            return newStream;
        }
    }
}
