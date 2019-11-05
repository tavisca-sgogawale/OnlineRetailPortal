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
                Value = new Contracts.Value(
                price.Value.Amount,
                price.Value.Currency),
                IsNegotiable = price.IsNegotiable
            };
        }

        public static Contracts.Category ToEntity(this Category category)
        {
            switch (category)
            {
                case Category.Bikes:
                    return Contracts.Category.Bikes;
                case Category.Books:
                    return Contracts.Category.Books;
                case Category.Cars:
                    return Contracts.Category.Cars;
                case Category.Electronics:
                    return Contracts.Category.Electronics;
                case Category.Fashions:
                    return Contracts.Category.Fashions;
                case Category.Furniture:
                    return Contracts.Category.Furniture;
                case Category.Mobiles:
                    return Contracts.Category.Mobiles;
                case Category.Others:
                    return Contracts.Category.Others;
                case Category.Properties:
                    return Contracts.Category.Properties;
                default:
                    return Contracts.Category.Others;
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
            var product = new Product(addProductStoreResponse.SellerId, addProductStoreResponse.Name, new Price { Value = new Value(addProductStoreResponse.Price.Value.Amount, addProductStoreResponse.Price.Value.Currency), IsNegotiable = addProductStoreResponse.Price.IsNegotiable })
            {
                ProductId = addProductStoreResponse.ProductId,
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
                case Contracts.Category.Bikes:
                    return Category.Bikes;
                case Contracts.Category.Books:
                    return Category.Books;
                case Contracts.Category.Cars:
                    return Category.Cars;
                case Contracts.Category.Electronics:
                    return Category.Electronics;
                case Contracts.Category.Fashions:
                    return Category.Fashions;
                case Contracts.Category.Furniture:
                    return Category.Furniture;
                case Contracts.Category.Mobiles:
                    return Category.Mobiles;
                case Contracts.Category.Others:
                    return Category.Others;
                case Contracts.Category.Properties:
                    return Category.Properties;
                default:
                    return Category.Others;
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
                    return Status.Disabled;
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
