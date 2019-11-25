using System;

namespace OnlineRetailPortal.Core
{
    public static class PriceTranslator
    {
        public static Contracts.Price ToEntity(this Price price)
        {
            if (price == null)
                return null;
            if (price.Money == null)
            {
                return new Contracts.Price()
                {
                    Money = null,
                    IsNegotiable = Convert.ToBoolean(price.IsNegotiable)
                };
            }
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
            if (price == null)
                return null;
            return new Price()
            {
                Money = new Money(
                price.Money.Amount,
                price.Money.Currency),
                IsNegotiable = Convert.ToBoolean(price.IsNegotiable)
            };
        }
    }
}
