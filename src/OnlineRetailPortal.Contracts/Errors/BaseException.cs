using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace OnlineRetailPortal.Contracts.Errors
{
    [Serializable]
    public class BaseException : Exception
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public HttpStatusCode HttpStatusCode { get; set; }
        public object Info { get; set; }

        public BaseException(string message, int code , HttpStatusCode httpStatusCode) : base(message)
        {
            Code = code;
            Message = message;
            HttpStatusCode = httpStatusCode;
        }
    }
}
