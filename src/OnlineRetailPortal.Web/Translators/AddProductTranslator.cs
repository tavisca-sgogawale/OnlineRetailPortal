using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineRetailPortal.Contracts;

namespace OnlineRetailPortal.Web
{
    public static class AddProductTranslator
    {
        public static Contracts.AddProductRequest ToEntity(this AddProductRequest addProductRequest)
        {
            Contracts.AddProductRequest request = new Contracts.AddProductRequest()
            {
                SellerId = addProductRequest.SellerId,
                Name = addProductRequest.Name,
                Description = addProductRequest.Description,
                HeroImage = addProductRequest.HeroImage,
                Price = addProductRequest.Price.ToEntity(),
                Category = addProductRequest.Category.ToEntity(),
                Images = addProductRequest.Images,
                PurchasedDate = addProductRequest.PurchasedDate,
                PickupAddress = addProductRequest.PickupAddress.ToEntity()
            };
            return request;
        }
        public static AddProductResponse ToModel(this Contracts.AddProductResponse addProductResponse)
        {
            AddProductResponse response = new AddProductResponse()
            {
                Id = addProductResponse.Id,
                SellerId = addProductResponse.SellerId,
                Name = addProductResponse.Name,
                Description = addProductResponse.Description,
                HeroImage = addProductResponse.HeroImage,
                Price = addProductResponse.Price.ToModel(),
                Category = addProductResponse.Category.ToModel(),
                Status = addProductResponse.Status.ToModel(),
                PostDateTime = addProductResponse.PostDateTime,
                ExpirationDate = addProductResponse.ExpirationDate,
                Images = addProductResponse.Images,
                PurchasedDate = addProductResponse.PurchasedDate,
                PickupAddress = addProductResponse.PickupAddress.ToModel()
            };

            return response;
        }
    }
}
