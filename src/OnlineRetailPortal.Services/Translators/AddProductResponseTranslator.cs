using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OnlineRetailPortal.Services.Translators
{
    public static class AddProductResponseTranslator
    {
        public static Contracts.AddProductResponse ToWeb(this Core.Product product)
        {
            Contracts.AddProductResponse response = new Contracts.AddProductResponse()
            {
                SellerId = product.Id,
                Name = product.Name,
                Description = product.Description,
                HeroImage = new Contracts.Image { Url = product.HeroImage.Url },
                Price = new Contracts.Price { Amount = product.Price.Amount, IsNegotiable = product.Price.IsNegotiable },
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

            return response;
        }

    }
}
