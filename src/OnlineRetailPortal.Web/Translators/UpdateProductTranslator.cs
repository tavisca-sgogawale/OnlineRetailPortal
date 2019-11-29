using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Web
{
    public static class UpdateProductTranslator
    {
        public static ProductEntity ToEntity(this Product updateProductEntity,string productId)
        {
            Contracts.ProductEntity request = new Contracts.ProductEntity()
            {
                Id = productId,
                Name = updateProductEntity.Name,
                Category = updateProductEntity.Category.ToEntity(),
                Description = updateProductEntity.Description,
                HeroImage = updateProductEntity.HeroImage,
                Price = updateProductEntity.Price.ToEntity(),
                Images = updateProductEntity.Images,
                PurchasedDate = updateProductEntity.PurchasedDate,
                PickupAddress = updateProductEntity.PickupAddress.ToEntity(),
                PostDateTime = updateProductEntity.PostDateTime,
                ExpirationDate = updateProductEntity.ExpirationDate ?? new DateTime(),
                Status = updateProductEntity.Status.ToStatusEntity()
            };         
            return request;
        }
        public static Product ToResponseModel(this Contracts.Product updateProductEntity)
        {
            Product response = new Product()
            {
                Id = updateProductEntity.Id,
                Name = updateProductEntity.Name,
                Description = updateProductEntity.Description,
                HeroImage = updateProductEntity.HeroImage,
                Price = updateProductEntity.Price.ToModel(),
                Category = updateProductEntity.Category.Name,
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
