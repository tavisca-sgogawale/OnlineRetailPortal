using OnlineRetailPortal.Contracts;

namespace OnlineRetailPortal.Core
{
    public static class GetProductServiceRequestTranslator
    {
        public static SearchQuery ToEntity(this GetProductsServiceRequest request)
        {
            if (request.PagingInfo == null)
            {
                return null;
            }
            SearchQuery page = new SearchQuery()
            {
                PagingInfo = request.PagingInfo
            };
            return page;
        }
    }
}
