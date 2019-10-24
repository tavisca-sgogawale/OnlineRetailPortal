using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Mock
{
    public static class Translator
    {
        public static Product ToProduct(this EntityPostRequest entityPostRequest)
        {
            Product product = new Product();

            product.Id = entityPostRequest.Id;

            product.Name = entityPostRequest.Name;

            product.Description = entityPostRequest.Description;

            product.HeroImage.Url = entityPostRequest.HeroImage.Url;

            product.Price.Amount = entityPostRequest.Price.Amount;
            product.Price.isNegotiable = entityPostRequest.Price.isNegotiable;

            product.Category = (Category)entityPostRequest.Category.GetHashCode();

            for (int index = 0; index < entityPostRequest.Images.Count; index++)
                product.Images[index].Url = entityPostRequest.Images[index].Url;

            product.PurchasedDate = entityPostRequest.PurchasedDate;

            product.PickupAddress.Line1 = entityPostRequest.PickupAddress.Line1;
            product.PickupAddress.Line2 = entityPostRequest.PickupAddress.Line2;
            product.PickupAddress.City = entityPostRequest.PickupAddress.City;
            product.PickupAddress.Pincode = entityPostRequest.PickupAddress.Pincode;
            product.PickupAddress.State = entityPostRequest.PickupAddress.State;

            return product;
        }

        public static EntityPostResponse ToEntityResponse(this Product product)
        {
            EntityPostResponse entityPostResponse = new EntityPostResponse();

            entityPostResponse.Id = product.Id;

            entityPostResponse.Name = product.Name;

            entityPostResponse.Description = product.Description;

            entityPostResponse.HeroImage.Url = product.HeroImage.Url;

            entityPostResponse.Price.Amount = product.Price.Amount;
            entityPostResponse.Price.isNegotiable = product.Price.isNegotiable;

            entityPostResponse.Category = (Contracts.Category)product.Category.GetHashCode();

            entityPostResponse.Status = (Contracts.Status)product.Status.GetHashCode();

            entityPostResponse.PostDateTime = product.PostDateTime;

            entityPostResponse.ExpirationDate = product.ExpirationDate;
            
            for (int index = 0; index < product.Images.Count; index++)
                entityPostResponse.Images[index].Url = product.Images[index].Url;

            entityPostResponse.PurchasedDate = product.PurchasedDate;

            entityPostResponse.PickupAddress.Line1 = product.PickupAddress.Line1;
            entityPostResponse.PickupAddress.Line2 = product.PickupAddress.Line2;
            entityPostResponse.PickupAddress.City = product.PickupAddress.City;
            entityPostResponse.PickupAddress.Pincode = product.PickupAddress.Pincode;
            entityPostResponse.PickupAddress.State = product.PickupAddress.State;

            return entityPostResponse;
        }
    }
}
