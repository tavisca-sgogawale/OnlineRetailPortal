using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OnlineRetailPortal.Mock
{
    public static class AddProductTranslator
    {
        public static Product ToModel(this AddProductStoreRequest request)
        {
            var product = new Product()
            {
                SellerId = request.SellerId,
                Name = request.Name,
                Description = request.Description,
                HeroImage = request.HeroImage.ToModel(),
                Price = request.Price.ToModel(),
                Category = request.Category.ToModel(),
                Images = request.Images.ToModel(),
                PurchasedDate = request.PurchasedDate.ToModel(),
                PickupAddress = request.PickupAddress.ToModel()
            };

            return product;
        }

        public static Image ToModel(this Image image)
        {
            return new Image()
            {
                Url = image.Url
            };
        }

        public static Price ToModel(this Price price)
        {
            return new Price()
            {
                Money = new Money(
                price.Money.Amount,
                price.Money.Currency),
                IsNegotiable = price.IsNegotiable
            };
        }

        public static Category ToModel(this Category category)
        {
            switch (category)
            {
                case Category.Bikes:
                    return Category.Bikes;
                case Category.Books:
                    return Category.Books;
                case Category.Cars:
                    return Category.Cars;
                case Category.Electronics:
                    return Category.Electronics;
                case Category.Fashions:
                    return Category.Fashions;
                case Category.Furniture:
                    return Category.Furniture;
                case Category.Mobiles:
                    return Category.Mobiles;
                case Category.Others:
                    return Category.Others;
                case Category.Properties:
                    return Category.Properties;
                default:
                    return Category.Others;
            }
        }

        public static Address ToModel(this Address pickupAddress)
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

        public static DateTime? ToModel(this DateTime? purchasedDate)
        {
            if (purchasedDate == null)
                return null;
            return new Product().PurchasedDate = purchasedDate;
        }

        public static List<Image> ToModel(this List<Image> images)
        {
            if (images == null)
                return null;
            return new Product().Images = images.Select(x => new Image
            {
                Url = x.Url
            }).ToList();
        }


        public static AddProductStoreResponse ToEntity(this Product product)
        {
            var entityPostResponse = new AddProductStoreResponse()
            {
                SellerId = product.SellerId,
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                HeroImage = product.HeroImage.ToEntity(),
                Price = product.Price.ToEntity(),
                Category = product.Category.ToEntity(),
                Status = product.Status.ToEntity(),
                PostDateTime = product.PostDateTime,
                ExpirationDate = product.ExpirationDate,
                Images = product.Images.ToEntity(),
                PurchasedDate = product.PurchasedDate.ToEntity(),
                PickupAddress = product.PickupAddress.ToEntity()
            };

            return entityPostResponse;
        }

        public static Image ToEntity(this Image image)
        {
            return new Image()
            {
                Url = image.Url
            };
        }

        public static Price ToEntity(this Price price)
        {
            return new Price()
            {
                Money = new Money(
                price.Money.Amount,
                price.Money.Currency),
                IsNegotiable = price.IsNegotiable
            };
        }

        public static Category ToEntity(this Category category)
        {
            switch (category)
            {
                case Category.Bikes:
                    return Category.Bikes;
                case Category.Books:
                    return Category.Books;
                case Category.Cars:
                    return Category.Cars;
                case Category.Electronics:
                    return Category.Electronics;
                case Category.Fashions:
                    return Category.Fashions;
                case Category.Furniture:
                    return Category.Furniture;
                case Category.Mobiles:
                    return Category.Mobiles;
                case Category.Others:
                    return Category.Others;
                case Category.Properties:
                    return Category.Properties;
                default:
                    return Category.Others;
            }
        }

        public static Status ToEntity(this Status status)
        {
            switch (status)
            {
                case Status.Active:
                    return Status.Active;
                case Status.Disabled:
                    return Status.Disabled;
                case Status.Sold:
                    return Status.Sold;
                default:
                    return Status.Active;
            }
        }

        public static Address ToEntity(this Address pickupAddress)
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

        public static DateTime? ToEntity(this DateTime? purchasedDate)
        {
            if (purchasedDate == null)
                return null;
            return new Product().PurchasedDate = purchasedDate;
        }

        public static List<Image> ToEntity(this List<Image> images)
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
