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

        public Dictionary<int,string> Info { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }

        public BaseException(string message, int code, Dictionary<int,string> info, HttpStatusCode httpStatusCode) : base(message)
        {
            Code = code;
            Message = message;
            Info = info;
            HttpStatusCode = httpStatusCode;
        }
    }
}
