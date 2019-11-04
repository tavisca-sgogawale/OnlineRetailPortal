using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Web.Translators
{
    public static class AddProductRequestTranslator
    {
        public static Contracts.AddProductRequest ToDataContract(this AddProductRequest addProductRequest)
        {
            Contracts.AddProductRequest request = new Contracts.AddProductRequest()
            {
                SellerId = addProductRequest.SellerId,
                Name = addProductRequest.Name,
                Description = addProductRequest.Description,
                HeroImage = new Contracts.Image { Url = addProductRequest.HeroImage.Url },
                Price = new Contracts.Price { Value = new Contracts.Value(addProductRequest.Price.Value.Amount, addProductRequest.Price.Value.Currency), IsNegotiable = addProductRequest.Price.IsNegotiable },
                Category = (Contracts.Category)addProductRequest.Category,
                Images = new Contracts.Product().Images = addProductRequest.Images.Select(x => new Contracts.Image
                {
                    Url = x.Url
                }).ToList(),
                PurchasedDate = addProductRequest.PurchasedDate,
                PickupAddress = new Contracts.Product().PickupAddress = new Contracts.Address()
                {
                    Line1 = addProductRequest.PickupAddress.Line1,
                    Line2 = addProductRequest.PickupAddress.Line2,
                    City = addProductRequest.PickupAddress.City,
                    Pincode = addProductRequest.PickupAddress.Pincode,
                    State = addProductRequest.PickupAddress.State
                }
            };
            return request;
        }
    }
}
