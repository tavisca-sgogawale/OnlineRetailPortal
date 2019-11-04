using System.Collections.Generic;
using System.Net;
using OnlineRetailPortal.Contracts.Errors;

namespace OnlineRetailPortal.Contracts.Errors
{
    public class CustomException : BaseException
    {
        private static HttpStatusCode httpStatusCode;
        public static Dictionary<int, string> Info { get; set; }
        public CustomException(int code) : base(CustomErrorCodes.getErrorMessage(code), code,Info, httpStatusCode)
        {
        }
    }

}
