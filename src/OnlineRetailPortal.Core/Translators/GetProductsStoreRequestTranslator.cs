using OnlineRetailPortal.Contracts;

namespace OnlineRetailPortal.Core
{
    public static class GetProductServiceRequestTranslator
    {
        public static GetProductsEntity ToEntity(this GetProductsServiceRequest request)
        {
            if (request.PagingInfo == null && request.ProductSort == null)
            {
                return null;
            }
            GetProductsEntity page = new GetProductsEntity()
            {
                PagingInfo = request.PagingInfo,
                ProductSort = request.ProductSort,
            };            
            return page;
        }
    }
}
