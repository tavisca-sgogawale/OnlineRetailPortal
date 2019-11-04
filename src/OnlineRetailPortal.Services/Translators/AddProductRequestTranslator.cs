using System;
using System.Collections.Generic;
using System.Text;
using OnlineRetailPortal.Core;
using System.Linq;

namespace OnlineRetailPortal.Services
{
    public static class AddProductRequestTranslator
    {
        public static Product ToCore(this Contracts.AddProductRequest addProductRequest)
        {
            var product = new Product()
            {
                Id = addProductRequest.SellerId,
                Name = addProductRequest.Name,
                Description = addProductRequest.Description,
                HeroImage = new Image { Url = addProductRequest.HeroImage.Url },
        //        Price = new Contracts.Price { Value = new Contracts.Value(addProductRequest.Price.Value.Amount, addProductRequest.Price.Value.Currency), IsNegotiable = addProductRequest.Price.IsNegotiable },
                Category = (Category)addProductRequest.Category,
                PurchasedDate = addProductRequest.PurchasedDate,
                Images = addProductRequest.Images.Select(x => new Image
                {
                    Url = x.Url
                }).ToList(),
                PickupAddress = new Address
                {
                    Line1 = addProductRequest.PickupAddress.Line1,
                    Line2 = addProductRequest.PickupAddress.Line2,
                    City = addProductRequest.PickupAddress.City,
                    Pincode = addProductRequest.PickupAddress.Pincode,
                    State = addProductRequest.PickupAddress.State
                }
            };
            return product;
        }
    }
}
