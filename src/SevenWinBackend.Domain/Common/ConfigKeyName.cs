///***************************
// * 该类是模拟枚举类型
// * 参考资料：https://stackoverflow.com/a/3007754
// *************************/

//namespace SevenWinBackend.Domain.Common;

///// <summary>
///// 站点配置键名
///// </summary>
//public class ConfigKeyName
//{
//    private const string DbVersionName = "DbVersion";
//    private const string AppIdName = "AppId";
//    private const string SevenGameName = "SevenGame";
//    private string Display { get; set; }

//    private ConfigKeyName(string display)
//    {
//        Display = display;
//    }

//    public override string ToString()
//    {
//        return Display;
//    }

//    /// <summary>
//    /// 数据库版本
//    /// </summary>
//    public static readonly ConfigKeyName DbVersion = new ConfigKeyName(DbVersionName);
//    /// <summary>
//    /// 内部应用标识（便于区分不同的独立应用，防止破坏性升级数据库）
//    /// </summary>
//    public static readonly ConfigKeyName AppId = new ConfigKeyName(AppIdName);
//    /// <summary>
//    /// 出7制胜游戏配置
//    /// </summary>
//    public static readonly ConfigKeyName SevenGame = new ConfigKeyName(SevenGameName);
//}