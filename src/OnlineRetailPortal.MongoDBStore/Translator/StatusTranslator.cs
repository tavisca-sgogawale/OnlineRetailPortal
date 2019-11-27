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
                case Status.Deleted:
                    return "Deleted";
                default:
                    return "Active";
            }
            throw new NotSupportedException(status + " is not supported");
        }
        public static Status ToStatusModel(this string status)
        {
            switch (status)
            {
                case "Active":
                    return Status.Active;
                case "Disabled":
                    return Status.Disabled;
                case "Sold":
                    return Status.Sold;
                case "Deleted":
                    return Status.Deleted;
                default:
                    return Status.Active;
            }
            throw new NotSupportedException(status + " is not supported");
        }
    }

}
