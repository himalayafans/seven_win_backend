using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Exceptions
{
    /// <summary>
    /// 模型验证异常
    /// </summary>
    public class ValidationException : AppException
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName;
        public ValidationException(string fieldName, string message) : base(message)
        {
            FieldName = fieldName;
        }
    }
}
