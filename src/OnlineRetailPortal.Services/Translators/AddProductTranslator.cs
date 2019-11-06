using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Core;

namespace OnlineRetailPortal.Services
{
    public static class AddProductTranslator
    {
        public static Core.Product ToEntity(this Contracts.AddProductRequest addProductRequest, IProductStore productStore)
        {
            var product = new Core.Product(productStore, addProductRequest.SellerId,addProductRequest.Name,addProductRequest.Price.ToEntity())
            {
                Description = addProductRequest.Description,
                HeroImage = addProductRequest.HeroImage.ToEntity(),
                Category = addProductRequest.Category.ToEntity(),
                Images = addProductRequest.Images.ToEntity(),
                PurchasedDate = addProductRequest.PurchasedDate,
                PickupAddress = addProductRequest.PickupAddress.ToEntity()
            };
            return product;
        }

        public static Core.Image ToEntity(this Contracts.Image image)
        {
            return new Core.Image()
            {
                Url = image.Url
            };
        }

        public static Core.Price ToEntity(this Contracts.Price price)
        {
            return new Core.Price()
            {
                Money = new Core.Money(
                price.Money.Amount,
                price.Money.Currency),
                IsNegotiable = price.IsNegotiable
            };
        }

        public static Core.Category ToEntity(this Contracts.Category category)
        {
            switch (category)
            {
                case Contracts.Category.Bike:
                    return Core.Category.Bike;
                case Contracts.Category.Book:
                    return Core.Category.Book;
                case Contracts.Category.Car:
                    return Core.Category.Car;
                case Contracts.Category.Electronic:
                    return Core.Category.Electronic;
                case Contracts.Category.Fashion:
                    return Core.Category.Fashion;
                case Contracts.Category.Furniture:
                    return Core.Category.Furniture;
                case Contracts.Category.Mobile:
                    return Core.Category.Mobile;
                case Contracts.Category.Other:
                    return Core.Category.Other;
                case Contracts.Category.Property:
                    return Core.Category.Property;
                default:
                    return Core.Category.Other;
            }
        }

        public static List<Core.Image> ToEntity(this List<Contracts.Image> images)
        {
            if (images == null)
                return null;
            return new Core.Product().Images = images.Select(x => new Core.Image
            {
                Url = x.Url
            }).ToList();
        }

        public static Core.Address ToEntity(this Contracts.Address pickupAddress)
        {
            if (pickupAddress == null)
                return null;
            return new Core.Product().PickupAddress = new Core.Address()
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
                ProductId = product.Id,
                SellerId = product.SellerId,
                Name = product.Name,
                Description = product.Description,
                HeroImage = product.HeroImage.ToModel(),
                Price = product.Price.ToModel(),
                Category = product.Category.ToModel(),
                Status = product.Status.ToModel(),
                PostDateTime = product.PostDateTime,
                ExpirationDate = product.ExpirationDate,
                Images = product.Images.ToModel(),
                PurchasedDate = product.PurchasedDate,
                PickupAddress = product.PickupAddress.ToModel()
            };

            return response;
        }

        public static Contracts.Price ToModel(this Core.Price price)
        {
            return new Contracts.Price()
            {
                Money = new Contracts.Money(
                price.Money.Amount,
                price.Money.Currency),
                IsNegotiable = price.IsNegotiable
            };
        }

        public static Contracts.Image ToModel(this Core.Image image)
        {
            return new Contracts.Image()
            {
                Url = image.Url
            };
        }

        public static Contracts.Category ToModel(this Core.Category category)
        {
            switch (category)
            {
                case Core.Category.Bike:
                    return Contracts.Category.Bike;
                case Core.Category.Book:
                    return Contracts.Category.Book;
                case Core.Category.Car:
                    return Contracts.Category.Car;
                case Core.Category.Electronic:
                    return Contracts.Category.Electronic;
                case Core.Category.Fashion:
                    return Contracts.Category.Fashion;
                case Core.Category.Furniture:
                    return Contracts.Category.Furniture;
                case Core.Category.Mobile:
                    return Contracts.Category.Mobile;
                case Core.Category.Other:
                    return Contracts.Category.Other;
                case Core.Category.Property:
                    return Contracts.Category.Property;
                default:
                    return Contracts.Category.Other;
            }
        }

        public static Contracts.Status ToModel(this Core.Status status)
        {
            switch (status)
            {
                case Core.Status.Active:
                    return Contracts.Status.Active;
                case Core.Status.Disabled:
                    return Contracts.Status.Disabled;
                case Core.Status.Sold:
                    return Contracts.Status.Sold;
                default:
                    return Contracts.Status.Active;
            }
        }

        public static List<Contracts.Image> ToModel(this List<Core.Image> images)
        {
            if (images == null)
                return null;
            return images.Select(x => new Contracts.Image
            {
                Url = x.Url
            }).ToList();
        }

        public static Contracts.Address ToModel(this Core.Address address)
        {
            if (address == null)
                return null;
            return new Contracts.Address()
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
