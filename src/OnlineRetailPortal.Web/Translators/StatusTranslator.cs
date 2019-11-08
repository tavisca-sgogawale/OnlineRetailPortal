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
            }
            throw new NotSupportedException(status + " is not supported");
        }
    }
}
