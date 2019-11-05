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
                    HeroImage = x.HeroImage.ToEntity(),
                    PostDateTime = x.PostDateTime,
                    Price = x.Price.ToEntity(),                 
                }).ToList(),
                PagingInfo = new PagingInfo()
                {
                    PageNumber = getProductsResponse.PagingInfo.PageNumber,
                    PageSize = getProductsResponse.PagingInfo.PageSize,
                    TotalPages = getProductsResponse.PagingInfo.TotalPages
                }

            };
            return response;

        }

    }
}