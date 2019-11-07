using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineRetailPortal.Contracts;

namespace OnlineRetailPortal.Web
{
    public static class AddProductTranslator
    {
        public static Contracts.AddProductRequest ToEntity(this AddProductRequest addProductRequest)
        {
            Contracts.AddProductRequest request = new Contracts.AddProductRequest()
            {
                SellerId = addProductRequest.SellerId,
                Name = addProductRequest.Name,
                Description = addProductRequest.Description,
                HeroImage = addProductRequest.HeroImage.ToEntity(),
                Price = addProductRequest.Price.ToEntity(),
                Category = addProductRequest.Category.ToEntity(),
                Images = addProductRequest.Images.ToEntity(),
                PurchasedDate = addProductRequest.PurchasedDate,
                PickupAddress = addProductRequest.PickupAddress.ToEntity()
            };
            return request;
        }

        public static Contracts.Image ToEntity(this Image image)
        {
            if (image == null)
                return null;
            return new Contracts.Image()
            {
                Url = image.Url
            };
        }

        public static Contracts.Price ToEntity(this Price price)
        {
            if (price == null)
                return null;
            return new Contracts.Price()
            {
                Money = new Contracts.Money(
                price.Money.Amount,
                price.Money.Currency),
                IsNegotiable = price.IsNegotiable
            };
        }

        public static Contracts.Category ToEntity(this string category)
        {
            switch (category)
            {
                case "Bike":
                    return Contracts.Category.Bike;
                case "Book":
                    return Contracts.Category.Book;
                case "Car":
                    return Contracts.Category.Car;
                case "Electronic":
                    return Contracts.Category.Electronic;
                case "Fashion":
                    return Contracts.Category.Fashion;
                case "Furniture":
                    return Contracts.Category.Furniture;
                case "Mobile":
                    return Contracts.Category.Mobile;
                case "Other":
                    return Contracts.Category.Other;
                case "Property":
                    return Contracts.Category.Property;
            }
            throw new NotSupportedException(category + " is not supported");
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

        public static AddProductResponse ToModel(this Contracts.AddProductResponse addProductResponse)
        {
            AddProductResponse response = new AddProductResponse()
            {
                Id = addProductResponse.Id,
                SellerId = addProductResponse.SellerId,
                Name = addProductResponse.Name,
                Description = addProductResponse.Description,
                HeroImage = addProductResponse.HeroImage.ToModel(),
                Price = addProductResponse.Price.ToModel(),
                Category = addProductResponse.Category.ToModel(),
                Status = addProductResponse.Status.ToModel(),
                PostDateTime = addProductResponse.PostDateTime,
                ExpirationDate = addProductResponse.ExpirationDate,
                Images = addProductResponse.Images.ToModel(),
                PurchasedDate = addProductResponse.PurchasedDate,
                PickupAddress = addProductResponse.PickupAddress.ToModel()
            };

            return response;
        }

        public static Price ToModel(this Contracts.Price price)
        {
            if (price == null)
                return null;
            return new Price()
            {
                Money = new Money() { 
                Amount = price.Money.Amount,
                Currency = price.Money.Currency },
                IsNegotiable = price.IsNegotiable
            };
        }

        public static Image ToModel(this Contracts.Image image)
        {
            if (image == null)
                return null;
            return new Image()
            {
                Url = image.Url
            };
        }

        public static string ToModel(this Contracts.Category category)
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
            }
            throw new NotSupportedException(category + " is not supported");
        }

        public static string ToModel(this Contracts.Status status)
        {
            switch (status)
            {
                case Contracts.Status.Active:
                    return "Active";
                case Contracts.Status.Disabled:
                    return "Disabled";
                case Contracts.Status.Sold:
                    return "Sold";
            }
            throw new NotSupportedException(status + " is not supported");
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
