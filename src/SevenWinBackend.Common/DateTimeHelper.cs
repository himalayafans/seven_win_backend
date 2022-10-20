using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Common
{
    /// <summary>
    /// DateTime工具类
    /// </summary>
    public static class DateTimeHelper
    {
        /// <summary>
        /// 将当前时区的datetime转换成JavaScript时间戳
        /// </summary>
        public static long ToTimestamp(DateTime time)
        {
            DateTime startTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long timeStamp = (long)(time.ToUniversalTime() - startTime).TotalMilliseconds; // 相差毫秒数
            return timeStamp;
        }
        /// <summary>
        /// 获取当前时间戳
        /// </summary>
        public static long GetNowTimestamp()
        {
            return ToTimestamp(DateTime.Now);
        }
        /// <summary>
        /// 将JavaScript时间戳转换成当前时区的datetime
        /// </summary>
        public static DateTime FromTimestamp(long timestamp)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(timestamp).DateTime;
        }
    }
}
