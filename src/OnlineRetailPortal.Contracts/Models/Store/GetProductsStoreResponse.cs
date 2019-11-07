using System.Collections.Generic;

namespace OnlineRetailPortal.Contracts
{
    public class GetProductsStoreResponse
    {
        public List<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}