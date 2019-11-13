using OnlineRetailPortal.Contracts;

namespace OnlineRetailPortal.Mock
{
    public static class GetProductStoreResponseTranslator
    {
        public static GetProductStoreResponse ToGetProductStore(this Product product)
        {
            if (product == null)
                return null;
            GetProductStoreResponse response = new GetProductStoreResponse()
            {
                Product = product.ToEntity()
            };
            return response;

        }
    }
}
