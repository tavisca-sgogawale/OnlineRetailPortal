using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Core;
using System;

namespace OnlineRetailPortal.Core
{
    public class Translator
    {
        public EntityPostRequest ToEntityRequest(CorePostRequest product)
        {
            EntityPostRequest  entityStoreRequest = new EntityPostRequest();
            entityStoreRequest.Id = product.Id;
            entityStoreRequest.Name = product.Name;
            entityStoreRequest.Description = product.Description;
            //entityStoreRequest.HeroImage = product.HeroImage;
            //entityStoreRequest.Price = product.Price;
            //entityStoreRequest.Category = product.Category;
            //entityStoreRequest.Images = product.Images;
            //entityStoreRequest.PurchasedDate = product.PurchasedDate;
            //entityStoreRequest.PickupAddress = product.PickupAddress;
            
            return entityStoreRequest;
        }

        public CorePostResponse ToProduct(EntityPostResponse entityStoreResponse)
        {
            CorePostResponse product = new CorePostResponse();
            product.Id = entityStoreResponse.Id;
            product.Name = entityStoreResponse.Name;
            product.Description = entityStoreResponse.Description;
            //product.HeroImage = entityStoreResponse.HeroImage;
            //product.Price = entityStoreResponse.Price;
            //product.Category = entityStoreResponse.Category;
            //product.Status = entityStoreResponse.Status;
            //product.PostDateTime = entityStoreResponse.PostDateTime;
            //product.ExpirationDate = entityStoreResponse.ExpirationDate;
            //product.Images = entityStoreResponse.Images;
            //product.PurchasedDate = entityStoreResponse.PurchasedDate;
            //product.PickupAddress = entityStoreResponse.PickupAddress;

            return product;
        }
    }
}
