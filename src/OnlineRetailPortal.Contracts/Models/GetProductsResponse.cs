using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Contracts.Models
{
    public class GetProductsResponse
    {
        public List<ProductList> products { get; set; }
    }
}
