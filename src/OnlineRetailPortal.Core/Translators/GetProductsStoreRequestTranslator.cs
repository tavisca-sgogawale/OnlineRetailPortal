using OnlineRetailPortal.Contracts;

namespace OnlineRetailPortal.Core
{
    public static class GetProductServiceRequestTranslator
    {
        public static GetProductsStoreEntity ToEntity(this GetProductsServiceRequest request)
        {
            if (request.PagingInfo == null)
            {
                return null;
            }
            GetProductsStoreEntity page = new GetProductsStoreEntity()
            {
                PagingInfo = request.PagingInfo
            };
            return page;
        }
    }
}
