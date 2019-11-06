using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Mock
{
    public static class PurchasedDateTranslator
    {
        public static DateTime? ToModel(this DateTime? purchasedDate)
        {
            if (purchasedDate == null)
                return null;
            return new Product().PurchasedDate = purchasedDate;
        }

        public static DateTime? ToEntity(this DateTime? purchasedDate)
        {
            if (purchasedDate == null)
                return null;
            return new Product().PurchasedDate = purchasedDate;
        }
    }
}
