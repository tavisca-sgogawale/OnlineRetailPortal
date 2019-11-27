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
                case Contracts.Status.Deleted:
                    return Status.Deleted;
                default:
                    return Status.Active;
            }
         
        }

        public static Contracts.Status ToEntity(this Status status)
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
                default:
                    return Contracts.Status.Active;
            }
            
        }
    }
}
