using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineRetailPortal.Core
{
    public static class GetProductServiceResponseTranslator
    {
        public static Product ToGetProductServiceResponse(this GetProductStoreResponse getProductResponse)
        {
            Product response = new Product()
            
                {
                    Name = getProductResponse.Product.Name,
                    Id = getProductResponse.Product.Id,
                    HeroImage = new Image() { Url = getProductResponse.Product.HeroImage.Url },
                    ExpirationDate = getProductResponse.Product.ExpirationDate,
                    PostDateTime = getProductResponse.Product.PostDateTime,
                    Description = getProductResponse.Product.Description,
                    Price = new Price() { Amount = getProductResponse.Product.Price.Amount, IsNegotiable = getProductResponse.Product.Price.IsNegotiable , Currency = getProductResponse.Product.Price.Currency},
                    PurchasedDate = getProductResponse.Product.PurchasedDate,
                    PickupAddress = new Address()
                    {
                        City = getProductResponse.Product.PickupAddress.City,
                        State = getProductResponse.Product.PickupAddress.State,
                        Line1 = getProductResponse.Product.PickupAddress.Line1,
                        Line2 = getProductResponse.Product.PickupAddress.Line2,
                        Pincode = getProductResponse.Product.PickupAddress.Pincode
                    },
                    Images = getProductResponse.Product.Images.Select(x => new Image
                    {
                        Url = x.Url
                    }).ToList(),
                    Status = (Status)getProductResponse.Product.Status.GetHashCode(),
                    Category = (Category)getProductResponse.Product.Category.GetHashCode()
                
            };

            return response;
        }
    }
}

