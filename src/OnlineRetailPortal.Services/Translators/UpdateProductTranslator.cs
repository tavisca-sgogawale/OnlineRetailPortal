using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Services
{
    public static class UpdateProductTranslator
    {
        public static Core.Product ToEntity(this UpdateProductEntity updateProductEntity)
        {
            var product = new Core.Product(updateProductEntity.Price.ToEntity(), updateProductEntity.SellerId, updateProductEntity.Name)
            {
                Id = updateProductEntity.Id,
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
            return product;
        }

        public static UpdateProductEntity ToResponseModel(this Core.Product product)
        {
            UpdateProductEntity response = new UpdateProductEntity()
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
