using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace OnlineRetailPortal.Services
{
    public static class GetProductServiceResponseTranslator
    {
        public static GetProductServiceResponse ToModel(this Core.Product getProductResponse)
        {
            GetProductServiceResponse response = new GetProductServiceResponse()
            {
                Product = new Contracts.Product()
                {
                    Name = getProductResponse.Name,
                    Id = getProductResponse.Id,
                    HeroImage =  getProductResponse.HeroImage,
                    ExpirationDate = getProductResponse.ExpirationDate,
                    PostDateTime = getProductResponse.PostDateTime,
                    Description = getProductResponse.Description,
                    Price = getProductResponse.Price.ToModel(),
                    PurchasedDate = getProductResponse.PurchasedDate,
                    PickupAddress = getProductResponse.PickupAddress.ToModel(),
                    Images = getProductResponse.Images,
                    Status = getProductResponse.Status.ToModel(),
                    Category = getProductResponse.Category.ToModel()
                }
            };            
            return response;
        }   
    }
}
