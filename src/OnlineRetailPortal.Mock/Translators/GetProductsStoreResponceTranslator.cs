using OnlineRetailPortal.Contracts;
using System.Collections.Generic;

namespace OnlineRetailPortal.Mock
{
    public static class GetProductsStoreResponceTranslator
    {
        public static GetProductsStoreResponse ToGetProductsStoreResponse(this List<Product> products)
        {
            GetProductsStoreResponse response = new GetProductsStoreResponse()
            {
                Products = products,

            };
            return response;
        }
    }
}
