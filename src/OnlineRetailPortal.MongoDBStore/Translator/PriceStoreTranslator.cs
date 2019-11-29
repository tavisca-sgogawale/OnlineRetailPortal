﻿using OnlineRetailPortal.Contracts;
using System;

namespace OnlineRetailPortal.MongoDBStore
{
    public static class PriceStoreTranslator
    {
        public static StorePrice ToEntity(this Price price)
        {
            if(price == null)
            {
                return null;
            }
            return new StorePrice() { Amount = price.Money.Amount, Currency = price.Money.Currency, IsNegotiable = Convert.ToBoolean(price.IsNegotiable) };
        }

        public static Price ToModel(this StorePrice storePrice)
        {
            if(storePrice == null)
            {
                return null;
            }
            return new Price()
            {
                Money = new Money(storePrice.Amount, storePrice.Currency),
                IsNegotiable = storePrice.IsNegotiable
            };
        }
    }

}
