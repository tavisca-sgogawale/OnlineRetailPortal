using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Core
{
    public static class UpdateProductTranslator
    {
        public static ProductEntity ToStoreEntity(this Product updateProduct)
        {
            var updateProductStoreRequest = new ProductEntity();
            updateProductStoreRequest.Id = updateProduct.Id;
            updateProductStoreRequest.Name = updateProduct.Name;
            updateProductStoreRequest.Description = updateProduct.Description;
            updateProductStoreRequest.HeroImage = updateProduct.HeroImage;
            updateProductStoreRequest.Price = updateProduct.Price.ToEntity();
            updateProductStoreRequest.Category = updateProduct.Category.ToEntity();
            updateProductStoreRequest.Images = updateProduct.Images;
            updateProductStoreRequest.PurchasedDate =updateProduct.PurchasedDate;
            updateProductStoreRequest.PickupAddress = updateProduct.PickupAddress.ToEntity();
            updateProductStoreRequest.PostDateTime = updateProduct.PostDateTime;
            updateProductStoreRequest.ExpirationDate = updateProduct.ExpirationDate;
            updateProductStoreRequest.Status = updateProduct.Status.ToEntity();

            return updateProductStoreRequest;
        }

        public static Product ToStoreModel(this ProductEntity addProductStoreResponse)
        {
            if (addProductStoreResponse == null)
                return null;
            var product = new Product(addProductStoreResponse.Price.ToModel(), addProductStoreResponse.SellerId, addProductStoreResponse.Name)
            {
                Id = addProductStoreResponse.Id,
                Description = addProductStoreResponse.Description,
                HeroImage = addProductStoreResponse.HeroImage,
                Category = addProductStoreResponse.Category.ToModel(),
                Status = addProductStoreResponse.Status.ToModel(),
                PostDateTime = addProductStoreResponse.PostDateTime,
                ExpirationDate = addProductStoreResponse.ExpirationDate,
                Images = addProductStoreResponse.Images,
                PurchasedDate = addProductStoreResponse.PurchasedDate,
                PickupAddress = addProductStoreResponse.PickupAddress.ToModel()
            };

            return product;
        }
    }
}
