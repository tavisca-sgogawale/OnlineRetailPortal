﻿using OnlineRetailPortal.Contracts;

namespace OnlineRetailPortal.Mock
{
    public static class AddProductTranslator
    {
        public static Product ToModel(this ProductEntity request)
        {
            var product = new Product()
            {
                SellerId = request.SellerId,
                Name = request.Name,
                Description = request.Description,
                HeroImage = request.HeroImage,
                Price = request.Price,
                Category = request.Category,
                Images = request.Images,
                PurchasedDate = request.PurchasedDate,
                PickupAddress = request.PickupAddress
            };

            return product;
        }

        public static ProductEntity ToEntity(this Product product)
        {
            var entityPostResponse = new ProductEntity()
            {
                SellerId = product.SellerId,
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                HeroImage = product.HeroImage,
                Price = product.Price,
                Category = product.Category,
                Status = product.Status,
                PostDateTime = product.PostDateTime,
                ExpirationDate = product.ExpirationDate,
                Images = product.Images,
                PurchasedDate = product.PurchasedDate,
                PickupAddress = product.PickupAddress
            };

            return entityPostResponse;
        }
    }
}
