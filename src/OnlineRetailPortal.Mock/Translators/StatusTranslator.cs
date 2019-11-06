using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Mock
{
    public static class StatusTranslator
    {
        public static Status ToEntity(this Status status)
        {
            switch (status)
            {
                case Status.Active:
                    return Status.Active;
                case Status.Disabled:
                    return Status.Disabled;
                case Status.Sold:
                    return Status.Sold;
                default:
                    return Status.Active;
            }
        }
    }
}
