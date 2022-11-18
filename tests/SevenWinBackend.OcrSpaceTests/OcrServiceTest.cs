using Microsoft.AspNetCore.Hosting;
using SevenWinBackend.Application.Services;
using SevenWinBackend.Common;
using Xunit.Abstractions;

namespace SevenWinBackend.OcrSpaceTests
{
    [Collection("ocr")]
    public class OcrServiceTest
    {
        private readonly OcrSpaceFixture fixture;
        private readonly ITestOutputHelper output;
        public readonly IOcrService ocrService;
        private readonly IWebHostEnvironment env;
        public OcrServiceTest(OcrSpaceFixture fixture, ITestOutputHelper output)
        {
            this.fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));
            this.output = output ?? throw new ArgumentNullException(nameof(output));
            this.ocrService = fixture.ocrService;
            this.env = fixture.env;
        }

        /// <summary>
        /// �����ļ�����
        /// </summary>
        [Fact]
        public void ConfigTest()
        {
            List<string> keys = fixture.settings.OcrSpaceKeys;
            var count = keys.Count();
            Assert.Equal(3, count);
            Assert.Equal("K85429622288957", keys[0]);
            Assert.Equal("K85930152388957", keys[1]);
            Assert.Equal("K85919863888957", keys[2]);
        }
        [Fact]
        public async Task ParseTest()
        {
            string webRootPath = this.env.WebRootPath;
            FileInfo file = new FileInfo(Path.Combine(webRootPath, "phone.jpeg"));
            output.WriteLine("��ȡ�ļ���");
            var stream = await file.ReadMemoryStreamAsync();
            output.WriteLine("����OcrSpace API");
            var ocrResult = await this.ocrService.Parse(stream);
            output.WriteLine("���Ocr���");
            Assert.Equal("23.753", ocrResult.GetPrice());
        }
        [Fact]
        public async Task IsIncludeHdo()
        {
            string webRootPath = this.env.WebRootPath;
            FileInfo file = new FileInfo(Path.Combine(webRootPath, "phone.jpeg"));
            var stream = await file.ReadMemoryStreamAsync();
            var ocrResult = await this.ocrService.Parse(stream);
            string text = ocrResult.GetText();
            // ż���ᱻʶ��Ϊ HIMALA AYA  EEXCHANGE
            Assert.True(text.ContainsIgnoreCase("himala") && text.ContainsIgnoreCase("exchange"));
        }
    }
}