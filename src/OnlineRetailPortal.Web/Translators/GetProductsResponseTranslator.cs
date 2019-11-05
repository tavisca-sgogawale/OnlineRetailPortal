using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Web
{
    public static class GetProductsResponseTranslator
    {
        public static GetProductsResponse ToGetProductsContract(this Contracts.GetProductsServiceResponse getProductsServiceResponse)
        {
            GetProductsResponse response = new GetProductsResponse()
            {
                Products = getProductsServiceResponse.Products.Select(x => new Product()
                {
                    Name = x.Name,
                    Id = x.Id,
                    HeroImage = x.HeroImage.ToEntity(),
                    PostDateTime = x.PostDateTime,
                    Price = x.Price.ToEntity(),
                }).ToList(),
                PagingInfo = new PagingInfo()
                {
                    PageNumber = getProductsServiceResponse.PagingInfo.PageNumber,
                    PageSize = getProductsServiceResponse.PagingInfo.PageSize,
                    TotalPages = getProductsServiceResponse.PagingInfo.TotalPages
                }
            };
            return response;
        }
    }
    

}