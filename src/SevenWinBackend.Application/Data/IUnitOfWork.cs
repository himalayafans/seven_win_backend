using SevenWinBackend.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Data
{
    /// <summary>
    /// 工作单元接口
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 开启事务
        /// </summary>
        void BeginTransaction();
        /// <summary>
        /// 提交事务
        /// </summary>
        void Commit();
        /// <summary>
        /// 回滚事务
        /// </summary>
        void Rollback();
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        Task ExecuteAsync(string sql, params object[] args);
        /// <summary>
        /// 执行获取标量
        /// </summary>
        Task<T> ExecuteScalarAsync<T>(string sql, params object[] args);
        /// <summary>
        /// 登录账户
        /// </summary>
        IAccountRepository Account { get; }
        /// <summary>
        /// Discord频道
        /// </summary>
        IChannelRepository Channel { get; }
        /// <summary>
        /// 应用配置
        /// </summary>
        IConfigRepository Config { get; }
        /// <summary>
        /// Discord图片
        /// </summary>
        IImageRepository Image { get; }
        /// <summary>
        /// Discord服务器
        /// </summary>
        IGuildRepository Guild { get; }
        /// <summary>
        /// 玩家参与的游戏
        /// </summary>
        IPlayerGameRepository PlayerGame { get; }
        /// <summary>
        /// 游戏视图
        /// </summary>
        IPlayerGameViewRepository PlayerGameView { get; }
        /// <summary>
        /// 玩家
        /// </summary>
        IPlayerRepository Player { get; }
        /// <summary>
        /// 出7制胜频道配置
        /// </summary>
        ISevenWinConfigRepository SevenWinConfig { get; }
        /// <summary>
        /// 出7制胜频道配置视图
        /// </summary>
        ISevenWinConfigViewRepository SevenWinConfigView { get; }
        /// <summary>
        /// 出7制胜游戏记录
        /// </summary>
        ISevenWinRecordViewRepository SevenWinRecordView { get; }
        /// <summary>
        /// 出7制胜游戏记录
        /// </summary>
        ISevenWinRecordRepository SevenWinRecord { get; }
    }
}
