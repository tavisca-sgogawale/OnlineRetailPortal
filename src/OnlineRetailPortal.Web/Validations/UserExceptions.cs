using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineRetailPortal.Contracts.Errors;

namespace OnlineRetailPortal.Web.Validations
{
    public class UserExceptions : BaseException
    {
        public UserExceptions(string code, int message) : base(code, message) { }

        public static BaseException InvalidRequest(string message,string code)
        {
            return new UserExceptions(message,Convert.ToInt32(code));
        }
    }
}
