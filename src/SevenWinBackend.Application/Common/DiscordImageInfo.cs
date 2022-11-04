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
        public string Hash { get; }
        public MemoryStream Stream { get; }

        public DiscordImageInfo(string url, string hash, ImageSize size, MemoryStream stream)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException(nameof(url));
            }

            if (string.IsNullOrWhiteSpace(hash))
            {
                throw new ArgumentNullException(nameof(hash));
            }

            this.Url = url;
            Size = size ?? throw new ArgumentNullException(nameof(size));
            Stream = stream ?? throw new ArgumentNullException(nameof(stream));
            Hash = hash;
        }
    }
}