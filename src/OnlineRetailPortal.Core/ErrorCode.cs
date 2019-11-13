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

        public static string ProductNotFound()
        {
            return string.Format(ErrorCodes.ProductNotFound);
        }
        public static string DataBaseDown()
        {
            return string.Format(ErrorCodes.DatabaseDown);

        }
        public static string InvalidCurrency()
        {
            return string.Format(ErrorCodes.InvalidCurrency);
        }
        public static string NullRequest()
        {
            return string.Format(ErrorCodes.NullRequest);
        }
        public static string InvalidRequest()
        {
            return string.Format(ErrorCodes.InvalidRequest);
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

        public static string GreaterDate()
        {
            return string.Format(ErrorCodes.GreaterDate);
        }
    }
}
