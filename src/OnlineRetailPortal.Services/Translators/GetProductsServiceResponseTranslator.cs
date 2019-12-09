using OnlineRetailPortal.Contracts;

namespace OnlineRetailPortal.Services
{
    static class GetProductsServiceResponseTranslator
    {
        public static GetProductsServiceResponse ToModel(this Core.ProductsWithPageInitiation getProductsResponse)
        {
            if (getProductsResponse == null)
                return null;
            GetProductsServiceResponse response = new GetProductsServiceResponse()
            {
                Products = getProductsResponse.Products.ToModel(),
                PagingInfo = getProductsResponse.PagingInfo.ToModel()
            };
            return response;
        }
    }
}