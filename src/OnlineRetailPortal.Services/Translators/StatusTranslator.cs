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
                case Status.Deleted:
                    return Contracts.Status.Deleted;
            }
            throw new NotSupportedException(status + " is not supported");
        }

        public static Status ToEntity(this Contracts.Status status)
        {
            switch (status)
            {
                case Contracts.Status.Active:
                    return Status.Active;
                case Contracts.Status.Disabled:
                    return Status.Disabled;
                case Contracts.Status.Sold:
                    return Status.Sold;
                case Contracts.Status.Deleted:
                    return Status.Deleted;
            }
            throw new NotSupportedException(status + " is not supported");
        }
    }
}
