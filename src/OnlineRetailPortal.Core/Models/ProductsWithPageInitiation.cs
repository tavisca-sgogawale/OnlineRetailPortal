using System.Collections.Generic;

namespace OnlineRetailPortal.Core
{
    public class ProductsWithPageInitiation
    {
        public List<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    } 
}