using OnlineRetailPortal.Contracts;

namespace OnlineRetailPortal.Core
{
    public static class GetProductServiceRequestTranslator
    {
        public static GetProductsStoreRequest ToProductStoreRequest(this GetProductsServiceRequest request)
        {
            if (request.PagingInfo == null)
            {
                return null;
            }
            GetProductsStoreRequest page = new GetProductsStoreRequest()
            {
                PagingInfo = request.PagingInfo
            };
            return page;
        }
    }
}
