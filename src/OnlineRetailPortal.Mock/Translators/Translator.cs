using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OnlineRetailPortal.Mock
{
    public static class Translator
    {
        public static Product ToProduct(this AddProductStoreRequest request)
        {
            if (request == null)
                return null;

            var product = new Product()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                HeroImage = new Image() { Url = request.HeroImage.Url },
                Price = new Price() { Amount = request.Price.Amount, IsNegotiable = request.Price.IsNegotiable },
                Category = (Category)request.Category,
                Images = GetImages(request.Images),
                PurchasedDate = GetPurchasedDates(request.PurchasedDate),
                PickupAddress = GetAddress(request.PickupAddress)
            };

            return product;
        }

        private static Address GetAddress(Contracts.Address pickupAddress)
        {
            if (pickupAddress == null)
                return null;
            return new Product().PickupAddress = new Address()
            {
                Line1 = pickupAddress.Line1,
                Line2 = pickupAddress.Line2,
                City =pickupAddress.City,
                Pincode = pickupAddress.Pincode,
                State = pickupAddress.State
            };
        }

        private static DateTime? GetPurchasedDates(DateTime? purchasedDate)
        {
            if (purchasedDate == null)
                return null;
            return new Product().PurchasedDate = purchasedDate;
        }

        private static List<Image> GetImages(List<Contracts.Image> images)
        {
            if (images == null)
                return null;
            return new Product().Images = images.Select(x => new Image
            {
                Url = x.Url
            }).ToList();
        }

        public static AddProductStoreResponse ToEntityResponse(this Product product)
        {
            var entityPostResponse = new AddProductStoreResponse() {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                HeroImage = new Contracts.Image() { Url = product.HeroImage.Url },
                Price = new Contracts.Price() { Amount = product.Price.Amount, IsNegotiable = product.Price.IsNegotiable },
                Category = (Contracts.Category)product.Category,
                Status = (Contracts.Status)product.Status,
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
