using OnlineRetailPortal.Contracts;
using System.Collections.Generic;

namespace OnlineRetailPortal.Mock
{
    public static class GetProductsStoreResponceTranslator
    {
        public static GetProductsStoreResponse ToGetProductsStoreResponse(this List<ProductEntity> products, PagingInfo pagingInfo)
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
