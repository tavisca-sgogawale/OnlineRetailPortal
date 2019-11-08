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
                Products = getProductsServiceResponse.Products.ToEntity(),
                PagingInfo = getProductsServiceResponse.PagingInfo.ToEntity()
            };
            return response;
        }
        public static PagingInfo ToEntity(this Contracts.PagingInfo pagingInfo)
        {
            return new PagingInfo()
            {
                PageNumber = pagingInfo.PageNumber,
                PageSize = pagingInfo.PageSize,
                TotalPages = pagingInfo.TotalPages
            };
        }
        public static List<Product> ToEntity(this List<Contracts.Product> products)
        {
            return  products.Select(x => new Product()
            {
                Name = x.Name,
                Id = x.Id,
                HeroImage = x.HeroImage,
                PostDateTime = x.PostDateTime,
                Price = x.Price.ToModel(),
            }).ToList();
        }
    }
    

}