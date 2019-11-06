using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineRetailPortal.Mock
{
    public static class GetProductsStoreResponceTranslator
    {
        public static GetProductsStoreResponse ToGetProductsStoreResponse(this List<Product> products)
        {
           GetProductsStoreResponse response = new GetProductsStoreResponse()
            {
                Products = products.Select(x => new Contracts.Product()
                {
                    Name = x.Name,
                    Id = x.Id,
                    HeroImage = new Contracts.Image() { Url = x.HeroImage.Url },
                    ExpirationDate = x.ExpirationDate,
                    PostDateTime = x.PostDateTime,
                    Description = x.Description,
                    Price = new Contracts.Price() { Money = { Amount = x.Price.Money.Amount,Currency = x.Price.Money.Currency }, IsNegotiable = x.Price.IsNegotiable },
                    PurchasedDate = x.PurchasedDate,
                    PickupAddress = new Contracts.Address()
                    {
                        City = x.PickupAddress.City,
                        State = x.PickupAddress.State,
                        Line1 = x.PickupAddress.Line1,
                        Line2 = x.PickupAddress.Line2,
                        Pincode = x.PickupAddress.Pincode
                    },
                    Images = x.Images.Select(y => new Contracts.Image
                    {
                        Url = y.Url
                    }).ToList(),
                    Status = x.Status,
                    Category = x.Category
                }).ToList()
            };
            return response;
        }
    }
}
