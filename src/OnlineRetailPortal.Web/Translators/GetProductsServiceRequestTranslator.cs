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
        public static GetProductsServiceRequest ToServiceRequest(int pageNo, int pageSize)
        {
            return new GetProductsServiceRequest()
            {
                PagingInfo = new Contracts.PagingInfo()
                {
                    PageNumber = pageNo == 0 ? _pageNo : pageNo,
                    PageSize = pageSize == 0 ? _pageSize : pageSize
                }
            };
        }
    }
}
