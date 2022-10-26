using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Exceptions
{
    /// <summary>
    /// 应用异常
    /// </summary>
    public class AppException: Exception
    {
        public AppException(string message) : base(message) { }
    }
}
