using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Web
{
    public static class GetProductsServiceRequestTranslator
    {
        public static GetProductsServiceRequest ToServiceRequest(int pageNo, int pageSize, SortBy sortBy)
        {
            GetProductsServiceRequest request = new GetProductsServiceRequest()
            {
                PagingInfo = new Contracts.PagingInfo()
                {
                    PageNumber = pageNo,
                    PageSize = pageSize,
                    SortBy = (Contracts.SortBy)sortBy
                }
            };
            return request;
        }
    }
}
