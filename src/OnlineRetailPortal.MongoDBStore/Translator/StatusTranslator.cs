using OnlineRetailPortal.Contracts;
using System;

namespace OnlineRetailPortal.MongoDBStore
{
    public static class StatusTranslator
    {
        public static string ToStatusEntity(this Status status)
        {
            switch (status)
            {
                case Status.Active:
                    return "Active";
                case Status.Disabled:
                    return "Disabled";
                case Status.Sold:
                    return "Sold";
            }
            throw new NotSupportedException(status + " is not supported");
        }
        public static Status ToModel(this string status)
        {
            switch (status)
            {
                case "Active":
                    return Status.Active;
                case "Disabled":
                    return Status.Disabled;
                case "Sold":
                    return Status.Sold;
            }
            throw new NotSupportedException(status + " is not supported");
        }
    }

}
