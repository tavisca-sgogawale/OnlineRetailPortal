using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace OnlineRetailPortal.Contracts
{
    [Serializable]
    public class BaseException : Exception
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public List<ErrorInfo> Info { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }

        public BaseException(int code, string message, List<ErrorInfo> info , HttpStatusCode httpStatusCode) : base(message)
        { 
            Code = code;
            Message = message;
            Info = info;
            HttpStatusCode = httpStatusCode;
        }
    }
}
