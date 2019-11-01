using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using OnlineRetailPortal.Contracts;


namespace OnlineRetailPortal.Core
{
    public class ErrorCodes
    {
        public static string NullField()
        {
            return string.Format(ErrorCodesMessage.NullField);
        }

        public static string MissingField()
        {
            return string.Format(ErrorCodesMessage.MissingField);
        }

        public static string GreaterCharacter()
        {
            return string.Format(ErrorCodesMessage.GreaterCharacter);
        }

        public static string GreaterValue()
        {
            return string.Format(ErrorCodesMessage.GreaterValue);
        }
    }
}
