using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Common
{
    internal sealed class DiscordImageInfo
    {
        public string Url { get; }
        public ImageSize Size { get; }

        public DiscordImageInfo(string url, ImageSize size)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("url");
            }
            this.Url = url;
            Size = size ?? throw new ArgumentNullException(nameof(size));
        }
    }
}
