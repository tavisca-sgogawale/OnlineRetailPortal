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
                    HeroImage = new Image() { Url = x.HeroImage.Url },
                    PostDateTime = x.PostDateTime,
                    Price = new Price() { Amount = x.Price.Amount, IsNegotiable = x.Price.IsNegotiable },
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