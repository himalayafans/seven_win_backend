using Microsoft.AspNetCore.Hosting;
using SevenWinBackend.Application.Services;
using SevenWinBackend.Common;
using SevenWinBackend.Application.Common;
using SixLabors.ImageSharp;

namespace SevenWinBackend.ApplicationTests
{
    [Collection("app collection")]
    public class ImageServiceTest
    {
        private readonly IImageService imageService;
        private readonly AppFixture appFixture;
        private readonly IWebHostEnvironment env;

        public ImageServiceTest(AppFixture appFixture)
        {
            this.appFixture = appFixture ?? throw new ArgumentNullException(nameof(appFixture));
            this.imageService = appFixture.imageService;
            this.env = appFixture.env;
        }

        [Fact]
        public async Task Test1()
        {
            string webRootPath = this.env.WebRootPath;
            FileInfo file = new FileInfo(Path.Combine(webRootPath, "phone.jpeg"));
            MemoryStream fileStream = await file.ReadMemoryStreamAsync();
            var imageStream = await this.imageService.Resize(fileStream, new ImageSize(200, 300), new ImageSize(10000, 10000));
            using var image = Image.Load(imageStream.ToArray());
            var height = image.Height;
            var width = image.Width;
            Assert.Equal(200, height);
            Assert.Equal(200, width); // 等比率缩放，应该是200，而不是300
        }
    }
}