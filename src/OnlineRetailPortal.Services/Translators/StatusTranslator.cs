using OnlineRetailPortal.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Services
{
    public static class StatusTranslator
    {
        public static Contracts.Status ToModel(this Status status)
        {
            switch (status)
            {
                case Status.Active:
                    return Contracts.Status.Active;
                case Status.Disabled:
                    return Contracts.Status.Disabled;
                case Status.Sold:
                    return Contracts.Status.Sold;
            }
            throw new NotSupportedException(status + " is not supported");
        }
    }
}
