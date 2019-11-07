using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OnlineRetailPortal.Services
{
    static class GetProductsServiceResponseTranslator
    {

        public static GetProductsServiceResponse ToModel(this Core.ProductsWithPageInitiation getProductsResponse)
        {
            GetProductsServiceResponse response = new GetProductsServiceResponse()
            {
                Products = getProductsResponse.Products.ToEntity(),
                PagingInfo = getProductsResponse.PagingInfo.ToEntity()
            };
            return response;
        }
        public static PagingInfo ToEntity(this Core.PagingInfo pagingInfo)
        {
            return new PagingInfo()
            {
                PageNumber = pagingInfo.PageNumber,
                PageSize = pagingInfo.PageSize,
                TotalPages = pagingInfo.TotalPages
            };
        }
        public static List<Product> ToEntity(this List<Core.Product> products)
        {
            return products.Select(x => new Product()
            {
                Name = x.Name,
                Id = x.Id,
                HeroImage = x.HeroImage.ToEntity(),
                PostDateTime = x.PostDateTime,
                Price = x.Price.ToEntity(),
            }).ToList();
        }

    }
}