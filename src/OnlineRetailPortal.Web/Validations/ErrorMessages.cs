using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Web.Validations
{
    public class ErrorMessages
    {
        public static string MissingField(string field)
        {
            return string.Format(field, "can not be blank");
        }

        public static string NullField(string field)
        {
            return string.Format(field, "can not be null");
        }

        public static string Greater(string field,string value)
        {
            return string.Format(field,"should be greater than",value);
        }
    }
}
