using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineRetailPortal.Core
{
    public static class AddProductTranslator
    {
        public static AddProductStoreRequest ToEntityRequest(this Product product)
        {
            var  addProductStoreRequest = new AddProductStoreRequest() {
                Name = product.Name,
                Description = product.Description,
                HeroImage = new Contracts.Image { Url = product.HeroImage.Url},
                Price = new Contracts.Price { Amount = product.Price.Amount, IsNegotiable = product.Price.IsNegotiable},
                Category = (Contracts.Category)product.Category,
                Images = GetImages(product.Images),
                PurchasedDate = GetPurchasedDates(product.PurchasedDate),
                PickupAddress = GetAddress(product.PickupAddress)
            };

            return addProductStoreRequest;
        }

        public static Product ToProduct(this AddProductStoreResponse addProductStoreResponse)
        {
            var product = new Product()
            {
                Id = addProductStoreResponse.Id,
                Name = addProductStoreResponse.Name,
                Description = addProductStoreResponse.Description,
                HeroImage = new Image { Url = addProductStoreResponse.HeroImage.Url },
                Price = new Price { Amount = addProductStoreResponse.Price.Amount, IsNegotiable = addProductStoreResponse.Price.IsNegotiable },
                Category = (Category)addProductStoreResponse.Category,
                Status = (Status)addProductStoreResponse.Status,
                PostDateTime = addProductStoreResponse.PostDateTime,
                ExpirationDate = addProductStoreResponse.ExpirationDate,
                Images = addProductStoreResponse.Images.Select(x => new Image
                {
                    Url = x.Url
                }).ToList(),
                PurchasedDate = addProductStoreResponse.PurchasedDate,
                PickupAddress = new Address
                {
                    Line1 = addProductStoreResponse.PickupAddress.Line1,
                    Line2 = addProductStoreResponse.PickupAddress.Line2,
                    City = addProductStoreResponse.PickupAddress.City,
                    Pincode = addProductStoreResponse.PickupAddress.Pincode,
                    State = addProductStoreResponse.PickupAddress.State
                }
            };

            return product;
        }

        private static Contracts.Address GetAddress(Address pickupAddress)
        {
            if (pickupAddress == null)
                return null;
            return new Contracts.Product().PickupAddress = new Contracts.Address()
            {
                Line1 = pickupAddress.Line1,
                Line2 = pickupAddress.Line2,
                City = pickupAddress.City,
                Pincode = pickupAddress.Pincode,
                State = pickupAddress.State
            };
        }

        private static DateTime? GetPurchasedDates(DateTime? purchasedDate)
        {
            if (purchasedDate == null)
                return null;
            return new Contracts.Product().PurchasedDate = purchasedDate;
        }

        private static List<Contracts.Image> GetImages(List<Image> images)
        {
            if (images == null)
                return null;
            return new Contracts.Product().Images = images.Select(x => new Contracts.Image
            {
                Url = x.Url
            }).ToList();
        }

        
    }
}
