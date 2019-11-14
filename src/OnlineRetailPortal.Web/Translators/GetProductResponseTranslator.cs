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
                    HeroImage = getProductServiceResponse.Product.HeroImage,
                    ExpirationDate = getProductServiceResponse.Product.ExpirationDate,
                    PostDateTime = getProductServiceResponse.Product.PostDateTime,
                    Description = getProductServiceResponse.Product.Description,
                    Price = getProductServiceResponse.Product.Price.ToModel(),
                    PurchasedDate = getProductServiceResponse.Product.PurchasedDate,
                    PickupAddress = getProductServiceResponse.Product.PickupAddress.ToModel(),
                    Images = getProductServiceResponse.Product.Images,
                    SellerId= getProductServiceResponse.Product.SellerId,
                    Status = getProductServiceResponse.Product.Status.ToModel(),
                    Category = getProductServiceResponse.Product.Category.ToModel()
                }
            };
            return response;
        }
    }
    
}
