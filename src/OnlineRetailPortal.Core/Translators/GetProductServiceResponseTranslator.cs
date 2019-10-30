using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineRetailPortal.Core
{
    public static class GetProductServiceResponseTranslator
    {
        public static GetProductServiceResponse ToGetProductServiceResponse(this GetProductStoreResponse getProductResponse)
        {
            GetProductServiceResponse response = new GetProductServiceResponse()
            {
                Product = new Contracts.Product()
                {
                    Name = getProductResponse.Product.Name,
                    Id = getProductResponse.Product.Id,
                    HeroImage = new Contracts.Image() { Url = getProductResponse.Product.HeroImage.Url },
                    ExpirationDate = getProductResponse.Product.ExpirationDate,
                    PostDateTime = getProductResponse.Product.PostDateTime,
                    Description = getProductResponse.Product.Description,
                    Price = new Contracts.Price() { Amount = getProductResponse.Product.Price.Amount, IsNegotiable = getProductResponse.Product.Price.IsNegotiable },
                    PurchasedDate = getProductResponse.Product.PurchasedDate,
                    PickupAddress = new Contracts.Address()
                    {
                        City = getProductResponse.Product.PickupAddress.City,
                        State = getProductResponse.Product.PickupAddress.State,
                        Line1 = getProductResponse.Product.PickupAddress.Line1,
                        Line2 = getProductResponse.Product.PickupAddress.Line2,
                        Pincode = getProductResponse.Product.PickupAddress.Pincode
                    },
                    Images = getProductResponse.Product.Images.Select(x => new Contracts.Image
                    {
                        Url = x.Url
                    }).ToList(),
                    Status = (Contracts.Status)getProductResponse.Product.Status.GetHashCode(),
                    Category = (Contracts.Category)getProductResponse.Product.Category.GetHashCode()
                }
            };

            return response;
        }
    }
}

