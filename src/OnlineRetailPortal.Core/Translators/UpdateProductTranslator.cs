using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Core
{
    public static class UpdateProductTranslator
    {
        public static ProductEntity ToStoreEntity(this Product product)
        {
            var addProductStoreRequest = new ProductEntity()
            {
                Id = product.Id,
                SellerId = product.SellerId,
                Name = product.Name,
                Description = product.Description,
                HeroImage = product.HeroImage,
                Price = product.Price.ToEntity(),
                Category = product.Category.ToEntity(),
                Images = product.Images,
                PurchasedDate = product.PurchasedDate,
                PickupAddress = product.PickupAddress.ToEntity(),
                PostDateTime = product.PostDateTime,
                ExpirationDate = product.ExpirationDate,
                Status = product.Status.ToEntity()

            };

            return addProductStoreRequest;
        }


        public static Product ToStoreModel(this ProductEntity addProductStoreResponse)
        {
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
