using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OnlineRetailPortal.Mock
{
    public static class Translator
    {
        public static Product ToProduct(this EntityPostRequest entityPostRequest)
        {
            Product product = new Product() {
                Id = entityPostRequest.Id,
                Name = entityPostRequest.Name,
                Description = entityPostRequest.Description,
                HeroImage = new Image() { Url = entityPostRequest.HeroImage.Url },
                Price = new Price() { Amount = entityPostRequest.Price.Amount, IsNegotiable = entityPostRequest.Price.IsNegotiable },
                Category = (Category)entityPostRequest.Category.GetHashCode(),
                Images = entityPostRequest.Images.Select(x => new Image
                {
                    Url = x.Url
                }).ToList(),
                PurchasedDate = entityPostRequest.PurchasedDate,
                PickupAddress = new Address()
                {
                    Line1 = entityPostRequest.PickupAddress.Line1,
                    Line2 = entityPostRequest.PickupAddress.Line2,
                    City = entityPostRequest.PickupAddress.City,
                    Pincode = entityPostRequest.PickupAddress.Pincode,
                    State = entityPostRequest.PickupAddress.State
                }
            };

            return product;
        }

        public static EntityPostResponse ToEntityResponse(this Product product)
        {
            EntityPostResponse entityPostResponse = new EntityPostResponse() {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                HeroImage = new Contracts.Image() { Url = product.HeroImage.Url },
                Price = new Contracts.Price() { Amount = product.Price.Amount, IsNegotiable = product.Price.IsNegotiable },
                Category = (Contracts.Category)product.Category.GetHashCode(),
                Status = (Contracts.Status)product.Status.GetHashCode(),
                PostDateTime = product.PostDateTime,
                ExpirationDate = product.ExpirationDate,
                Images = product.Images.Select(x => new Contracts.Image
                {
                    Url = x.Url
                }).ToList(),
                PurchasedDate = product.PurchasedDate,
                PickupAddress = new Contracts.Address()
                {
                    Line1 = product.PickupAddress.Line1,
                    Line2 = product.PickupAddress.Line2,
                    City = product.PickupAddress.City,
                    Pincode = product.PickupAddress.Pincode,
                    State = product.PickupAddress.State
                }
            };

            return entityPostResponse;
        }
    }
}
