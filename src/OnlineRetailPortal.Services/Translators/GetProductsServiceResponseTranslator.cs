using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OnlineRetailPortal.Services
{
    static class GetProductsServiceResponseTranslator
    {

        public static GetProductsServiceResponse ToGetProductsContract(this List<Core.Product> getProductsResponse)
        {
            GetProductsServiceResponse response = new GetProductsServiceResponse()
            {
                Products = getProductsResponse.Select(x => new Product()
                {
                    Name = x.Name,
                    Id = x.Id,
                    HeroImage = new Contracts.Image() { Url = x.HeroImage.Url },
                    ExpirationDate = x.ExpirationDate,
                    PostDateTime = x.PostDateTime,
                    Description = x.Description,
                    Price = new Contracts.Price() { Amount = x.Price.Amount, IsNegotiable = x.Price.IsNegotiable },
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
                    Status = (Contracts.Status)x.Status.GetHashCode(),
                    Category = (Contracts.Category)x.Category.GetHashCode()
                }).ToList()
            };
            return response;

        }

    }
}