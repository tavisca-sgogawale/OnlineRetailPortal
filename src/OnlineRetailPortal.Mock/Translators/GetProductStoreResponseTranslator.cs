using OnlineRetailPortal.Contracts;

namespace OnlineRetailPortal.Mock
{
    public static class GetProductStoreResponseTranslator
    {
        public static GetProductStoreResponse ToGetProductStore(this Product product)
        {
            GetProductStoreResponse response = new GetProductStoreResponse()
            {
                Product = product.ToEntity()
            };
            return response;

        }
    }
}
