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
                Products = getProductsResponse.Products.ToModel(),
                PagingInfo = getProductsResponse.PagingInfo.ToModel()
            };
            return response;
        }
    }
}