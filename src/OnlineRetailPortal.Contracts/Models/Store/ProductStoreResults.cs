using System.Collections.Generic;

namespace OnlineRetailPortal.Contracts
{
    public class ProductStoreResults
    {
        public List<ProductEntity> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}