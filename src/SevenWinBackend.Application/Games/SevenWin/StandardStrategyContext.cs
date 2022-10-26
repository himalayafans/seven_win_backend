using Discord.WebSocket;
using SevenWinBackend.Application.Common;
using SevenWinBackend.Application.Data;
using SevenWinBackend.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Games.SevenWin
{
    /// <summary>
    /// 策略上下文
    /// </summary>
    internal class StandardStrategyContext
    {
        public PlayResult PlayResult { get; }
        public IUnitOfWork UnitOfWork { get; }
        public IOcrResult OcrResult { get; }
        public FileInfo ImageFile { get; }
        public SocketUserMessage SocketUserMessage { get; }

        public StandardStrategyContext(PlayResult playResult, IUnitOfWork unitOfWork, IOcrResult ocrResult, FileInfo imageFile, SocketUserMessage socketUserMessage)
        {
            PlayResult = playResult ?? throw new ArgumentNullException(nameof(playResult));
            UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            OcrResult = ocrResult ?? throw new ArgumentNullException(nameof(ocrResult));
            ImageFile = imageFile ?? throw new ArgumentNullException(nameof(imageFile));
            SocketUserMessage = socketUserMessage ?? throw new ArgumentNullException(nameof(socketUserMessage));
        }
    }
}
