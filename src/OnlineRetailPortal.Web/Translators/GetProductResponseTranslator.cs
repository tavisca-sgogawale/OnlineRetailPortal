using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Web
{
    public static class GetProductResponseTranslator
    {
        public static GetProductResponse ToGetProductContract(this Contracts.GetProductServiceResponse getProductServiceResponse)
        {
            GetProductResponse response = new GetProductResponse()
            {
                Product = new Product()
                {
                    Name = getProductServiceResponse.Product.Name,
                    Id = getProductServiceResponse.Product.Id,
                    HeroImage = new Web.Image() { Url = getProductServiceResponse.Product.HeroImage.Url },
                    ExpirationDate = getProductServiceResponse.Product.ExpirationDate,
                    PostDateTime = getProductServiceResponse.Product.PostDateTime,
                    Description = getProductServiceResponse.Product.Description,
                    Price = new Web.Price() { Amount = getProductServiceResponse.Product.Price.Amount, IsNegotiable = getProductServiceResponse.Product.Price.IsNegotiable },
                    PurchasedDate = getProductServiceResponse.Product.PurchasedDate,
                    PickupAddress = new Web.Address()
                    {
                        City = getProductServiceResponse.Product.PickupAddress.City,
                        State = getProductServiceResponse.Product.PickupAddress.State,
                        Line1 = getProductServiceResponse.Product.PickupAddress.Line1,
                        Line2 = getProductServiceResponse.Product.PickupAddress.Line2,
                        Pincode = getProductServiceResponse.Product.PickupAddress.Pincode
                    },
                    Images = getProductServiceResponse.Product.Images.Select(x => new Web.Image
                    {
                        Url = x.Url
                    }).ToList(),
                    Status = (Web.Status)getProductServiceResponse.Product.Status.GetHashCode(),
                    Category = (Web.Category)getProductServiceResponse.Product.Category.GetHashCode()

                }
            };
            return response;
        }
    }
}
