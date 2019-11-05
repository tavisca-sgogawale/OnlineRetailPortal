using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineRetailPortal.Contracts;

namespace OnlineRetailPortal.Services
{
    public static class AddProductTranslator
    {
        public static Product ToEntity(this Contracts.AddProductRequest addProductRequest)
        {
            var product = new Product()
            {
                SellerId = addProductRequest.SellerId,
                Name = addProductRequest.Name,
                Description = addProductRequest.Description,
                HeroImage = addProductRequest.HeroImage.ToEntity(),
                Price = addProductRequest.Price.ToEntity(),
                Category = addProductRequest.Category.ToEntity(),
                Images = addProductRequest.Images.ToEntity(),
                PurchasedDate = addProductRequest.PurchasedDate.ToEntity(),
                PickupAddress = addProductRequest.PickupAddress.ToEntity()
            };
            return product;
        }

        public static Contracts.Image ToEntity(this Image image)
        {
            return new Contracts.Image()
            {
                Url = image.Url
            };
        }

        public static Contracts.Price ToEntity(this Price price)
        {
            return new Contracts.Price()
            {
                Money = new Contracts.Money(
                price.Money.Amount,
                price.Money.Currency),
                IsNegotiable = price.IsNegotiable
            };
        }

        public static Contracts.Category ToEntity(this Category category)
        {
            switch (category)
            {
                case Category.Bike:
                    return Contracts.Category.Bike;
                case Category.Book:
                    return Contracts.Category.Book;
                case Category.Car:
                    return Contracts.Category.Car;
                case Category.Electronic:
                    return Contracts.Category.Electronic;
                case Category.Fashion:
                    return Contracts.Category.Fashion;
                case Category.Furniture:
                    return Contracts.Category.Furniture;
                case Category.Mobile:
                    return Contracts.Category.Mobile;
                case Category.Other:
                    return Contracts.Category.Other;
                case Category.Property:
                    return Contracts.Category.Property;
                default:
                    return Contracts.Category.Other;
            }
        }

        public static List<Contracts.Image> ToEntity(this List<Image> images)
        {
            if (images == null)
                return null;
            return new Contracts.Product().Images = images.Select(x => new Contracts.Image
            {
                Url = x.Url
            }).ToList();
        }

        public static DateTime? ToEntity(this DateTime? purchasedDate)
        {
            if (purchasedDate == null)
                return null;
            return new Contracts.AddProductRequest().PurchasedDate = purchasedDate;
        }

        public static Contracts.Address ToEntity(this Address pickupAddress)
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




        public static Contracts.AddProductResponse ToModel(this Core.Product product)
        {
            Contracts.AddProductResponse response = new Contracts.AddProductResponse()
            {
                ProductId = product.ProductId,
                SellerId = product.SellerId,
                Description = product.Description,
                HeroImage = product.HeroImage.ToModel(),
                Category = product.Category.ToModel(),
                Status = product.Status.ToModel(),
                PostDateTime = product.PostDateTime,
                ExpirationDate = product.ExpirationDate,
                Images = product.Images.ToModel(),
                PurchasedDate = product.PurchasedDate.ToModel(),
                PickupAddress = product.PickupAddress.ToModel()
            };

            return response;
        }

        public static Image ToModel(this Core.Image image)
        {
            return new Image()
            {
                Url = image.Url
            };
        }

        public static Category ToModel(this Core.Category category)
        {
            switch (category)
            {
                case Core.Category.Bike:
                    return Category.Bike;
                case Core.Category.Book:
                    return Category.Book;
                case Core.Category.Car:
                    return Category.Car;
                case Core.Category.Electronic:
                    return Category.Electronic;
                case Core.Category.Fashion:
                    return Category.Fashion;
                case Core.Category.Furniture:
                    return Category.Furniture;
                case Core.Category.Mobile:
                    return Category.Mobile;
                case Core.Category.Other:
                    return Category.Other;
                case Core.Category.Property:
                    return Category.Property;
                default:
                    return Category.Other;
            }
        }

        public static Status ToModel(this Core.Status status)
        {
            switch (status)
            {
                case Core.Status.Active:
                    return Status.Active;
                case Core.Status.Disabled:
                    return Status.Disabled;
                case Core.Status.Sold:
                    return Status.Sold;
                default:
                    return Status.Active;
            }
        }

        public static List<Image> ToModel(this List<Core.Image> images)
        {
            if (images == null)
                return null;
            return images.Select(x => new Image
            {
                Url = x.Url
            }).ToList();
        }

        public static DateTime? ToModel(this DateTime? purchasedDate)
        {
            if (purchasedDate == null)
                return null;
            return purchasedDate;
        }

        public static Address ToModel(this Core.Address address)
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
    }
}
