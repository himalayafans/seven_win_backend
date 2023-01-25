using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Domain.Common
{
    public class HttpResponseException : Exception
    {
        public HttpResponseException(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest) : base(message)
        {
            this.StatusCode = statusCode;
        }
        public HttpStatusCode StatusCode { get; }
    }
}
