using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Services
{
    public static class UpdateProductTranslator
    {
        public static Core.Product ToEntity(this ProductEntity updateProductEntity)
        {
            var updateProduct = new Core.Product()
            {
                Id = updateProductEntity.Id,
                Name = updateProductEntity.Name,
                Price = updateProductEntity.Price.ToEntity(),
                Description = updateProductEntity.Description,
                HeroImage = updateProductEntity.HeroImage,
                Category = updateProductEntity.Category.ToEntity(),
                Images = updateProductEntity.Images,
                PurchasedDate = updateProductEntity.PurchasedDate,
                PickupAddress = updateProductEntity.PickupAddress.ToEntity(),
                PostDateTime = updateProductEntity.PostDateTime,
                ExpirationDate = updateProductEntity.ExpirationDate,
                Status = updateProductEntity.Status.ToEntity()
            };
            return updateProduct;
        }

        public static ProductEntity ToResponseModel(this Core.Product product)
        {
            ProductEntity response = new ProductEntity()
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
                PurchasedDate = (DateTime) product.PurchasedDate,
                PickupAddress = product.PickupAddress.ToModel()
            };

            return response;
        }
    }
}
