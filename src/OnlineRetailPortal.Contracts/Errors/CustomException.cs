using System.Collections.Generic;
using System.Net;
using OnlineRetailPortal.Contracts.Errors;
using System;

namespace OnlineRetailPortal.Contracts.Errors
{
    public class CustomException : BaseException
    {
        private static HttpStatusCode httpStatusCode;
        public static List<Tuple<int, string>> Info { get; set; }
        public CustomException(int code) : base(code,CustomErrorCodes.getErrorMessage(code),Info, httpStatusCode)
        {
        }
    }

}
