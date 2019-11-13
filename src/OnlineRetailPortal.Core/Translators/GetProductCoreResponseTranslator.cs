using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace OnlineRetailPortal.Core
{
    public static class GetProductServiceResponseTranslator
    {
        public static Product ToModel(this Contracts.GetProductStoreResponse getProductResponse)
        {
            if (getProductResponse == null)
            {
               return null;
            }

            Price price = getProductResponse.Product.Price.ToModel();
            Product response = new Product(price,getProductResponse.Product.SellerId,getProductResponse.Product.Name)
            
                {
                    Id = getProductResponse.Product.Id,
                    HeroImage = getProductResponse.Product.HeroImage,
                    ExpirationDate = getProductResponse.Product.ExpirationDate,
                    PostDateTime = getProductResponse.Product.PostDateTime,
                    Description = getProductResponse.Product.Description,          
                    PurchasedDate = getProductResponse.Product.PurchasedDate,
                    PickupAddress = getProductResponse.Product.PickupAddress.ToModel(),
                    Images = getProductResponse.Product.Images,
                    Status = getProductResponse.Product.Status.ToModel(),
                    Category = getProductResponse.Product.Category.ToModel()

            };

            return response;
        }
        
    }
}

