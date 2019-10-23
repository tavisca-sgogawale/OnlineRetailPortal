using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Core;
using System;

namespace OnlineRetailPortal.Core
{
    public static class Translator
    {
        public static EntityPostRequest ToEntityRequest(this CorePostRequest product)
        {
            EntityPostRequest  entityStoreRequest = new EntityPostRequest();

            entityStoreRequest.Id = product.Id;

            entityStoreRequest.Name = product.Name;

            entityStoreRequest.Description = product.Description;

            entityStoreRequest.HeroImage.Url = product.HeroImage.Url;

            entityStoreRequest.Price.Amount = product.Price.Amount;
            entityStoreRequest.Price.isNegotiable = product.Price.isNegotiable;

            entityStoreRequest.Category = (Contracts.Category) product.Category.GetHashCode();

            for (int index = 0; index < product.Images.Count; index++)
                entityStoreRequest.Images[index].Url = product.Images[index].Url;

            entityStoreRequest.PurchasedDate = product.PurchasedDate;

            entityStoreRequest.PickupAddress.Line1 = product.PickupAddress.Line1;
            entityStoreRequest.PickupAddress.Line2 = product.PickupAddress.Line2;
            entityStoreRequest.PickupAddress.City = product.PickupAddress.City;
            entityStoreRequest.PickupAddress.Pincode = product.PickupAddress.Pincode;
            entityStoreRequest.PickupAddress.State = product.PickupAddress.State;

            return entityStoreRequest;
        }

        public static CorePostResponse ToProduct(this EntityPostResponse entityStoreResponse)
        {
            CorePostResponse product = new CorePostResponse();

            product.Id = entityStoreResponse.Id;

            product.Name = entityStoreResponse.Name;

            product.Description = entityStoreResponse.Description;

            product.HeroImage.Url = entityStoreResponse.HeroImage.Url;

            product.Price.Amount = entityStoreResponse.Price.Amount;
            product.Price.isNegotiable = entityStoreResponse.Price.isNegotiable;

            product.Category = (Category) entityStoreResponse.Category.GetHashCode();

            product.Status = (Status) entityStoreResponse.Status.GetHashCode();

            product.PostDateTime = entityStoreResponse.PostDateTime;

            product.ExpirationDate = entityStoreResponse.ExpirationDate;

            for (int index = 0; index < product.Images.Count; index++)
                product.Images[index].Url = entityStoreResponse.Images[index].Url;

            product.PurchasedDate = entityStoreResponse.PurchasedDate;

            product.PickupAddress.Line1 = entityStoreResponse.PickupAddress.Line1;
            product.PickupAddress.Line2 = entityStoreResponse.PickupAddress.Line2;
            product.PickupAddress.City = entityStoreResponse.PickupAddress.City;
            product.PickupAddress.Pincode = entityStoreResponse.PickupAddress.Pincode;
            product.PickupAddress.State = entityStoreResponse.PickupAddress.State;

            return product;
        }
    }
}
