using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Web
{
    public static class GetProductsServiceRequestTranslator
    {
        public static GetProductsServiceRequest ToServiceRequest(int pageNo, int pageSize)
        {
            GetProductsServiceRequest request = new GetProductsServiceRequest()
            {
                PagingInfo = new Contracts.PagingInfo()
                {
                    PageNumber = pageNo,
                    PageSize = pageSize
                }
            };
            return request;
        }
        
    }
}
