using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineRetailPortal.Core
{
    public static class GetProductsCoreResponseTranslator
    {

        public static ProductsWithPageInitiation ToProductsWithPageInitiation(this GetProductsStoreResponse getProductResponse)
        {
            ProductsWithPageInitiation responce = new ProductsWithPageInitiation()
            {
                Products = getProductResponse.Products.ToEntity(),
                PagingInfo = getProductResponse.PagingInfo.ToEntity()
            };
            return responce;
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
            return products.Select(x => new Product(x.Price.ToEntity(),x.SellerId,x.Name)
            {                
                Id = x.Id,
                HeroImage = x.HeroImage.ToEntity(),
                PostDateTime = x.PostDateTime, 
            }).ToList();
        }

    }
}