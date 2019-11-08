using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineRetailPortal.Mock
{
    public static class GetProductsStoreResponceTranslator
    {
        public static GetProductsStoreResponse ToGetProductsStoreResponse(this List<Product> products , PagingInfo pagingInfo)
        {
            GetProductsStoreResponse response = new GetProductsStoreResponse()
            {
                Products = products,
                PagingInfo = pagingInfo

            };
            return response;
        }
    }
}
