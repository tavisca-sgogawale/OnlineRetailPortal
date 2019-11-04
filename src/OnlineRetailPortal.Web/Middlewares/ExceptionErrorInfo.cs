using System.Collections.Generic;
using System.Net;

namespace OnlineRetailPortal.Web
{
    public class ExceptionErrorInfo
    {
        public int Code { get; }

        public string Message { get; }

        public HttpStatusCode HttpStatusCode { get; }

        public Dictionary<int, string> data { get; set; }
        public ExceptionErrorInfo(int code, string message, HttpStatusCode httpStatusCode)
        {
            Code = code;
            Message = message;
            HttpStatusCode = httpStatusCode;
        }
    }
}