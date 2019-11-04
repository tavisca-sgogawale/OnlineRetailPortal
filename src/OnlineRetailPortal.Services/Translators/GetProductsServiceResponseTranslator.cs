using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OnlineRetailPortal.Services
{
    static class GetProductsServiceResponseTranslator
    {

        public static GetProductsServiceResponse ToGetProductsContract(this Core.ProductsWithPageInitiation getProductsResponse)
        {
            GetProductsServiceResponse response = new GetProductsServiceResponse()
            {
                Products = getProductsResponse.Products.Select(x => new Product()
                {
                    Name = x.Name,
                    Id = x.Id,
                    HeroImage = new Image() { Url = x.HeroImage.Url },
                    ExpirationDate = x.ExpirationDate,
                    PostDateTime = x.PostDateTime,
                    Description = x.Description,
                    Price = new Price() { Amount = x.Price.Amount, IsNegotiable = x.Price.IsNegotiable },
                    PurchasedDate = x.PurchasedDate,
                    PickupAddress = new Address()
                    {
                        City = x.PickupAddress.City,
                        State = x.PickupAddress.State,
                        Line1 = x.PickupAddress.Line1,
                        Line2 = x.PickupAddress.Line2,
                        Pincode = x.PickupAddress.Pincode
                    },
                    Images = x.Images.Select(y => new Image
                    {
                        Url = y.Url
                    }).ToList(),
                    Status = (Status)x.Status.GetHashCode(),
                    Category = (Category)x.Category.GetHashCode()
                }).ToList(),
                PagingInfo = new PagingInfo()
                {
                    PageNumber = getProductsResponse.PagingInfo.PageNumber,
                    PageSize = getProductsResponse.PagingInfo.PageSize,
                    SortBy = (SortBy)getProductsResponse.PagingInfo.SortBy
                }

            };
            return response;

        }

    }
}