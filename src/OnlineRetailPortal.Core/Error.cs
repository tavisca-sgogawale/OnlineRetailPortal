using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineRetailPortal.Contracts;

namespace OnlineRetailPortal.Core
{
    public class Error
    {
        public static string DuplicateProduct()
        {
            return string.Format(ErrorMessage.DuplicateProduct);
        }
        public static string ProductNotFound(string field)
        {
            return string.Format(ErrorMessage.ProductNotFound, field);
        }
        public static string DataBaseDown()
        {
            return string.Format(ErrorMessage.DatabaseDown);
        }
        public static string InvalidCurrency(string field)
        {
            return string.Format(ErrorMessage.InvalidCurrency, field);
        }
        public static string UnsupportedFileFormat()
        {
            return string.Format(ErrorMessage.UnsupportedFileFormat);
        }
        public static string MissingImage()
        {
            return string.Format(ErrorMessage.MissingImage);
        }
        public static string NullRequest()
        {
            return string.Format(ErrorMessage.NullRequest);
        }
        public static string InvalidRequest()
        {
            return string.Format(ErrorMessage.InvalidRequest);
        }

        public static string NullField(string field)
        {
            return string.Format(ErrorMessage.NullField, field);
        }

        public static string GreaterValue(string field, string value)
        {
            return string.Format(ErrorMessage.GreaterValue, field, value);
        }

        public static string MissingField(string field)
        {
            return string.Format(ErrorMessage.MissingField, field);
        }


        public static string GreaterCharacter(string field, string value)
        {
            return string.Format(ErrorMessage.GreaterCharacter, field, value);
        }

        public static string GreaterDate(string field)
        {
            return string.Format(ErrorMessage.GreaterDate, field);
        }
    }
}
