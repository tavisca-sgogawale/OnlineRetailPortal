using System.Collections.Generic;

namespace OnlineRetailPortal.Core
{
    public class GetProductsCoreResponce
    {
        public List<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    } 
}