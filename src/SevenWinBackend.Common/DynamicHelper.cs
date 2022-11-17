using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Common
{
    /// <summary>
    /// 动态对象帮助类
    /// </summary>
    public static class DynamicHelper
    {
        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public static void SetPropertyValue(ExpandoObject expando, string propertyName, object propertyValue)
        {
            if (expando == null)
            {
                throw new ArgumentNullException(nameof(expando));
            }
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentNullException(nameof(propertyName));
            }
            if (propertyValue == null)
            {
                throw new ArgumentNullException(nameof(propertyValue));
            }
            propertyName = propertyName.Trim();
            var expandoDict = expando as IDictionary<string, object>;
            if (expandoDict.ContainsKey(propertyName))
            {
                expandoDict[propertyName] = propertyValue;
            }
            else
            {
                expandoDict.Add(propertyName, propertyValue);
            }
        }
    }
}
