using System.Collections.Generic;
using System.Net;

namespace OnlineRetailPortal.Contracts
{
    public class CustomException : BaseException
    {
        public static List<ErrorInfo> Info { get; set; }
        private static HttpStatusCode httpStatusCode;
        public CustomException(int code) : base(code,CustomErrorCodes.getErrorMessage(code),Info, httpStatusCode)
        {
        }
    }

}
