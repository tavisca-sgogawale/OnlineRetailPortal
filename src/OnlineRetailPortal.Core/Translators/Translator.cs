using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Core;
using System;
using System.Linq;

namespace OnlineRetailPortal.Core
{
    public static class Translator
    {
        public static AddProductStoreRequest ToEntityRequest(this Product product)
        {
            AddProductStoreRequest  entityStoreRequest = new AddProductStoreRequest() {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                HeroImage = new Contracts.Image { Url = product.HeroImage.Url},
                Price = new Contracts.Price { Amount = product.Price.Amount, IsNegotiable = product.Price.IsNegotiable},
                Category = (Contracts.Category)product.Category.GetHashCode(),
                Images = product.Images.Select(x => new Contracts.Image
                {
                    Url = x.Url
                }).ToList(),
                PurchasedDate = product.PurchasedDate,
                PickupAddress = new Contracts.Address
                {
                    Line1 = product.PickupAddress.Line1,
                    Line2 = product.PickupAddress.Line2,
                    City = product.PickupAddress.City,
                    Pincode = product.PickupAddress.Pincode,
                    State = product.PickupAddress.State
        }
            };

            return entityStoreRequest;
        }

        public static Product ToProduct(this AddProductStoreResponse entityStoreResponse)
        {
            Product product = new Product() {
                Id = entityStoreResponse.Id,
                Name = entityStoreResponse.Name,
                Description = entityStoreResponse.Description,
                HeroImage = new Image { Url = entityStoreResponse.HeroImage.Url },
                Price = new Price { Amount = entityStoreResponse.Price.Amount, IsNegotiable = entityStoreResponse.Price.IsNegotiable },
                Category = (Category)entityStoreResponse.Category.GetHashCode(),
                Status = (Status)entityStoreResponse.Status.GetHashCode(),
                PostDateTime = entityStoreResponse.PostDateTime,
                ExpirationDate = entityStoreResponse.ExpirationDate,
                Images = entityStoreResponse.Images.Select(x => new Image
                {
                    Url = x.Url
                }).ToList(),
                PurchasedDate = entityStoreResponse.PurchasedDate,
                PickupAddress = new Address
                {
                    Line1 = entityStoreResponse.PickupAddress.Line1,
                    Line2 = entityStoreResponse.PickupAddress.Line2,
                    City = entityStoreResponse.PickupAddress.City,
                    Pincode = entityStoreResponse.PickupAddress.Pincode,
                    State = entityStoreResponse.PickupAddress.State
                }
            };

            return product;
        }
    }
}
