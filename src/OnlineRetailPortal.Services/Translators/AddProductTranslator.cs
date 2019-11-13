using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Services
{
    public static class AddProductTranslator
    {
        public static Core.Product ToEntity(this Contracts.AddProductRequest addProductRequest)
        {
            var product = new Core.Product(addProductRequest.Price.ToEntity(), addProductRequest.SellerId, addProductRequest.Name)
            {
                Description = addProductRequest.Description,
                HeroImage = addProductRequest.HeroImage,
                Category = addProductRequest.Category.ToEntity(),
                Images = addProductRequest.Images,
                PurchasedDate = addProductRequest.PurchasedDate,
                PickupAddress = addProductRequest.PickupAddress.ToEntity()
            };
            return product;
        }

        public static Contracts.AddProductResponse ToModel(this Core.Product product)
        {
            Contracts.AddProductResponse response = new Contracts.AddProductResponse()
            {
                Id = product.Id,
                SellerId = product.SellerId,
                Name = product.Name,
                Description = product.Description,
                HeroImage = product.HeroImage,
                Price = product.Price.ToModel(),
                Category = product.Category.ToModel(),
                Status = product.Status.ToModel(),
                PostDateTime = product.PostDateTime,
                ExpirationDate = product.ExpirationDate,
                Images = product.Images,
                PurchasedDate = product.PurchasedDate,
                PickupAddress = product.PickupAddress.ToModel()
            };

            return response;
        }

    }
}
