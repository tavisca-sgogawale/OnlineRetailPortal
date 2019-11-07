using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Web
{
    public static class GetProductResponseTranslator
    {
        public static GetProductResponse ToEntity(this Contracts.GetProductServiceResponse getProductServiceResponse)
        {
            GetProductResponse response = new GetProductResponse()
            {
                Product = new Product()
                {
                    Name = getProductServiceResponse.Product.Name,
                    Id = getProductServiceResponse.Product.Id,
                    HeroImage = getProductServiceResponse.Product.HeroImage.ToEntity(),
                    ExpirationDate = getProductServiceResponse.Product.ExpirationDate,
                    PostDateTime = getProductServiceResponse.Product.PostDateTime,
                    Description = getProductServiceResponse.Product.Description,
                    Price = getProductServiceResponse.Product.Price.ToEntity(),
                    PurchasedDate = getProductServiceResponse.Product.PurchasedDate,
                    PickupAddress = getProductServiceResponse.Product.PickupAddress.ToEntity(),
                    Images = getProductServiceResponse.Product.Images.ToEntity(),
                    Status = getProductServiceResponse.Product.Status.ToEntity(),
                    Category = getProductServiceResponse.Product.Category.ToEntity()

                }
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
        public static string ToEntity(this Contracts.Category category)
        {
            switch (category)
            {
                case Contracts.Category.Bike:
                    return "Bike";
                case Contracts.Category.Book:
                    return "Book";
                case Contracts.Category.Car:
                    return "Car";
                case Contracts.Category.Electronic:
                    return "Electronic";
                case Contracts.Category.Fashion:
                    return "Fashion";
                case Contracts.Category.Furniture:
                    return "Furniture";
                case Contracts.Category.Mobile:
                    return "Mobile";
                case Contracts.Category.Other:
                    return "Other";
                case Contracts.Category.Property:
                    return "Property";
                default :
                    throw new NotSupportedException($"This category is not supported:{category}");
            }
        }
        public static string ToEntity(this Contracts.Status status)
        {
            switch (status)
            {
                case Contracts.Status.Active:
                    return "Active";
                case Contracts.Status.Disabled:
                    return "Disabled";
                case Contracts.Status.Sold:
                    return "Sold";
                default:
                    throw new NotSupportedException($"This status is not supported:{status}");
            }
        }
        public static Address ToEntity(this Contracts.Address pickupAddress)
        {
            if (pickupAddress == null)
                return null;
            return new Product().PickupAddress = new Address()
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
            return new Product().PurchasedDate = purchasedDate;
        }
        public static List<Image> ToEntity(this List<Contracts.Image> images)
        {
            if (images == null)
                return null;
            return new Product().Images = images.Select(x => new Image
            {
                Url = x.Url
            }).ToList();
        }
    }
    
}
