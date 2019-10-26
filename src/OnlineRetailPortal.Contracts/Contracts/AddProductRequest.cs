using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Contracts
{
    public class AddProductRequest
    {
        public Product Product { get; set; }

        public AddProductRequest()
        {
            this.Product = new Product();
        }
    }
}
