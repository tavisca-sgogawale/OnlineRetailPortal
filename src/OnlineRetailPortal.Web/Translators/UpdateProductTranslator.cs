using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Web
{
    public static class UpdateProductTranslator
    {
        public static Contracts.UpdateProductEntity ToEntity(this UpdateProductEntity updateProductEntity)
        {
            Contracts.UpdateProductEntity request = new Contracts.UpdateProductEntity()
            {
                Id = updateProductEntity.Id,
                SellerId = updateProductEntity.SellerId,
                Name = updateProductEntity.Name,
                Description = updateProductEntity.Description,
                HeroImage = updateProductEntity.HeroImage,
                Price = updateProductEntity.Price.ToEntity(),
                Category = updateProductEntity.Category.ToEntity(),
                Images = updateProductEntity.Images,
                PurchasedDate = updateProductEntity.PurchasedDate,
                PickupAddress = updateProductEntity.PickupAddress.ToEntity(),
                PostDateTime = updateProductEntity.PostDateTime,
                ExpirationDate = updateProductEntity.ExpirationDate,
                Status = updateProductEntity.Status.ToStatusEntity()
            };
            return request;
        }
        public static UpdateProductEntity ToResponseModel(this Contracts.UpdateProductEntity updateProductEntity)
        {
            UpdateProductEntity response = new UpdateProductEntity()
            {
                Id = updateProductEntity.Id,
                SellerId = updateProductEntity.SellerId,
                Name = updateProductEntity.Name,
                Description = updateProductEntity.Description,
                HeroImage = updateProductEntity.HeroImage,
                Price = updateProductEntity.Price.ToModel(),
                Category = updateProductEntity.Category.ToModel(),
                Status = updateProductEntity.Status.ToModel(),
                PostDateTime = updateProductEntity.PostDateTime,
                ExpirationDate = updateProductEntity.ExpirationDate,
                Images = updateProductEntity.Images,
                PurchasedDate = updateProductEntity.PurchasedDate,
                PickupAddress = updateProductEntity.PickupAddress.ToModel()
            };

            return response;
        }
    }
}
