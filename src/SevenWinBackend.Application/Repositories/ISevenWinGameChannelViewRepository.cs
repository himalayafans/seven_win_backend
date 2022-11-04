using SevenWinBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Repositories
{
    public interface ISevenWinGameChannelViewRepository
    {
        /// <summary>
        /// 获取基础游戏频道
        /// </summary>
        Task<SevenWinGameChannelView?> GetBaseChannel();
        /// <summary>
        /// 获取附加游戏频道
        /// </summary>
        Task<List<SevenWinGameChannelView>> GetAdditionalChannels();
        /// <summary>
        /// 通过Discord ID获取频道
        /// </summary>
        Task<SevenWinGameChannelView?> GetChannel(ulong discordId);
        /// <summary>
        /// 获取所有频道
        /// </summary>
        Task<List<SevenWinGameChannelView>> GetAllChannels();
    }
}
