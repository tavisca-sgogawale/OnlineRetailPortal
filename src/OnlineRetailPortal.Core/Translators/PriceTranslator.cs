using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Core
{
    public static class PriceTranslator
    {
        public static Contracts.Price ToEntity(this Price price)
        {
            return new Contracts.Price()
            {
                Money = new Contracts.Money(
                price.Money.Amount,
                price.Money.Currency),
                IsNegotiable = price.IsNegotiable
            };
        }

        public static Price ToModel(this Contracts.Price price)
        {
            return new Price()
            {
                Money = new Money(
                price.Money.Amount,
                price.Money.Currency),
                IsNegotiable = price.IsNegotiable
            };
        }
    }
}
