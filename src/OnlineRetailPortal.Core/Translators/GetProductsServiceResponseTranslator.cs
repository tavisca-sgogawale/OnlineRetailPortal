using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Core
{
    public static class GetProductsServiceResponseTranslator
    {

        public static GetProductsServiceResponse ToProductsList(this List<Core.Product> products)
        {
            var getProductsResponse = new GetProductsServiceResponse()
            {
                Products = GetList(products)
            };
            return getProductsResponse;

        }

        private static List<Contracts.Product> GetList(List<Product> products)
        {
            List<Contracts.Product> productLists = new List<Contracts.Product>();
            for (int i = 0; i < products.Count; i++)
            {
                productLists[i].Id = products[i].Id;
                productLists[i].Name = products[i].Name;
                productLists[i].Price = new Contracts.Price { Amount = products[i].Price.Amount, isPriceNegotiable = products[i].Price.isPriceNegotiable, Currency = (Contracts.Currency)products[i].Price.Currency };
                productLists[i].Category = (Contracts.Category)products[i].Category;
                productLists[i].HeroImage = new Contracts.Image { Url = products[i].HeroImage.Url };
                productLists[i].PickupAddress = new Contracts.Address
                {
                    Line1 = products[i].PickupAddress.Line1,
                    Line2 = products[i].PickupAddress.Line2,
                    State = products[i].PickupAddress.State,
                    City = products[i].PickupAddress.City,
                    Pincode = products[i].PickupAddress.Pincode
                };
                productLists[i].PostDateTime = products[i].PostDateTime;
                productLists[i].Status = (Contracts.Status)products[i].Status;
            }
            return productLists;
        }
    }
}
