using System.Collections.Generic;

namespace OnlineRetailPortal.Contracts
{
    public class GetProductsServiceRequest
    {
        public PagingInfo PagingInfo { get; set; }
        public ProductSort ProductSort { get; set; }
        public List<Filter> Filters { get; set; }
    }
}