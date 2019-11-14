using System.Collections.Generic;

namespace OnlineRetailPortal.Contracts
{
    public class GetProductsServiceResponse
    {
        public List<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
