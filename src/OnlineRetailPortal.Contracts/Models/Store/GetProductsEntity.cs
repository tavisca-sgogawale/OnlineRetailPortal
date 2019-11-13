using System.Collections.Generic;

namespace OnlineRetailPortal.Contracts
{
    public class GetProductsEntity
    {
        public PagingInfo PagingInfo { get; set; }
        public ProductSort ProductSort { get; set; }
        public List<Filter> Filters { get; set; }
    }
}