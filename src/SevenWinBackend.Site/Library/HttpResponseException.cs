using System.Net;

namespace SevenWinBackend.Site.Library
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