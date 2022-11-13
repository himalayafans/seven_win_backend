using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SevenWinBackend.Common
{
    /// <summary>
    /// JSON工具类
    /// </summary>
    public static class JsonHelper
    {

        /// <summary>
        /// 尝试解析JSON，如果转换失败，则返回该类型的默认值（该方法不抛异常）
        /// </summary>
        public static T? TryParseJson<T>(string json, T? defaultValue = null) where T : class
        {
            try
            {
                return JsonSerializer.Deserialize<T>(json);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
        /// <summary>
        /// JSON序列化
        /// </summary>
        public static string Serialize<T>(T obj) where T : class
        {
            if (obj == null)
            {
                return string.Empty;
            }
            else
            {
                return JsonSerializer.Serialize(obj);
            }
        }
        /// <summary>
        /// JSON反序列化
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public static T Deserialize<T>(string json) where T : class
        {
            T? obj = JsonSerializer.Deserialize<T>(json);
            if (obj == null)
            {
                throw new InvalidOperationException();
            }
            return obj;
        }
    }
}
