using System.Collections.Generic;
using System.Net;

namespace OnlineRetailPortal.Web
{
    public class ExceptionErrorInfo
    {
        public int Code { get; }

        public string Message { get; }
        public Dictionary<int, string> info { get; set; }
        public HttpStatusCode HttpStatusCode { get; }
        public ExceptionErrorInfo(int code, string message, HttpStatusCode httpStatusCode)
        {
            Code = code;
            Message = message;
            HttpStatusCode = httpStatusCode;
        }
    }
}