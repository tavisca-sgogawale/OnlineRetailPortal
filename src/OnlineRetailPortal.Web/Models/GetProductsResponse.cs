using System.Collections.Generic;

namespace OnlineRetailPortal.Web
{
    public class GetProductsResponse
    {
       public List<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }

    }
}