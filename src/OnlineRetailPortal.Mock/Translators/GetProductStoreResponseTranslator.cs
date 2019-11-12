using OnlineRetailPortal.Contracts;

namespace OnlineRetailPortal.Mock
{
    public static class GetProductStoreResponseTranslator
    {
        public static ProductStoreResult ToGetProductStore(this Product product)
        {
            ProductStoreResult response = new ProductStoreResult()
            {
                Product = product.ToEntity()
            };
            return response;

        }
    }
}
