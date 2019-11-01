using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineRetailPortal.Core
{
    public static class AddProductTranslator
    {
        public static AddProductStoreRequest ToEntityRequest(this Product product)
        {
            var  addProductStoreRequest = new AddProductStoreRequest() {
                Name = product.Name,
                Description = product.Description,
                HeroImage = new Contracts.Image { Url = product.HeroImage.Url},
                Price = new Contracts.Price { Value = new Contracts.Value(product.Price.Value.Amount, product.Price.Value.Currency), IsNegotiable = product.Price.IsNegotiable},
                Category = (Contracts.Category)product.Category,
                Images = new Contracts.Product().Images = product.Images.Select(x => new Contracts.Image
                {
                    Url = x.Url
                }).ToList(),
                PurchasedDate = product.PurchasedDate,
                PickupAddress = new Contracts.Product().PickupAddress = new Contracts.Address()
                {
                    Line1 = product.PickupAddress.Line1,
                    Line2 = product.PickupAddress.Line2,
                    City = product.PickupAddress.City,
                    Pincode = product.PickupAddress.Pincode,
                    State = product.PickupAddress.State
                }
            };

            return addProductStoreRequest;
        }

        public static Product ToProduct(this AddProductStoreResponse addProductStoreResponse)
        {
            var product = new Product()
            {
                Id = addProductStoreResponse.Id,
                Name = addProductStoreResponse.Name,
                Description = addProductStoreResponse.Description,
                HeroImage = new Image { Url = addProductStoreResponse.HeroImage.Url },
                Price = new Price { Value = new Value(addProductStoreResponse.Price.Value.Amount, addProductStoreResponse.Price.Value.Currency), IsNegotiable = addProductStoreResponse.Price.IsNegotiable },
                Category = (Category)addProductStoreResponse.Category,
                Status = (Status)addProductStoreResponse.Status,
                PostDateTime = addProductStoreResponse.PostDateTime,
                ExpirationDate = addProductStoreResponse.ExpirationDate,
                Images = addProductStoreResponse.Images.Select(x => new Image
                {
                    Url = x.Url
                }).ToList(),
                PurchasedDate = addProductStoreResponse.PurchasedDate,
                PickupAddress = new Address
                {
                    Line1 = addProductStoreResponse.PickupAddress.Line1,
                    Line2 = addProductStoreResponse.PickupAddress.Line2,
                    City = addProductStoreResponse.PickupAddress.City,
                    Pincode = addProductStoreResponse.PickupAddress.Pincode,
                    State = addProductStoreResponse.PickupAddress.State
                }
            };

            return product;
        }
    }
}
