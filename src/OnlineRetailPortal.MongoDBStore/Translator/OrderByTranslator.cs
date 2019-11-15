using OnlineRetailPortal.Contracts;
using System;

namespace OnlineRetailPortal.MongoDBStore
{
    public static class OrderByTranslator
    {
        public static string ToEntity(this string type)
        {
            switch (type)
            {
                case "Date":
                    return "CreatedDate";
                case "Price":
                    return "Price.Amount";
            }
            throw new NotSupportedException(type + " is not supported");
        }
       
    }

}
