using OnlineRetailPortal.Contracts;
using System;

namespace OnlineRetailPortal.Web
{
    public static class GetProductsServiceRequestTranslator
    {
        private const int _pageNo = 1;
        private const int _pageSize = 100;
        private const string _sortType = "Date";
        private const string _sortOrder = "Desc";
        public static GetProductsServiceRequest ToServiceRequest(this GetProductsRequest request, int pageNo, int pageSize)
        {
            return new GetProductsServiceRequest()
            {
                PagingInfo = new Contracts.PagingInfo()
                {
                    PageNumber = pageNo == 0 ? _pageNo : pageNo,
                    PageSize = pageSize == 0 ? _pageSize : pageSize
                },
                ProductSort = new Contracts.Sort()
                {
                    Type = String.IsNullOrEmpty(request.ProductSort.Type) ? _sortType : request.ProductSort.Type,
                    Order = String.IsNullOrEmpty(request.ProductSort.Order) ? _sortOrder : request.ProductSort.Order
                }
            };
        }
    }
}
