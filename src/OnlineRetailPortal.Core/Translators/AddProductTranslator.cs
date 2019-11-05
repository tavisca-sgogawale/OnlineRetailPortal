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
                SellerId = product.SellerId,
                Name = product.Name,
                Description = product.Description,
                HeroImage = new Contracts.Image { Url = product.HeroImage.Url},
                Price = new Contracts.Price { Value = new Contracts.Value(product.Price.Value.Amount, product.Price.Value.Currency), IsNegotiable = product.Price.IsNegotiable},
                Category = (Contracts.Category)product.Category,
                Images = GetImages(product.Images),                
                PurchasedDate = GetPurchasedDates(product.PurchasedDate),
                PickupAddress = GetAddress(product.PickupAddress)
                
            };

            return addProductStoreRequest;
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

        public static Product ToProduct(this AddProductStoreResponse addProductStoreResponse)
        {
            var product = new Product(addProductStoreResponse.SellerId, addProductStoreResponse.Name, new Price { Value = new Value(addProductStoreResponse.Price.Value.Amount, addProductStoreResponse.Price.Value.Currency), IsNegotiable = addProductStoreResponse.Price.IsNegotiable })
            {
                ProductId = addProductStoreResponse.ProductId,
                Description = addProductStoreResponse.Description,
                HeroImage = new Image { Url = addProductStoreResponse.HeroImage.Url },
                Category = (Category)addProductStoreResponse.Category,
                Status = (Status)addProductStoreResponse.Status,
                PostDateTime = addProductStoreResponse.PostDateTime,
                ExpirationDate = addProductStoreResponse.ExpirationDate,
                Images = GetImagesResponse(addProductStoreResponse.Images),
                PurchasedDate = GetPurchasedDates(addProductStoreResponse.PurchasedDate),
                PickupAddress = GetAddressResponse(addProductStoreResponse.PickupAddress)
            };

            return product;
        }

        private static Address GetAddressResponse(Contracts.Address address)
        {
            if (address == null)
                return null;
            return new Address()
            {
                Line1 = address.Line1,
                Line2 = address.Line2,
                City = address.City,
                Pincode = address.Pincode,
                State = address.State
            };
        }

        private static List<Image> GetImagesResponse(List<Contracts.Image> images)
        {
            if (images == null)
                return null;
            return images.Select(x => new Image
            {
                Url = x.Url
            }).ToList();
        }
    }
}
