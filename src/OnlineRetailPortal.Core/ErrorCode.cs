using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using OnlineRetailPortal.Contracts;


namespace OnlineRetailPortal.Core
{
    public class ErrorCode
    {
        public static string Invalid()
        {
            return string.Format(ErrorCodes.Invalid);
        }

        public static string NullField()
        {
            return string.Format(ErrorCodes.NullField);
        }

        public static string MissingField()
        {
            return string.Format(ErrorCodes.MissingField);
        }

        public static string GreaterCharacter()
        {
            return string.Format(ErrorCodes.GreaterCharacter);
        }

        public static string GreaterValue()
        {
            return string.Format(ErrorCodes.GreaterValue);
        }
    }
}
