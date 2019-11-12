using System;

namespace OnlineRetailPortal.Core
{
    public static class StatusTranslator
    {
        public static Status ToModel(this Contracts.Status status)
        {
            switch (status)
            {
                case Contracts.Status.Active:
                    return Status.Active;
                case Contracts.Status.Disabled:
                    return Status.Disabled;
                case Contracts.Status.Sold:
                    return Status.Sold;
            }
            throw new NotSupportedException(status + " is not supported");
        }
    }
}
