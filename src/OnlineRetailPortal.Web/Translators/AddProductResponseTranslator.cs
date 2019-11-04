using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Resources;

namespace OnlineRetailPortal.Web.Translators
{
    public static class AddProductResponseTranslator
    {
        public static AddProductResponse ToUser(this Contracts.AddProductResponse addProductResponse)
        {
            AddProductResponse response = new AddProductResponse()
            {
                SellerId = addProductResponse.SellerId,
                Name = addProductResponse.Name,
                Description = addProductResponse.Description,
                HeroImage = new Image { Url = addProductResponse.HeroImage.Url },
                //Price = new Price { Value = new Value{ addProductResponse.Price.Value.Amount, addProductResponse.Price.Value.Currency }, IsNegotiable = addProductResponse.Price.IsNegotiable },
                PostDateTime = addProductResponse.PostDateTime,
                ExpirationDate = addProductResponse.ExpirationDate,
                Images = addProductResponse.Images.Select(x => new Image
                {
                    Url = x.Url
                }).ToList(),
                PurchasedDate = addProductResponse.PurchasedDate,
                PickupAddress = new Address 
                {
                    Line1 = addProductResponse.PickupAddress.Line1,
                    Line2 = addProductResponse.PickupAddress.Line2,
                    City = addProductResponse.PickupAddress.City,
                    Pincode = addProductResponse.PickupAddress.Pincode,
                    State = addProductResponse.PickupAddress.State
                }
            };

            return response;
        }

    }
}
