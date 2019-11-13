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
                ProductSort = new Contracts.ProductSort()
                {
                    SortBy = String.IsNullOrEmpty(request.ProductSort.SortBy) ? _sortBy : request.ProductSort.SortBy,
                    Order = String.IsNullOrEmpty(request.ProductSort.Order) ? _sortOrder : request.ProductSort.Order
                }
                //Filter is not implemented
                /*
                ,
                Filters = request.Filters.Select(x => new Contracts.Filter() 
                { 
                   Search = new Contracts.SearchFilter() 
                   { 
                       SearchQuery = x.Search.SearchQuery 
                   },
                   Price = new Contracts.PriceFilter()
                   { 
                       Min =x.Price.Min, 
                       Max = x.Price.Max }
                }).ToList()*/
            };
        }
    }
}
