using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineRetailPortal.Services
{
    public static class GetProductServiceResponseTranslator
    {
        public static GetProductServiceResponse ToGetProductContract(this Core.Product getProductResponse)
        {
            GetProductServiceResponse response = new GetProductServiceResponse()
            {
                Product = new Product()
                {
                    Name = getProductResponse.Name,
                    Id = getProductResponse.Id,
                    HeroImage =  getProductResponse.HeroImage.ToEntity(),
                    ExpirationDate = getProductResponse.ExpirationDate,
                    PostDateTime = getProductResponse.PostDateTime,
                    Description = getProductResponse.Description,
                    Price = getProductResponse.Price.ToEntity(),
                    PurchasedDate = getProductResponse.PurchasedDate,
                    PickupAddress = getProductResponse.PickupAddress.ToEntity(),
                    Images = getProductResponse.Images.ToEntity(),
                    Status = getProductResponse.Status.ToEntity(),
                    Category = getProductResponse.Category.ToEntity()
                }
            };
            
            return response;
        }
        public static Price ToEntity(this Core.Price getPrice)
        {

            return new Price()
            {
                Money = new Money(
                getPrice.Money.Amount,
                getPrice.Money.Currency),
                IsNegotiable = getPrice.IsNegotiable,

            };

        }

        public static Image ToEntity(this Core.Image image)
        {
            return new Image()
            {
                Url = image.Url
            };
        }
        //category will change after category api implementation
        public static Category ToEntity(this Core.Category category)
        {
            switch (category)
            {
                case Core.Category.Property:
                    return Category.Property;
                case Core.Category.Car:
                    return Category.Car;
                case Core.Category.Furniture:
                    return Category.Furniture;
                case Core.Category.Mobile:
                    return Category.Mobile;
                case Core.Category.Bike:
                    return Category.Bike;
                case Core.Category.Book:
                    return Category.Book;
                case Core.Category.Fashion:
                    return Category.Fashion;
                case Core.Category.Electronic:
                    return Category.Electronic;
                case Core.Category.Other:
                    return Category.Other;
                default:
                    throw new NotSupportedException($"This category is not supported:{category}");

            }
        }
        public static Status ToEntity(this Core.Status status)
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
                    throw new NotSupportedException($"This status is not supported:{status}");

            }
        }
        public static Address ToEntity(this Core.Address pickupAddress)
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
        public static List<Image> ToEntity(this List<Core.Image> images)
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
