using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Web
{
    public static class UpdateProductTranslator
    {
        public static Contracts.UpdateProductEntity ToEntity(this UpdateProductEntity updateProductEntity,string productId)
        {
            Contracts.UpdateProductEntity request = new Contracts.UpdateProductEntity();
            
            request.Id = productId;
            request.Name = updateProductEntity.Name;
            request.Category = updateProductEntity.Category;
            request.Description = updateProductEntity.Description;
            request.HeroImage = updateProductEntity.HeroImage;
            request.Price = updateProductEntity.Price.ToEntity();
            request.Images = updateProductEntity.Images;
            request.PurchasedDate = updateProductEntity.PurchasedDate;
            request.PickupAddress = updateProductEntity.PickupAddress.ToEntity();
            request.PostDateTime = updateProductEntity.PostDateTime;
            request.PostDateTime = updateProductEntity.PostDateTime;
            request.ExpirationDate = updateProductEntity.ExpirationDate;
            request.Status = updateProductEntity.Status;

            return request;
        }
        public static UpdateProductEntity ToResponseModel(this Contracts.UpdateProductEntity updateProductEntity)
        {
            UpdateProductEntity response = new UpdateProductEntity()
            {
                Id = updateProductEntity.Id,
                Name = updateProductEntity.Name,
                Description = updateProductEntity.Description,
                HeroImage = updateProductEntity.HeroImage,
                Price = updateProductEntity.Price.ToModel(),
                Category = updateProductEntity.Category,
                Status = updateProductEntity.Status,
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
