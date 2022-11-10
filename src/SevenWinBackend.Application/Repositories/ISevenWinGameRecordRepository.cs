using SevenWinBackend.Application.Base;
using SevenWinBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Repositories
{
    /// <summary>
    /// 出7制胜游戏记录表
    /// </summary>
    public interface ISevenWinRecordRepository : IRepository<SevenWinRecord>
    {
        /// <summary>
        /// 获取指定玩家一分钟内的基础游戏记录
        /// </summary>
        public Task<SevenWinRecord?> GetBaseRecordWithinOneMinute(Player player);
        /// <summary>
        /// 获取指定玩家一分钟内的附加游戏记录
        /// </summary>
        public Task<List<SevenWinRecord>> GetAdditionalRecordWithinOneMinute(Player player);
    }
}
