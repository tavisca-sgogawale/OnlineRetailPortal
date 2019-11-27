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
            var updateProduct = new Core.Product();
            updateProduct.Id = updateProductEntity.Id;
            updateProduct.Name = updateProductEntity.Name;
            updateProduct.Price = updateProductEntity.Price.ToEntity();
            updateProduct.Description = updateProductEntity.Description;
            updateProduct.HeroImage = updateProductEntity.HeroImage;
            updateProduct.Category = updateProductEntity.Category.ToEntity();
            updateProduct.Images = updateProductEntity.Images;
            updateProduct.PurchasedDate = updateProductEntity.PurchasedDate;
            updateProduct.PickupAddress = updateProductEntity.PickupAddress.ToEntity();
            updateProduct.PostDateTime = updateProductEntity.PostDateTime;
            updateProduct.ExpirationDate = updateProductEntity.ExpirationDate;
            updateProduct.Status = updateProductEntity.Status.ToEntity();
            
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
