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
        public List<Tuple<int, string>> Info { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }

        public BaseException(int code, string message, List<Tuple<int, string>> info) : base(message)
        {
            Code = code;
            Message = message;
            Info = info;
        }
    }
}
