using System.Collections.Generic;

namespace OnlineRetailPortal.Contracts
{
    public class GetProductsStoreResponse
    {
        public List<ProductEntity> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}