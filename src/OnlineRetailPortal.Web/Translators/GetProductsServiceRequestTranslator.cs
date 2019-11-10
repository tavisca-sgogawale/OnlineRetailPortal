using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Web
{
    public static class GetProductsServiceRequestTranslator
    {
        private const int _pageNo = 1;
        private const int _pageSize = 100;
        private const string _sortBy = "Date";
        private const string _sortOrder = "asc"; // Enum
        public static GetProductsServiceRequest ToServiceRequest(this GetProductRequest request, int pageNo, int pageSize)
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
                    SortBy = String.IsNullOrEmpty(request.ProductSort.SortBy) ? _sortBy : request.ProductSort.SortBy,
                    SortOrder = String.IsNullOrEmpty(request.ProductSort.SortOrder) ? _sortOrder : request.ProductSort.SortOrder
                },
                Filters = request.Filters.Select(x => new Contracts.Filter() { searchQuery = x.searchQuery }).ToList()
            };
            }
    }
}
