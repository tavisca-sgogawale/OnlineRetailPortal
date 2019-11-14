using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineRetailPortal.Core
{
    public static class GetProductsCoreResponseTranslator
    {

        public static ProductsWithPageInitiation ToModel(this GetProductsStoreResponse getProductResponse)
        {
            if (getProductResponse == null)
                return null;
            ProductsWithPageInitiation responce = new ProductsWithPageInitiation()
            {
                Products = getProductResponse.Products.ToModel(),
                PagingInfo = getProductResponse.PagingInfo.ToModel()
            };
            return responce;
        }



    }
}