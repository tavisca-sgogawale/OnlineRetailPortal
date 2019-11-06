using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Core;
using System;
using System.Collections.Generic;
using System.Linq;
namespace OnlineRetailPortal.Core
{
    public static class AddProductTranslator
    {
        public static AddProductStoreRequest ToEntity(this Product product)
        {
            var  addProductStoreRequest = new AddProductStoreRequest() {
                SellerId = product.SellerId,
                Name = product.Name,
                Description = product.Description,
                HeroImage = product.HeroImage.ToEntity(),
                Price = product.Price.ToEntity(),
                Category = product.Category.ToEntity(),
                Images = product.Images.ToEntity(),                
                PurchasedDate = product.PurchasedDate.ToEntity(),
                PickupAddress = product.PickupAddress.ToEntity()
                
            };

            return addProductStoreRequest;
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
            return new Contracts.Product().PurchasedDate = purchasedDate;
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

       


        public static Product ToModel(this AddProductStoreResponse addProductStoreResponse)
        {
            var product = new Product(addProductStoreResponse.SellerId, addProductStoreResponse.Name, new Price { Money = new Money(addProductStoreResponse.Price.Money.Amount, addProductStoreResponse.Price.Money.Currency), IsNegotiable = addProductStoreResponse.Price.IsNegotiable })
            {
                Id = addProductStoreResponse.Id,
                Description = addProductStoreResponse.Description,
                HeroImage = addProductStoreResponse.HeroImage.ToModel(),
                Category = addProductStoreResponse.Category.ToModel(),
                Status = addProductStoreResponse.Status.ToModel(),
                PostDateTime = addProductStoreResponse.PostDateTime,
                ExpirationDate = addProductStoreResponse.ExpirationDate,
                Images = addProductStoreResponse.Images.ToModel(),
                PurchasedDate = addProductStoreResponse.PurchasedDate.ToModel(),
                PickupAddress = addProductStoreResponse.PickupAddress.ToModel()
            };

            return product;
        }

        public static Image ToModel(this Contracts.Image image)
        {
            return new Image()
            {
                Url = image.Url
            };
        }

        public static Category ToModel(this Contracts.Category category)
        {
            switch (category)
            {
                case Contracts.Category.Bike:
                    return Category.Bike;
                case Contracts.Category.Book:
                    return Category.Book;
                case Contracts.Category.Car:
                    return Category.Car;
                case Contracts.Category.Electronic:
                    return Category.Electronic;
                case Contracts.Category.Fashion:
                    return Category.Fashion;
                case Contracts.Category.Furniture:
                    return Category.Furniture;
                case Contracts.Category.Mobile:
                    return Category.Mobile;
                case Contracts.Category.Other:
                    return Category.Other;
                case Contracts.Category.Property:
                    return Category.Property;
                default:
                    return Category.Other;
            }
        }

        public static Status ToModel(this Contracts.Status status)
        {
            switch (status)
            {
                case Contracts.Status.Active:
                    return Status.Active;
                case Contracts.Status.Disabled:
                    return Status.Disabled;
                case Contracts.Status.Sold:
                    return Status.Sold;
                default:
                    return Status.Active;
            }
        }

        public static List<Image> ToModel(this List<Contracts.Image> images)
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

        public static Address ToModel(this Contracts.Address address)
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
