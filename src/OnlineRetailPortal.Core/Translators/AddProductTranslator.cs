using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Core;
using System;
using System.Collections.Generic;
using System.Linq;
namespace OnlineRetailPortal.Core
{
    public static class AddProductTranslator
    {
        public static AddProductStoreRequest ToEntity(this Product product)
        {
            var  addProductStoreRequest = new AddProductStoreRequest() {
                SellerId = product.SellerId,
                Name = product.Name,
                Description = product.Description,
                HeroImage = product.HeroImage.ToEntity(),
                Price = product.Price.ToEntity(),
                Category = product.Category.ToEntity(),
                Images = product.Images.ToEntity(),                
                PurchasedDate = product.PurchasedDate,
                PickupAddress = product.PickupAddress.ToEntity()
                
            };

            return addProductStoreRequest;
        } 


        public static Product ToModel(this AddProductStoreResponse addProductStoreResponse)
        {
            var product = new Product(addProductStoreResponse.SellerId, addProductStoreResponse.Name, addProductStoreResponse.Price.ToModel()) { 
                Id = addProductStoreResponse.Id,
                Description = addProductStoreResponse.Description,
                HeroImage = addProductStoreResponse.HeroImage.ToModel(),
                Category = addProductStoreResponse.Category.ToModel(),
                Status = addProductStoreResponse.Status.ToModel(),
                PostDateTime = addProductStoreResponse.PostDateTime,
                ExpirationDate = addProductStoreResponse.ExpirationDate,
                Images = addProductStoreResponse.Images.ToModel(),
                PurchasedDate = addProductStoreResponse.PurchasedDate,
                PickupAddress = addProductStoreResponse.PickupAddress.ToModel()
            };

            return product;
        }      
    }
}
