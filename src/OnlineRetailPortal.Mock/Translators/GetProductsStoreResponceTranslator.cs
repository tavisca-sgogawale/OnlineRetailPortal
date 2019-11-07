using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineRetailPortal.Mock
{
    public static class GetProductsStoreResponceTranslator
    {
        public static GetProductsStoreResponse ToGetProductsStoreResponse(this List<Product> products , int pageNo , int pageSize , int totalPages)
        {
            GetProductsStoreResponse response = new GetProductsStoreResponse()
            {
                Products = products,
                PagingInfo = new PagingInfo()
                {
                    PageNumber =pageNo,
                    PageSize = pageSize,
                    TotalPages = totalPages
                }

            };
            return response;
        }
    }
}
