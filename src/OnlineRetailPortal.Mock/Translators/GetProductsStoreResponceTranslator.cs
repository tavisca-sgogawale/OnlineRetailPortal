using OnlineRetailPortal.Contracts;
using System.Collections.Generic;

namespace OnlineRetailPortal.Mock
{
    public static class GetProductsStoreResponceTranslator
    {
        public static ProductStoreResults ToGetProductsStoreResponse(this List<ProductEntity> products, PagingInfo pagingInfo)
        {
            ProductStoreResults response = new ProductStoreResults()
            {
                Products = products,
                PagingInfo = pagingInfo

            };
            return response;
        }
    }
}
