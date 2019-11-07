using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineRetailPortal.Core
{
    public static class GetProductServiceResponseTranslator
    {
        public static Product ToModel(this GetProductStoreResponse getProductResponse)
        {
            Price price = getProductResponse.Product.Price.ToEntity();
            Product response = new Product(price,getProductResponse.Product.SellerId,getProductResponse.Product.Name)
            
                {
                    Id = getProductResponse.Product.Id,
                    HeroImage = getProductResponse.Product.HeroImage.ToEntity(),
                    ExpirationDate = getProductResponse.Product.ExpirationDate,
                    PostDateTime = getProductResponse.Product.PostDateTime,
                    Description = getProductResponse.Product.Description,          
                    PurchasedDate = getProductResponse.Product.PurchasedDate,
                    PickupAddress = getProductResponse.Product.PickupAddress.ToEntity(),
                    Images = getProductResponse.Product.Images.ToEntity(),
                    Status = getProductResponse.Product.Status.ToEntity(),
                    Category = getProductResponse.Product.Category.ToEntity()

            };

            return response;
        }
        public static Price ToEntity(this Contracts.Price getPrice)
        {

            return new Price()
            {
                Money = new Money(
                getPrice.Money.Amount,
                getPrice.Money.Currency),
                IsNegotiable = getPrice.IsNegotiable,

            };

        }

        public static Image ToEntity(this Contracts.Image image)
        {
            return new Image()
            {
                Url = image.Url
            };
        }
        //category will change after category api implementation
        public static Category ToEntity(this Contracts.Category category)
        {
            switch (category)
            {
                case Contracts.Category.Property:
                    return Category.Property;
                case Contracts.Category.Car:
                    return Category.Car;
                case Contracts.Category.Furniture:
                    return Category.Furniture;
                case Contracts.Category.Mobile:
                    return Category.Mobile;
                case Contracts.Category.Bike:
                    return Category.Bike;
                case Contracts.Category.Book:
                    return Category.Book;
                case Contracts.Category.Fashion:
                    return Category.Fashion;
                case Contracts.Category.Electronic:
                    return Category.Electronic;
                case Contracts.Category.Other:
                    return Category.Other;
                default:
                    throw new NotSupportedException($"This category is not supported:{category}");
            }
        }
        public static Status ToEntity(this Contracts.Status status)
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
                    throw new NotSupportedException($"This status is not supported:{status}");
            }
        }
        public static Address ToEntity(this Contracts.Address pickupAddress)
        {
            if (pickupAddress == null)
                return null;
            return new Address()
            {
                Line1 = pickupAddress.Line1,
                Line2 = pickupAddress.Line2,
                City = pickupAddress.City,
                Pincode = pickupAddress.Pincode,
                State = pickupAddress.State
            };
        }
        public static DateTime? ToEntity(this DateTime? purchasedDate)
        {
            if (purchasedDate == null)
                return null;
            return purchasedDate;
        }
        public static List<Image> ToEntity(this List<Contracts.Image> images)
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

