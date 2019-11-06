using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Core
{
   public static class PurchasedDateTranslator
    {
        public static DateTime? ToEntity(this DateTime? purchasedDate)
        {
            if (purchasedDate == null)
                return null;
            return new Contracts.Product().PurchasedDate = purchasedDate;
        }

        public static DateTime? ToModel(this DateTime? purchasedDate)
        {
            if (purchasedDate == null)
                return null;
            return purchasedDate;
        }
    }
}
