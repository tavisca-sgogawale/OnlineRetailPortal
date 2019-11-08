using OnlineRetailPortal.Contracts;

namespace OnlineRetailPortal.Core
{
    public static class GetProductsCoreResponseTranslator
    {

        public static ProductsWithPageInitiation ToModel(this GetProductsStoreResponse getProductResponse)
        {
            ProductsWithPageInitiation responce = new ProductsWithPageInitiation()
            {
                Products = getProductResponse.Products.ToModel()
            };
            return responce;
        }



    }
}