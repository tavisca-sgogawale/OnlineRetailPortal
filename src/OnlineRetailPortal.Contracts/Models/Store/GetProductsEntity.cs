using System.Collections.Generic;

namespace OnlineRetailPortal.Contracts
{
    public class GetProductsEntity
    {
        public PagingInfo PagingInfo { get; set; }
        public Sort ProductSort { get; set; }
        public List<Filter> Filters { get; set; }
    }
}