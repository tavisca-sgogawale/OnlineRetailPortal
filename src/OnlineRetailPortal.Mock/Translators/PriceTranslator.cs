using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Mock
{
    public static class PriceTranslator
    {
        public static Price ToModel(this Price price)
        {
            return new Price()
            {
                Money = new Money(
                price.Money.Amount,
                price.Money.Currency),
                IsNegotiable = price.IsNegotiable
            };
        }

        public static Price ToEntity(this Price price)
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
