using System.Net;
using OnlineRetailPortal.Contracts.Errors;

namespace OnlineRetailPortal.Contracts.Errors
{
    public class CustomException : BaseException
    {
        private static HttpStatusCode httpStatusCode;

        public CustomException(int code) : base(CustomErrorCodes.getErrorMessage(code), code, httpStatusCode)
        {
        }
    }

}
