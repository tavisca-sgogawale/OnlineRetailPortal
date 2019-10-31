using OnlineRetailPortal.Contracts;

namespace OnlineRetailPortal.Core
{
    public static class GetProductServiceRequestTranslator
    {
        public static GetProductsStoreRequest ToProductStoreRequest(this GetProductsServiceRequest request)
        {
            if (request.Page == null)
            {
                return null;
            }
            GetProductsStoreRequest page = new GetProductsStoreRequest()
            {
                Page = new Contracts.PagingInfo()
                {
                    PageNumber = request.Page.PageNumber,
                    PageSize = request.Page.PageSize,
                    SortBy = request.Page.SortBy
                }
            };
            return page;
        }

    }
}
