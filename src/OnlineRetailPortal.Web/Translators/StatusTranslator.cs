using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Web
{
    public static class StatusTranslator
    {
        public static string ToModel(this Contracts.Status status)
        {
            switch (status)
            {
                case Contracts.Status.Active:
                    return "Active";
                case Contracts.Status.Disabled:
                    return "Disabled";
                case Contracts.Status.Sold:
                    return "Sold";
                case Contracts.Status.Deleted:
                    return "Deleted";
            }
            throw new NotSupportedException(status + " is not supported");
        }

        public static Contracts.Status ToStatusEntity(this string status)
        {
            switch (status)
            {
                case "Active":
                    return Contracts.Status.Active;
                case "Disabled":
                    return Contracts.Status.Disabled;
                case "Sold":
                    return Contracts.Status.Sold;
                case "Deleted":
                    return Contracts.Status.Deleted;
                case null:
                    return Contracts.Status.Active;
            }
            throw new NotSupportedException(status + " is not supported");
        }
    }
}
