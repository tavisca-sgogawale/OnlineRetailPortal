
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using OnlineRetailPortal.Contracts.Errors;
using OnlineRetailPortal.Contracts;

namespace OnlineRetailPortal.Web.Validations
{
    public class UserExceptions : BaseException
    {
        public UserExceptions(string code, int message,Dictionary<int,string> info, HttpStatusCode httpStatusCode) : base(code, message,info, httpStatusCode) { }

        public static BaseException InvalidRequest(string message, string code, Dictionary<int, string> info, HttpStatusCode httpStatusCode)
        {
            return new UserExceptions(message, Convert.ToInt32(code),info, httpStatusCode);
        }
    }
}