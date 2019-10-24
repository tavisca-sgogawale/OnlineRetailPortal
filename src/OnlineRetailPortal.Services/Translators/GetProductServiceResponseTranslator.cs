﻿using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineRetailPortal.Services
{
    public static class GetProductServiceResponseTranslator
    {
        public static GetProductServiceResponse ToGetProductContract(this Core.Product getProductResponse)
        {
            GetProductServiceResponse response = new GetProductServiceResponse()
            {
                Product = new Product()
                {
                    Name = getProductResponse.Name,
                    Id = getProductResponse.Id,
                    HeroImage = new Contracts.Image() { Url = getProductResponse.HeroImage.Url },
                    ExpirationDate = getProductResponse.ExpirationDate,
                    PostDateTime = getProductResponse.PostDateTime,
                    Description = getProductResponse.Description,
                    Price = new Contracts.Price() { Amount = getProductResponse.Price.Amount, IsNegotiable = getProductResponse.Price.IsNegotiable },
                    PurchasedDate = getProductResponse.PurchasedDate,
                    PickupAddress = new Contracts.Address()
                    {
                        City = getProductResponse.PickupAddress.City,
                        State = getProductResponse.PickupAddress.State,
                        Line1 = getProductResponse.PickupAddress.Line1,
                        Line2 = getProductResponse.PickupAddress.Line2,
                        Pincode = getProductResponse.PickupAddress.Pincode
                    },
                    Images = getProductResponse.Images.Select(x => new Contracts.Image
                    {
                        Url = x.Url
                    }).ToList(),
                    Status = (Contracts.Status)getProductResponse.Status.GetHashCode(),
                    Category = (Contracts.Category)getProductResponse.Category.GetHashCode()
                }
            };
            
            return response;
        }
    }
}
