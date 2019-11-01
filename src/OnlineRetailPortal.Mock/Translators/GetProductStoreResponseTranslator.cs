using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineRetailPortal.Mock
{
    public static class GetProductStoreResponseTranslator
    {
        public static GetProductStoreResponse ToGetProductStore(this Product product)
        {
            GetProductStoreResponse response = new GetProductStoreResponse()
            {
                Product = new Contracts.Product()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    HeroImage = new Contracts.Image { Url = product.HeroImage.Url },
                    Price = new Contracts.Price() { Value = { Amount = product.Price.Value.Amount, Currency = product.Price.Value.Currency }, IsNegotiable = product.Price.IsNegotiable },
                    Category = (Contracts.Category)product.Category.GetHashCode(),
                    Status = (Contracts.Status)product.Status.GetHashCode(),
                    PostDateTime = product.PostDateTime,
                    ExpirationDate = product.ExpirationDate,
                    Images = product.Images.Select(x => new Contracts.Image
                    {
                        Url = x.Url
                    }).ToList(),
                    PurchasedDate = product.PurchasedDate,
                    PickupAddress = new Contracts.Address()
                    {
                        Line1 = product.PickupAddress.Line1,
                        Line2 = product.PickupAddress.Line2,
                        City = product.PickupAddress.City,
                        Pincode = product.PickupAddress.Pincode,
                        State = product.PickupAddress.State
                    }
                }
            };
            return response;

        }
    }
}
