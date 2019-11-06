using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OnlineRetailPortal.Mock
{
    public static class AddProductTranslator
    {
        public static Product ToModel(this AddProductStoreRequest request)
        {
            var product = new Product()
            {
                SellerId = request.SellerId,
                Name = request.Name,
                Description = request.Description,
                HeroImage = request.HeroImage.ToModel(),
                Price = request.Price.ToModel(),
                Category = request.Category.ToModel(),
                Images = request.Images.ToModel(),
                PurchasedDate = request.PurchasedDate,
                PickupAddress = request.PickupAddress.ToModel()
            };

            return product;
        }

        public static AddProductStoreResponse ToEntity(this Product product)
        {
            var entityPostResponse = new AddProductStoreResponse()
            {
                SellerId = product.SellerId,
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                HeroImage = product.HeroImage.ToEntity(),
                Price = product.Price.ToEntity(),
                Category = product.Category.ToEntity(),
                Status = product.Status.ToEntity(),
                PostDateTime = product.PostDateTime,
                ExpirationDate = product.ExpirationDate,
                Images = product.Images.ToEntity(),
                PurchasedDate = product.PurchasedDate,
                PickupAddress = product.PickupAddress.ToEntity()
            };

            return entityPostResponse;
        }
    }
}
